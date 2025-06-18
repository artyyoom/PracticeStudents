using Microsoft.EntityFrameworkCore;
using PracticeStudents.Domain.Entities;

using ServiceRegistration;

[ServiceScoped]
public class CourseRepository : AbstractRepository<Course>
{
    public CourseRepository(ProjectDbContext context) : base(context)
    {
    }
}