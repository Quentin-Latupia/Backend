using System;
using System.Collections.Generic;

namespace Models;

public partial class Penalite
{
    public int PEN_id { get; set; }

    public int PEN_membre { get; set; }

    public int? PEN_reservation { get; set; }

    public DateOnly PEN_date_debut { get; set; }

    public DateOnly PEN_date_fin { get; set; }

    public string PEN_raison { get; set; } = null!;

    public virtual Membre PEN_membreNavigation { get; set; } = null!;

    public virtual Reservation? PEN_reservationNavigation { get; set; }
}
