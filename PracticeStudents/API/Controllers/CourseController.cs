using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;


[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly IService<Course> courseService;

    public CourseController(IService<Course> _courseService)
    {
        courseService = _courseService;
    }

    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<Course>>> GetAll()
    {
        var courses = await courseService.GetAll();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<Course>>> Get(int id)
    {
        var course = await courseService.Get(id);
        return Ok(course);
    }

    [HttpPost]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<CourseResponseDto>>> Create([FromBody] CourseRequestDto courseDto)
    {
        var created = await courseService.Create<CourseRequestDto, CourseResponseDto>(courseDto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<Course>>> Update(int id, [FromBody] Course course)
    {
        if (id != course.Id)
            return BadRequest("ID mismatch");

        await courseService.Update(course);
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<Course>>> Delete(int id)
    {
        await courseService.Delete(id);
        return NoContent();
    }
}