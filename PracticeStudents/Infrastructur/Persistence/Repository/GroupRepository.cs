using PracticeStudents.Domain.Entities;

public class GroupRepository : AbstractRepository<Group>
{
    public GroupRepository(ProjectDbContext context) : base(context)
    {
    }
}