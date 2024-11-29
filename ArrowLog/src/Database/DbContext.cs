using ArrowLog.Features.Login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ArrowLog.Database;

public class BloggingContext : DbContext
{
    public DbSet<User> Blogs { get; set; }

    public string DbPath { get; }

    public BloggingContext()
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
