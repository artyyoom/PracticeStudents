using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api/attendance")]
public class AttendanceController : ControllerBase
{
    private readonly IService<Attendance> service;

    public AttendanceController(IService<Attendance> _service)
    {
        service = _service;
    }

    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<Attendance>>> GetAll()
    {
        var result = await service.GetAll<AttendanceResponseDto>();
        return Ok(result);
    }

    [HttpPost]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<AttendanceResponseDto>>> Create([FromBody] AttendanceRequestDto requestDto)
    {
        var created = await service.Create<AttendanceRequestDto, AttendanceResponseDto>(requestDto);
        return Created(string.Empty, created);
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<Attendance>>> Update(int id, [FromBody] AttendanceRequestDto requestDto)
    {
        await service.Update(id, requestDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<Attendance>>> Delete(int id)
    {
        await service.Delete(id);
        return NoContent();
    }
}