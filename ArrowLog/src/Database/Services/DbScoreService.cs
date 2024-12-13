using ArrowLog.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArrowLog.Database.Services;

public class DbScoreService
{
    private AppDbContext _context;

    public DbScoreService(AppDbContext context)
    {
        _context = context;
    }

    /*
    public Score CreateScore(Score score)
    {
        try
        {

            await _context.Persons.AddAsync(person);

            await _context.SaveChangesAsync();

            return person;
        }
        catch (Exception ex)
        {
            return null;
        }
    } 
    */
}