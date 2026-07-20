using System;
using System.Collections.Generic;

namespace Models;

public partial class Type_Reservation
{
    public int TR_id { get; set; }

    public int TR_duree { get; set; }

    public int TR_pause { get; set; }

    public int TR_periode_reservation { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual Periode_Reservation TR_periode_reservationNavigation { get; set; } = null!;
}
