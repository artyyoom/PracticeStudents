using PracticeStudents.Domain.Entities;

public class AttendanceService : AbstractService<Attendance>
{
    public AttendanceService(IRepository<Attendance> repository, IGenericMapper mapper) : base(repository, mapper)
    {
    }
}