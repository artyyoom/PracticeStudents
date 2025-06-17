using System.ComponentModel.DataAnnotations;
using PracticeStudents.Domain.Entities;

namespace PracticeStudents.Domain.Entities;

public class StudentsGroup : IEntity
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }

    // Навигационные свойства
    public User Student { get; set; } = null!;
    public Group Group { get; set; } = null!;
}

