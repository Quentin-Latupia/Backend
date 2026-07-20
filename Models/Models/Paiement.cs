using System;
using System.Collections.Generic;

namespace Models;

public partial class Paiement
{
    public int PAY_id { get; set; }

    public int PAY_participation { get; set; }

    public decimal PAY_montant { get; set; }

    public DateTime PAY_date { get; set; }

    public virtual Participation_Reservation PAY_participationNavigation { get; set; } = null!;
}
