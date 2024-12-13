using ArrowLog.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ArrowLog.Database.Services;

public class DbScoreService
{
    private AppDbContext _context;

    public DbScoreService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Score?> CreateScore(Score score)
    {
        try
        {
            await _context.Scores.AddAsync(score);

            await _context.SaveChangesAsync();

            return score;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Score?> UpdateScore(Score score)
    {
        try
        {
            var existingScore = await _context.Scores.FindAsync(score.Id);

            if (existingScore is null)
            {
                return null;
            }

            existingScore.TotalScore = score.TotalScore;

            await _context.SaveChangesAsync();

            return existingScore;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> DeleteScore(Score score)
    {
        try
        {
            var existingScore = await _context.Scores.FindAsync(score.Id);

            if (existingScore is null)
            {
                return false;
            }

            _context.Scores.Remove(existingScore);

            await _context.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}

