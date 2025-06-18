using PracticeStudents.Domain.Enums;

public class UserResponseDto
{
    public int id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Role Role { get; set; }
}