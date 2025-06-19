using PracticeStudents.Domain.Entities;

public class StudentsGroupRepository : AbstractRepository<StudentsGroup>
{
    public StudentsGroupRepository(ProjectDbContext context) : base(context)
    {
    }
}