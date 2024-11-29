using ArrowLog.Database;

namespace ArrowLog.Features.Login;

public class AuthService
{
    private readonly AppDbContext _dbContext;

    public AuthService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User ValidateUser(string username, string password)
    {
        var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);

        if (user != null && EncryptionService.VerifyPassword(password, user.PasswordHash))
        {
            return user;
        }
        return null;
    }

    public User RegisterUser(string username, string password)
    {
        if (_dbContext.Users.Any(u => u.Username == username))
        {
            return null;
        }

        var user = new User()
        {
            Username = username,
            PasswordHash = EncryptionService.HashPassword(password)
        };

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user;
    }
}

