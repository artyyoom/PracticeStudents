using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api/StudentsGroups")]
public class StudentsGroupController : ControllerBase
{
    private readonly IService<StudentsGroup> service;

    public StudentsGroupController(IService<StudentsGroup> _service)
    {
        service = _service;
    }

    [HttpPost]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<StudentsGroupResponseDto>>> Create([FromBody] StudentsGroupRequestDto requestDto)
    {
        var created = await service.Create<StudentsGroupRequestDto, StudentsGroupResponseDto>(requestDto);
        return Created(string.Empty, created);
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<StudentsGroup>>> Delete(int id)
    {
        await service.Delete(id);
        return NoContent();
    }
}