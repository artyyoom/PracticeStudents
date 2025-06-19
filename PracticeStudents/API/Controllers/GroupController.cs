using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{
    private readonly GroupService service;

    public GroupController(GroupService _service)
    {
        service = _service;
    }

    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<GroupResponseDto>>> GetByCourse([FromQuery] string requestName)
    {
        var result = await service.GetByFilter(requestName);
        return Ok(result);
    }

    [HttpPost]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<GroupResponseDto>>> Create([FromBody] GroupRequestDto requestDto)
    {
        var created = await service.Create<GroupRequestDto, GroupResponseDto>(requestDto);
        return Created(string.Empty, created);
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Update(int id, [FromBody] GroupRequestDto requestDto)
    {
        await service.Update(id, requestDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Delete(int id)
    {
        await service.Delete(id);
        return NoContent();
    }
}