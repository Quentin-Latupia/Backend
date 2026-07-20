using System;
using System.Collections.Generic;

namespace Models;

public partial class Terrain
{
    public int TER_id { get; set; }

    public int TER_site { get; set; }

    public string TER_nom { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual Site TER_siteNavigation { get; set; } = null!;
}
