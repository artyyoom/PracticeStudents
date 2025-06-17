using System.ComponentModel.DataAnnotations;
using PracticeStudents.Domain.Entities;

namespace PracticeStudents.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int CreatedById { get; set; }

    // Навигационные свойства
    public User CreatedBy { get; set; } = null!;
    public ICollection<Group>? Groups { get; set; } = new List<Group>();
}
