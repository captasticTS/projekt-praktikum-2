using System.ComponentModel.DataAnnotations;

namespace ArrowLog.Database.Models;

public class Game
{
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public int Code { get; set; }
    [Required] 
    public bool IsActive { get; set; }
    [Required] 
    public List<Score> Scores { get; set; } = new();
}
