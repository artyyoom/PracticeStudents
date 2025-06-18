using PracticeStudents.Domain.Entities;
using ServiceRegistration;

[ServiceScoped]
public class UserService : AbstractService<User>
{
    public UserService(IRepository<User> repository, IGenericMapper mapper) : base(repository, mapper)
    {

    }
}