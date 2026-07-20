using System;
using System.Collections.Generic;

namespace Models;

public partial class Periode_Reservation
{
    public int PR_id { get; set; }

    public TimeOnly PR_heure_ouverture { get; set; }

    public TimeOnly PR_heure_fermeture { get; set; }

    public int PR_annee { get; set; }

    public int PR_site { get; set; }

    public virtual Site PR_siteNavigation { get; set; } = null!;

    public virtual ICollection<Type_Reservation> Type_Reservations { get; set; } = new List<Type_Reservation>();
}
