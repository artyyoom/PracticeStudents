using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class UserController : ControllerBase
{
    private readonly UserService service;

    public UserController(UserService _userService)
    {
        service = _userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequestDto dto)
    {

        AppLogger.Info("Попытка регистрации пользователя с email {Email}", dto.Email);

        bool value = await service.Register(dto);

        if (value == false)
        {
            AppLogger.Warning("Попытка регистрации не удалась: пользователь с email {Email} уже существует", dto.Email);
            return BadRequest("User with this email already exists.");
        }

        AppLogger.Info("Пользователь с email {Email} успешно зарегистрирован", dto.Email);
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login([FromBody] LoginRequestDto dto)
    {

        AppLogger.Info("Попытка входа пользователя с email {Email}", dto.Email);

        var token = await service.Login(dto);

        if (token == null) {
            AppLogger.Warning("Попытка входа не удалась: пользователь с email {Email} не найден", dto.Email);
            return BadRequest("User with this email not found");
        }

        AppLogger.Info("Пользователь с email {Email} успешно вошел в систему", dto.Email);
        return Ok(new { token });
        }

    [HttpGet("profile")]
    [Authorize]
    public async Task<ActionResult<UserProfileDto>> GetProfile()
    {
        var email = User.Identity?.Name;

        if (string.IsNullOrEmpty(email))
        {
            AppLogger.Warning("Попытка доступа к профилю без авторизации");
            return Unauthorized();
        }

        AppLogger.Info("Запрос профиля пользователя с email {Email}", email);

        var userProfileDto = await service.GetProfile(email);

        AppLogger.Info("Профиль пользователя с email {Email} успешно получен", email);
        return Ok(userProfileDto);
    }
}