using System.ComponentModel.DataAnnotations;
using PracticeStudents.Domain.Entities;
using PracticeStudents.Domain.Enums;


namespace PracticeStudents.Domain.Entities;


public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Role Role { get; set; }

    // Навигационные свойства
    public ICollection<Course>? CreatedCourses { get; set; } = new List<Course>();
    public ICollection<StudentsGroup>? StudentsInGroups { get; set; } = new List<StudentsGroup>();
    public ICollection<Attendance>? Attendances { get; set; } = new List<Attendance>();
}
