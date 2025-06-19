using PracticeStudents.Domain.Entities;

public class LessonService : AbstractService<Lesson>
{
    private readonly LessonRepository _lessonRepository;

    public LessonService(LessonRepository lessonRepository, IRepository<Lesson> repository, IGenericMapper mapper) : base(repository, mapper)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<IEnumerable<LessonResponseDto>> GetByGroupIdAsync(int groupId)
    {
        var entities = await _lessonRepository.GetByGroupIdAsync(groupId);
        var dtos = _mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonResponseDto>>(entities);
        return dtos;
    }

    public async Task<IEnumerable<LessonResponseDto>> GetByCourseIdAsync(int courseId)
    {
        var entities = await _lessonRepository.GetByCourseIdAsync(courseId);
        var dtos = _mapper.Map<IEnumerable<Lesson>, IEnumerable<LessonResponseDto>>(entities);
        return dtos;
    }
}