using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Stadium
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Place { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
