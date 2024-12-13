namespace ArrowLog.Database.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public int LastName { get; set; }
    public string NickName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public List<Score> Scores { get; set; } = new();
}
