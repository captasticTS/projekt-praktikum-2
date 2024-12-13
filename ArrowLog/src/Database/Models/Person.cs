using System.ComponentModel.DataAnnotations;

namespace ArrowLog.Database.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [Required] 
    public string NickName { get; set; } = string.Empty;
    [Required] 
    public string Email { get; set; } = string.Empty;
    [Required] 
    public string PasswordHash { get; set; } = string.Empty;
    [Required] 
    public List<Score> Scores { get; set; } = new();
}
