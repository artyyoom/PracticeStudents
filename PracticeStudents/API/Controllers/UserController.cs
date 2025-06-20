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
        bool value = await service.Register(dto);

        if (value == false)
        {
            return BadRequest("User with this email already exists.");
        }
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login([FromBody] LoginRequestDto dto)
    {
        var token = await service.Login(dto);

        if (token == null)
            return BadRequest("User with this email already exists.");

        return Ok(new { token });
        }

    [HttpGet("profile")]
    [Authorize]
    public async Task<ActionResult<UserProfileDto>> GetProfile()
    {
        var email = User.Identity?.Name;

        if (string.IsNullOrEmpty(email))
            return Unauthorized();

        var userProfileDto = await service.GetProfile(email);

        return Ok(userProfileDto);
    }
}