using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ArrowLog.Database.Models;

public class Parcours
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    [Required]
    public int AnimalCount { get; set; }
    [Required]
    public List<Game> Games { get; set; } = new();
}

