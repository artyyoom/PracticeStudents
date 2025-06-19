using System.Data.Entity;
using PracticeStudents.Domain.Entities;
public class LessonRepository : AbstractRepository<Lesson>
{
    public LessonRepository(ProjectDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Lesson>> GetByGroupIdAsync(int groupId)
    {
        return await _context.Set<Lesson>()
            .Where(l => l.GroupId == groupId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Lesson>> GetByCourseIdAsync(int courseId)
    {
        return await _context.Set<Lesson>()
            .Include(l => l.Group)
            .Where(l => l.Group.CourseId == courseId)
            .ToListAsync();
    }
}
