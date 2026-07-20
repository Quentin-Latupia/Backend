using System;
using System.Collections.Generic;

namespace Models;

public partial class Membre
{
    public int MEM_id { get; set; }

    public string MEM_nom { get; set; } = null!;

    public string MEM_prenom { get; set; } = null!;

    public string MEM_matricule { get; set; } = null!;

    public decimal MEM_solde { get; set; }

    public int MEM_type { get; set; }

    public int? MEM_site { get; set; }

    public bool MEM_is_admin { get; set; }

    public virtual Site? MEM_siteNavigation { get; set; }

    public virtual Type_Membre MEM_typeNavigation { get; set; } = null!;

    public virtual ICollection<Participation_Reservation> Participation_Reservations { get; set; } = new List<Participation_Reservation>();

    public virtual ICollection<Penalite> Penalites { get; set; } = new List<Penalite>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
