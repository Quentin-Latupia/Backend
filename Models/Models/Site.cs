using System;
using System.Collections.Generic;

namespace Models;

public partial class Site
{
    public int SIT_id { get; set; }

    public string SIT_nom { get; set; } = null!;

    public string SIT_adresse { get; set; } = null!;

    public virtual ICollection<Fermeture> Fermetures { get; set; } = new List<Fermeture>();

    public virtual ICollection<Membre> Membres { get; set; } = new List<Membre>();

    public virtual ICollection<Periode_Reservation> Periode_Reservations { get; set; } = new List<Periode_Reservation>();

    public virtual ICollection<Terrain> Terrains { get; set; } = new List<Terrain>();
}
