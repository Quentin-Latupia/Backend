using System;
using System.Collections.Generic;

namespace Models;

public partial class v_Planning_Terrain
{
    public int RES_id { get; set; }

    public int RES_prive { get; set; }

    public int RES_statut { get; set; }

    public string TER_nom { get; set; } = null!;

    public string SIT_nom { get; set; } = null!;

    public DateTime RES_heure_debut { get; set; }

    public DateTime RES_heure_fin { get; set; }
}
