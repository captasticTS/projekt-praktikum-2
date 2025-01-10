using System;
using ArrowLog.Database;
using ArrowLog.Database.Models;
using ArrowLog.Database.Services;

namespace ArrowLog.Features.Login;

public class AuthService
{
    private readonly AppDbContext _dbContext;

    public AuthService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Person? ValidateUser(string nickname, string password)
    {
        var person = _dbContext.Persons.SingleOrDefault(u => u.NickName == nickname);

//!!!!!!!!!Code only for testing, to be removed before going productive!!!!!!!!!
        if (nickname == "reset" && password == "reset") 
        { 
            var deleteData = new DbDeleteDataService(_dbContext) ;
            deleteData.DeleteAllData();
            return null;
        }
//TODO!!!!!!!!!Code only for testing, to be removed before going productive!!!!!!!!!
        else
        { 
            if (person != null && EncryptionService.VerifyPassword(password, person.PasswordHash))
            {
                return person;
            }
            return null;
        }
        
    }

    public Person? RegisterUser(string nickname, string password)
    {
        if (_dbContext.Persons.Any(u => u.NickName ==  nickname))
        {
            return null;
        }

        var person = new Person()
        {
            NickName = nickname,
            PasswordHash = EncryptionService.HashPassword(password)
        };

        _dbContext.Persons.Add(person);
        _dbContext.SaveChanges();

        return person;
    }
}

