using ArrowLog.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ArrowLog.Database.Services;

public class DbPersonService
{
    private AppDbContext _context;

    public DbPersonService(AppDbContext context)
    {
        _context = context;
    }

    public bool DeactivatePerson(Person person)
    {
        person.FirstName = "Deleted";
        person.LastName = "User";
        person.NickName = "DeletedUser";
        person.Email = "None";
        person.PasswordHash = "";
        person.Scores = new();
        person.Games = new();

        try
        {
            _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        
    }

    public async Task<Person?> CreatePerson(Person person)
    {
        try
        {
            if (!VerificationService.VerifyPerson(person))
            {
                return null;
            }

            var alreadyExists = await _context.Persons
                .AnyAsync(x => x.NickName == person.NickName);

            if (alreadyExists)
            {
                return null;
            }

            await _context.Persons.AddAsync(person);

            await _context.SaveChangesAsync();

            return person;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Person>?> FindPersonsByName(string name, NameType type = NameType.NickName)
    {
        try
        {
            var persons = await _context.Persons.
                Where(x => type == NameType.NickName && x.NickName == name ||
                           type == NameType.FirstName && x.FirstName == name ||
                           type == NameType.LastName && x.LastName == name)
                .ToListAsync();

            return persons;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Person?> UpdatePerson(Person person)
    {
        try
        {
            var existingPerson = await _context.Persons.FindAsync(person.Id);

            if (existingPerson is null)
            {
                return null;
            }

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.NickName = person.NickName;
            existingPerson.Email = person.Email;
            existingPerson.PasswordHash = person.PasswordHash;

            await _context.SaveChangesAsync();

            return existingPerson;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> DeletePerson(Person person)
    {
        try
        {
            var existingPerson = await _context.Persons.FindAsync(person.Id);

            if (existingPerson is null)
            {
                return false;
            }

            _context.Persons.Remove(existingPerson);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public enum NameType
    {
        NickName = 0, FirstName = 1, LastName = 2
    }
}


