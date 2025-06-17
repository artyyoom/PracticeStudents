using Microsoft.EntityFrameworkCore;
using PracticeStudents.Domain.Entities;

public class CourseRepository : AbstractIRepository<Course>
{
    public CourseRepository(DbContext context) : base(context)
    {
    }
}