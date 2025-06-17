using System.ComponentModel.DataAnnotations;
using PracticeStudents.Domain.Entities;

namespace PracticeStudents.Domain.Entities;

public class Group : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CourseId { get; set; }

    // Навигационные свойства
    public Course Course { get; set; } = null!;
    public ICollection<StudentsGroup>? StudentsInGroups { get; set; } = new List<StudentsGroup>();
    public ICollection<Lesson>? Lessons { get; set; } = new List<Lesson>();
}
