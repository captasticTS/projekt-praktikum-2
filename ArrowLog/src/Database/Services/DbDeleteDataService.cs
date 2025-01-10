using ArrowLog.Database;

public class DbDeleteDataService
{
    private readonly AppDbContext _context;

    public DbDeleteDataService(AppDbContext context)
    {
        _context = context;
    }

    public void DeleteAllData()
    {
        Console.WriteLine("clearing");

        if (_context.Users.Any()) 
        { 
            _context.Users.RemoveRange(_context.Users); 
        };
        if (_context.Persons.Any())
        {
            _context.Persons.RemoveRange(_context.Persons);
        };
        if (_context.Parcours.Any()) 
        {
            _context.Parcours.RemoveRange(_context.Parcours);
        };
        if (_context.Rulesets.Any())
        {
            _context.Rulesets.RemoveRange(_context.Rulesets);
        };
        if (_context.ShotsAtTargets.Any())
        {
            _context.ShotsAtTargets.RemoveRange(_context.ShotsAtTargets);
        };
        if (_context.Scores.Any())
        {
            _context.Scores.RemoveRange(_context.Scores);
        };
        if (_context.Games.Any())
        {
            _context.Games.RemoveRange(_context.Games);
        };

_context.SaveChanges();
        Console.WriteLine("db cleared?");
    }
}
