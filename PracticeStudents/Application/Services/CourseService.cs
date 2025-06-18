using PracticeStudents.Domain.Entities;
using ServiceRegistration;

[ServiceScoped]
public class CourseService : AbstractService<Course>
{

    public CourseService(IRepository<Course> repository, IGenericMapper mapper) : base(repository, mapper)
    {

    }

}