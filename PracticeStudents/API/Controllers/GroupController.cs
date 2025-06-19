using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{
    private readonly IService<Group> service;

    public GroupController(IService<Group> _service)
    {
        service = _service;
    }

    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<Group>>> GetAll()
    {
        var result = await service.GetAll<GroupResponseDto>();
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
    public async Task<ActionResult<IEnumerable<Group>>> Update(int id, [FromBody] GroupRequestDto requestDto)
    {
        await service.Update(id, requestDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<Group>>> Delete(int id)
    {
        await service.Delete(id);
        return NoContent();
    }
}