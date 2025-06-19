using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api/lessons")]
public class LessonController : ControllerBase
{
    private readonly IService<Lesson> service;

    public LessonController(IService<Lesson> _service)
    {
        service = _service;
    }

    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<Lesson>>> GetAll()
    {
        var result = await service.GetAll();
        return Ok(result);
    }

    [HttpPost]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<LessonResponseDto>>> Create([FromBody] LessonRequestDto requestDto)
    {
        var created = await service.Create<LessonRequestDto, LessonResponseDto>(requestDto);
        return Created(string.Empty, created);
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<Lesson>>> Update(int id, [FromBody] LessonRequestDto requestDto)
    {
        await service.Update(id, requestDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<Lesson>>> Delete(int id)
    {
        await service.Delete(id);
        return NoContent();
    }
}