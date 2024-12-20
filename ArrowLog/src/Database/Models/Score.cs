namespace ArrowLog.Database.Models;

public class Score
{
    public int Id { get; set; }
    public Ruleset Ruleset { get; set; } = new();

    // on the firstElement-nth try the seceondElement-th area was hit
    public List<Shot> Results { get; set; } = new();
}
