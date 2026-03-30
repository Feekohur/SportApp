using System;
using System.Collections.Generic;

namespace SportApp.Models;

public partial class Stage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Ordering { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
