public class LessonResponseDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Topic { get; set; } = null!;
    public int GroupId { get; set; }
}