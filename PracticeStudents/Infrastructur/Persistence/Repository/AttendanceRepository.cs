using PracticeStudents.Domain.Entities;

public class AttendanceRepository : AbstractRepository<Attendance>
{
    public AttendanceRepository(ProjectDbContext context) : base(context)
    {
    }
}