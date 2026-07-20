using System;
using System.Collections.Generic;

namespace Models;

public partial class Role_Participation
{
    public int RP_id { get; set; }

    public string RP_code { get; set; } = null!;

    public string RP_libelle { get; set; } = null!;

    public virtual ICollection<Participation_Reservation> Participation_Reservations { get; set; } = new List<Participation_Reservation>();
}
