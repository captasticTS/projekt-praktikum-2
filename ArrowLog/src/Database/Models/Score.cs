using System.ComponentModel.DataAnnotations;

namespace ArrowLog.Database.Models;

public class Score
{
    public int Id { get; set; }
    [Required] 
    public int TotalScore {  get; set; }
}
