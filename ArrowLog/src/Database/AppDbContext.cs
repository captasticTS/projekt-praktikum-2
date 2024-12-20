using ArrowLog.Database.Models;
using ArrowLog.Features.Login;
using Microsoft.EntityFrameworkCore;

namespace ArrowLog.Database;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Parcours> Parcours { get; set; }
    public DbSet<Ruleset> Rulesets { get; set; }
    public DbSet<Shot> ShotsAtTargets { get; set; }

    public string DbPath { get; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "arrowlog.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
