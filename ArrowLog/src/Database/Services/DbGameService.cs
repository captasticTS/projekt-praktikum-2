using ArrowLog.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ArrowLog.Database.Services;

public class DbGameService
{
    private AppDbContext _context;

    public DbGameService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Game?> CreateGame(Game game)
    {
        try
        {
            if (!VerificationService.VerifyGame(game))
            {
                return null;
            }

            var alreadyExists = await _context.Games
                .AnyAsync(x => x.Code == game.Code && x.activePlayers.Any());

            // return early if there is already an existing game with same code
            if (alreadyExists && game.IsActive)
            {
                return null;
            }

            await _context.Games.AddAsync(game);

            await _context.SaveChangesAsync();

            return game;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Game>?> FindGameByCode(int code, bool? activityStatus = null)
    {
        try
        {
            var games = await _context.Games
                .Where(x => x.Code == code && (activityStatus == null || x.activePlayers.Any() == activityStatus))
                .Include(x => x.Ruleset)
                    .ThenInclude(x => x.HitTypes)
                .Include(x => x.Parcours)
                .Include(x => x.Owner)
                .Include(x => x.activePlayers)
                .ToListAsync();

            return games;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Game>?> FindGameByActivity(bool activityStatus)
    {
        try
        {
            var games = await _context.Games
                .Where(x => x.activePlayers.Any() == activityStatus)
                .Include(x => x.Ruleset)
                .Include(x => x.Parcours)
                .ToListAsync();

            return games;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Game>?> FindGameByDay(DateTime date)
    {
        try
        {
            var games = await _context.Games
                .Where(x => x.Date.Date == date.Date)
                .ToListAsync();

            return games;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Game?> UpdateGame(Game game)
    {
        try
        {
            var existingGame = await _context.Games.FindAsync(game.Id);

            if (existingGame is null)
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return existingGame;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> DeleteGame(Game game)
    {
        try
        {
            var existingGame = await _context.Games.FindAsync(game.Id);

            if (existingGame is null)
            {
                return false;
            }

            _context.Games.Remove(existingGame);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
