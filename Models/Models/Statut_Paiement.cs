using System;
using System.Collections.Generic;

namespace Models;

public partial class Statut_Paiement
{
    public int SP_id { get; set; }

    public string SP_code { get; set; } = null!;

    public string SP_libelle { get; set; } = null!;

    public virtual ICollection<Participation_Reservation> Participation_Reservations { get; set; } = new List<Participation_Reservation>();
}
