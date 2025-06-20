using Microsoft.AspNetCore.Mvc;
using PracticeStudents.Domain.Entities;

[ApiController]
[Route("api")]
public class AttendanceController : ControllerBase
{
    private readonly AttendanceService service;

    public AttendanceController(AttendanceService _service)
    {
        service = _service;
    }

    [HttpGet("lessons/{lessonId}/attendance")]
    // [Authorize]
    public async Task<ActionResult<IEnumerable<Attendance>>> GetByLessonId(int lessonId)
    {
        var result = await service.GetListByFuncAsync(lessonId);
        return Ok(result);
    }

    [HttpPost("lessons/{lessonId}/attendance")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult<IEnumerable<AttendanceResponseDto>>> Create(
        int lessonId,[FromBody] IEnumerable<AttendanceRequestDto> requestDtos)
    {
        var created = await service.CreateBulkAsync(lessonId, requestDtos);
        return Created(string.Empty, created);
    }

    [HttpPut("attendance/{attendanceId}")]
    // [Authorize(Roles = "Teacher")]
    public async Task<ActionResult> Update(int attendanceId, [FromBody] AttendanceRequestDto requestDto)
    {
        await service.Update(attendanceId, requestDto);
        return NoContent();
    }
}