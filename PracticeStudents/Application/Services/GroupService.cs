using PracticeStudents.Domain.Entities;

public class GroupService : AbstractService<Group>
{
    public GroupService(IRepository<Group> repository, IGenericMapper mapper) : base(repository, mapper)
    {
    }
}