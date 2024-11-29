using System.Security.Cryptography;
using System.Text;

namespace ArrowLog.Features.Login;

public class EncryptionService
{
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        var enteredPasswordHash = HashPassword(enteredPassword);
        return enteredPasswordHash == storedHash;
    }
}

