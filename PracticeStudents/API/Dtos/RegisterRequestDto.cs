using PracticeStudents.Domain.Enums;

public class RegisterRequestDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Role Role { get; set; }
}