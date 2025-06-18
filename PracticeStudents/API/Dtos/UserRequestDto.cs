using PracticeStudents.Domain.Enums;

public class UserRequestDto
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Role Role { get; set; }
}