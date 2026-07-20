using System;
using System.Collections.Generic;

namespace Models;

public partial class Participation_Reservation
{
    public int PAR_id { get; set; }

    public int PAR_reservation { get; set; }

    public int PAR_membre { get; set; }

    public int PAR_role { get; set; }

    public int PAR_statut_paiement { get; set; }

    public DateTime? PAR_date_paiement { get; set; }

    public decimal PAR_montant { get; set; }

    public virtual Membre PAR_membreNavigation { get; set; } = null!;

    public virtual Reservation PAR_reservationNavigation { get; set; } = null!;

    public virtual Role_Participation PAR_roleNavigation { get; set; } = null!;

    public virtual Statut_Paiement PAR_statut_paiementNavigation { get; set; } = null!;

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
