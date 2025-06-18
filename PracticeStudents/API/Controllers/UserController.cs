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

    [HttpPost]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> Create([FromBody] UserRequestDto userDto)
    {
        var created = await userService.Create<UserRequestDto, UserResponseDto>(userDto);
        return Ok(created);
    }
}