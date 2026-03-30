using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Sport { get; set; } = null!;

    public string Status { get; set; } = null!;

    public TimeOnly TimevenueUtc { get; set; }

    public DateOnly Datevenue { get; set; }

    public int Season { get; set; }

    public int? HomeTeamId { get; set; }

    public int? AwayTeamId { get; set; }

    public int StageId { get; set; }

    public int CompetitionId { get; set; }

    public int? StadiumId { get; set; }

    public int? ResultId { get; set; }

    public virtual Team? AwayTeam { get; set; }

    public virtual Competition Competition { get; set; } = null!;

    public virtual Team? HomeTeam { get; set; }

    public virtual Result? Result { get; set; }

    public virtual Stadium? Stadium { get; set; }

    public virtual Stage Stage { get; set; } = null!;
}
