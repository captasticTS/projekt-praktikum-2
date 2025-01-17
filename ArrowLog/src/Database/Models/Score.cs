namespace ArrowLog.Database.Models;

public class Score
{
    public int Id { get; set; }
    public Ruleset Ruleset { get; set; } = new();
    public Person Owner { get; set; } = new();

    public List<Shot> Results { get; set; } = new();

    public int getTotalScore()
    {
        int sum = 0;

        foreach (Shot shot in Results)
        {
            sum += shot.ValueHit;
        }

        return sum; 
    }
}
