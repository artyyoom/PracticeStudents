public class AttendanceResponseDto
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int StudentId { get; set; }
    public bool IsPresent { get; set; }
}