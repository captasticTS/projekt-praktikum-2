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

        if (user != null /*&& EncryptionService.Verify(password, user.PasswordHash)*/)
        {
            return user;
        }
        return null;
    }
}

