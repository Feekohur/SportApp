using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Result
{
    public int Id { get; set; }

    public int HomeGoals { get; set; }

    public int AwayGoals { get; set; }

    public string? Message { get; set; }

    public string? Winner { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
