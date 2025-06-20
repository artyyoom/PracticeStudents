using PracticeStudents.Domain.Entities;

public class AttendanceService : AbstractService<Attendance>
{
    public AttendanceService(IRepository<Attendance> repository, IGenericMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<AttendanceResponseDto>> GetListByFuncAsync(int requestId)
    {
        var entities = await _repository.GetListByFuncAsync(a => a.LessonId == requestId);
        var dtos = _mapper.Map<IEnumerable<Attendance>, IEnumerable<AttendanceResponseDto>>(entities);
        return dtos;
    }

    public async Task<IEnumerable<AttendanceResponseDto>> CreateBulkAsync(int lessonId, IEnumerable<AttendanceRequestDto> dtos)
{
    var entities = dtos.Select(dto => {
        var entity = _mapper.Map<AttendanceRequestDto, Attendance>(dto);
        entity.LessonId = lessonId;
        return entity;
    }).ToList();

    await _repository.AddRangeAsync(entities);
    return _mapper.Map<IEnumerable<Attendance>, IEnumerable<AttendanceResponseDto>>(entities);
}
}