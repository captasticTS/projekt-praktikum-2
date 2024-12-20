namespace ArrowLog.Database.Models;

public class HitType
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<int> Values { get; set; } = new();
}

