using Microsoft.EntityFrameworkCore;
using PracticeStudents.Domain.Entities;

public class GroupRepository : AbstractRepository<Group>
{
    public GroupRepository(ProjectDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Group>> GetByFilterAsync(string requestName)
    {
        return await _context.Set<Group>().Where(x => x.Name.ToLower() == requestName.ToLower()).ToListAsync();
    }
}