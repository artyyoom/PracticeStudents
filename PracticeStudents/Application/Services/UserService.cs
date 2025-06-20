using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeStudents.Domain.Entities;
using ServiceRegistration;
    

[ServiceScoped]
public class UserService : AbstractService<User>
{
    private readonly IRepository<User> _repository;
    private readonly IPasswordHasher<User> _passwordHasher;


    public UserService(IRepository<User> repository, IGenericMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        User? user = await _repository.GetByFuncAsync(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        return user;
    }

    public async Task<bool> Register(RegisterRequestDto dto)
    {
        var existingUser = await GetByEmailAsync(dto.Email);

        if (existingUser != null)
            return false;

        var user = new User
        {
            Email = dto.Email,
            Role = dto.Role
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        await _repository.AddAsync(user);

        return true;
    }

    public async Task<string?> Login(LoginRequestDto dto)
    {
        var user = await GetByEmailAsync(dto.Email);
        if (user == null)
            return null;

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (result == PasswordVerificationResult.Failed)
            return null;

        var token = GenerateJwtToken(user);
        return token;
    }

    internal async Task<UserProfileDto> GetProfile(string email)
    {
        User user = await GetByEmailAsync(email);

        return _mapper.Map<User, UserProfileDto>(user);
    }

    private string? GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var key = AuthOptions.GetSymmetricSecurityKey();
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}