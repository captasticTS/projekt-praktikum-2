﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ArrowLog.Database.Models;

public class Game
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Code { get; set; }
    public List<Score> Scores { get; set; } = new();
    public Ruleset Ruleset { get; set; } = new();
    public Person Owner { get; set; } = new();
    public Parcours Parcours { get; set; } = new();
    public List<Person> activePlayers { get; set; } = new();

    [NotMapped]
    public bool IsActive => activePlayers.Any();
}
