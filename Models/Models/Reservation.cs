using System;
using System.Collections.Generic;

namespace Models;

public partial class Reservation
{
    public int RES_id { get; set; }

    public int RES_terrain { get; set; }

    public DateTime RES_heure_debut { get; set; }

    public DateTime RES_heure_fin { get; set; }

    public int RES_type_reservation { get; set; }

    public int RES_reservataire { get; set; }

    public bool RES_prive { get; set; }

    public int RES_statut { get; set; }

    public int RES_nb_max { get; set; }

    public virtual ICollection<Participation_Reservation> Participation_Reservations { get; set; } = new List<Participation_Reservation>();

    public virtual ICollection<Penalite> Penalites { get; set; } = new List<Penalite>();

    public virtual Membre RES_reservataireNavigation { get; set; } = null!;

    public virtual Statut_Reservation RES_statutNavigation { get; set; } = null!;

    public virtual Terrain RES_terrainNavigation { get; set; } = null!;

    public virtual Type_Reservation RES_type_reservationNavigation { get; set; } = null!;
}
