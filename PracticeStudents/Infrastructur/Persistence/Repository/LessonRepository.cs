using PracticeStudents.Domain.Entities;

public class LessonRepository : AbstractRepository<Lesson>
{
    public LessonRepository(ProjectDbContext context) : base(context)
    {
    }
}