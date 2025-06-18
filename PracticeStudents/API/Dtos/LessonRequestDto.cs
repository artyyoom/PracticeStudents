public class LessonRequestDto
{
    public DateTime Date { get; set; }
    public string Topic { get; set; } = null!;
    public int GroupId { get; set; }
}