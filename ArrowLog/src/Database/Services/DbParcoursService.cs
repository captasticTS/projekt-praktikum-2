﻿using ArrowLog.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ArrowLog.Database.Services;

public class DbParcoursService
{
    private AppDbContext _context;

    public DbParcoursService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Parcours?> CreateParcours(Parcours parcours)
    {
        try
        {
            if (!VerificationService.VerifyParcours(parcours))
            {
                return null;
            }

            var alreadyExists = await _context.Parcours
                .AnyAsync(x => x.Name == parcours.Name);

            if (alreadyExists)
            {
                return null;
            }

            await _context.Parcours.AddAsync(parcours);

            await _context.SaveChangesAsync();

            return parcours;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Parcours>?> FindParcoursByName(string name)
    {
        try
        {
            var parcours = await _context.Parcours
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            return parcours;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Parcours>?> FindParcoursByLocation(string location)
    {
        try
        {
            var parcours = await _context.Parcours
                .Where(p => p.Location.ToLower().Contains(location.ToLower()))
                .ToListAsync();

            return parcours;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<Parcours>?> FindParcoursByAnimalCount(int animalCount)
    {
        try
        {
            var parcours = await _context.Parcours
                .Where(x => x.AnimalCount == animalCount)
                .ToListAsync();

            return parcours;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Parcours?> UpdateParcours(Parcours parcours)
    {
        try
        {
            var existingParcours = await _context.Parcours.FindAsync(parcours.Id);

            if (existingParcours is null)
            {
                return null;
            }

            existingParcours.Name = parcours.Name;
            existingParcours.Location = parcours.Location;
            existingParcours.AnimalCount = parcours.AnimalCount;

            await _context.SaveChangesAsync();

            return existingParcours;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> DeleteParcours(Parcours parcours)
    {
        try
        {
            var existingParcours = await _context.Parcours.FindAsync(parcours.Id);

            if (existingParcours is null)
            {
                return false;
            }

            _context.Parcours.Remove(existingParcours);

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

