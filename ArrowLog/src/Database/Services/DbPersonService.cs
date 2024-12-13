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

    public async Task<Person?> CreatePerson(Person person)
    {
        try
        {
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
            return null;
        }
    }

    public async Task<List<Person>?> FindPersonsByName(string name, NameType type)
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
        catch
        {
            return null;
        }
    }

    public enum NameType
    {
        NickName = 0, FirstName = 1, LastName = 2
    }
}


