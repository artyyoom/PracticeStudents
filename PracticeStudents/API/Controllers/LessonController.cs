using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api/lessons")]
public class LessonController : ControllerBase
{
    private readonly LessonService service;

    public LessonController(LessonService _service)
    {
        service = _service;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Lesson>>> GetByFilter([FromQuery] int? groupId, [FromQuery] int? courseId)
    {

        if (groupId.HasValue)
        {
            var lessons = await service.GetByGroupIdAsync(groupId.Value);
            return Ok(lessons);
        }
        else if (courseId.HasValue)
        {
            var lessons = await service.GetByCourseIdAsync(courseId.Value);
            return Ok(lessons);
        }
        
        var result = await service.GetAll<LessonResponseDto>();
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<LessonResponseDto>>> Create([FromBody] LessonRequestDto requestDto)
    {
        var created = await service.Create<LessonRequestDto, LessonResponseDto>(requestDto);
        return Created(string.Empty, created);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Teacher")]
    public async Task<ActionResult> Update(int id, [FromBody] LessonRequestDto requestDto)
    {
        await service.Update(id, requestDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Teacher")]
    public async Task<ActionResult> Delete(int id)
    {
        await service.Delete(id);
        return NoContent();
    }
}