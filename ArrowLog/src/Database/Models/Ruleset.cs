namespace ArrowLog.Database.Models;

public class Ruleset
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Person Author { get; set; } = new();
    public List<HitType> HitTypes { get; set; } = new();
}