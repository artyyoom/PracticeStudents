using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PracticeStudents.Domain.Entities;

namespace PracticeStudents.Domain.Entities;

public class Lesson : IEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Topic { get; set; } = null!;
    public int GroupId { get; set; }

    // Навигационные свойства
    public Group Group { get; set; } = null!;
    public ICollection<Attendance>? Attendances { get; set; } = new List<Attendance>();
}

