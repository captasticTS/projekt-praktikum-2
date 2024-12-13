namespace ArrowLog.Database.Models;

public class Parcours
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int AnimalCount { get; set; }
    public List<Game> Games { get; set; } = new();
}

