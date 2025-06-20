using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api/groups/{groupId}/students")]
public class StudentsGroupController : ControllerBase
{
    private readonly StudentsGroupService service;

    public StudentsGroupController(StudentsGroupService _service)
    {
        service = _service;
    }

    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<StudentsGroupResponseDto>>> Create(int groupID, [FromBody] StudentsGroupRequestDto requestDto)
    {
        var created = await service.Create(requestDto, groupID);
        return Created(string.Empty, created);
    }

    [HttpDelete("{studentId}")]
    [Authorize(Roles = "Teacher")]
    public async Task<ActionResult> Delete(int studentId)
    {
        await service.Delete(studentId);
        return NoContent();
    }
}