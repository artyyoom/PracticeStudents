using PracticeStudents.Domain.Entities;

public class CourseService : IService<Course, CourseRequestDto>
{
    public Task<Course> Create(CourseRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Delete(int id, Course entity)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Get(int id, Course entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Course>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Course> Update(int id, Course entity)
    {
        throw new NotImplementedException();
    }
}