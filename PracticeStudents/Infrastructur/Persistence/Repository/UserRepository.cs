using PracticeStudents.Domain.Entities;
using ServiceRegistration;


[ServiceScoped]
public class UserRepository : AbstractRepository<User>
{
    public UserRepository(ProjectDbContext context) : base(context)
    {
    }

    
}
