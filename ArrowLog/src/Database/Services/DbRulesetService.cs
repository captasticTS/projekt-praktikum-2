using ArrowLog.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ArrowLog.Database.Services;

public class DbRulsetService
{
    private AppDbContext _context;

    public DbRulsetService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Ruleset?> CreateRulset(Ruleset ruleset)
    {
        try
        {
            if (!VerificationService.VerifyRuleset(ruleset))
            {
                return null;
            }

            var alreadyExists = await _context.Rulesets
                .AnyAsync(x => x.Name == ruleset.Name);

            if (alreadyExists)
            {
                return null;
            }

            await _context.Rulesets.AddAsync(ruleset);

            await _context.SaveChangesAsync();

            return ruleset;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Ruleset>?> FindRulesetByName(string name)
    {
        try
        {
            var ruleset = await _context.Rulesets.
                Where(x => x.Name == name)
                .ToListAsync();

            return ruleset;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Ruleset?> UpdateRuleset(Ruleset ruleset)
    {
        try
        {
            var existingRuleset = await _context.Rulesets.FindAsync(ruleset.Id);

            if (existingRuleset is null)
            {
                return null;
            }

            existingRuleset.Name = ruleset.Name;
            existingRuleset.Author = ruleset.Author;
            existingRuleset.HitTypes = ruleset.HitTypes;

            await _context.SaveChangesAsync();

            return existingRuleset;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> DeleteRuleset(Ruleset ruleset)
    {
        try
        {
            var existingRuleset = await _context.Rulesets.FindAsync(ruleset.Id);

            if (existingRuleset is null)
            {
                return false;
            }

            _context.Rulesets.Remove(existingRuleset);

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