using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(GenericMappingProfile).Assembly);
builder.Services.AddScoped<IGenericMapper, GenericMapper>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// builder.Services.RegisterServices();

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



builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// app.UseAuthorization();

app.MapControllers();

app.Run();
