using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(GenericMappingProfile).Assembly);
builder.Services.AddScoped<IGenericMapper, GenericMapper>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var assembly = Assembly.GetExecutingAssembly();

builder.Services.Scan(scan => scan
    .FromAssemblies(assembly)
    .AddClasses(classes => classes.AssignableTo(typeof(IService<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());
builder.Services.Scan(scan => scan
    .FromAssemblies(assembly)
    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

builder.Services.AddScoped<GroupRepository>();
builder.Services.AddScoped<GroupService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LessonRepository>();
builder.Services.AddScoped<LessonService>();
builder.Services.AddScoped<StudentsGroupRepository>();
builder.Services.AddScoped<StudentsGroupService>();
builder.Services.AddScoped<AttendanceRepository>();
builder.Services.AddScoped<AttendanceService>();


builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Введите JWT токен в формате: Bearer {token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
