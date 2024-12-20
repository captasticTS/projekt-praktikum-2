namespace ArrowLog.Database.Models;

public class Ruleset
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Person Author { get; set; } = new();

    // [row, col] matrix. the row-th target was hit on the col-th attempt
    // and then receives Points[row, col] points as a reward
    public int[,]? Points;
}