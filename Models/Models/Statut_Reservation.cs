using System;
using System.Collections.Generic;

namespace Models;

public partial class Statut_Reservation
{
    public int SR_id { get; set; }

    public string SR_code { get; set; } = null!;

    public string SR_libelle { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
