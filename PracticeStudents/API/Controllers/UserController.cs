using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api/auth")]
public class UserController : ControllerBase
{
    private readonly IService<User> userService;

    public UserController(IService<User> _userService)
    {
        userService = _userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> Register([FromBody] UserRequestDto userDto)
    {
        var created = await userService.Create<UserRequestDto, UserResponseDto>(userDto);
        return Ok(created);
    }

    [HttpPost("login")]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> Login([FromBody] UserLoginDto userDto)
    {
        return Ok();
    }

    [HttpGet("profile")]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetProfile()
    {
        return Ok();
    }
}