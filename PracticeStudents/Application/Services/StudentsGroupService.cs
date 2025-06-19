using PracticeStudents.Domain.Entities;

public class StudentsGroupService : AbstractService<StudentsGroup>
{
    public StudentsGroupService(IRepository<StudentsGroup> repository, IGenericMapper mapper) : base(repository, mapper)
    {
    }
}