using PracticeStudents.Domain.Entities;

public class LessonService : AbstractService<Lesson>
{
    public LessonService(IRepository<Lesson> repository, IGenericMapper mapper) : base(repository, mapper)
    {
    }
}