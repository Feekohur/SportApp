using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string OfficialName { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string TeamCountryCode { get; set; } = null!;

    public int? StagePosition { get; set; }

    public virtual ICollection<Event> EventAwayTeams { get; set; } = new List<Event>();

    public virtual ICollection<Event> EventHomeTeams { get; set; } = new List<Event>();
}
