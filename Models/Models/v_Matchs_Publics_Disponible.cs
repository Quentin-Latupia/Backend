using System;
using System.Collections.Generic;

namespace Models;

public partial class v_Matchs_Publics_Disponible
{
    public int RES_id { get; set; }

    public DateTime RES_heure_debut { get; set; }

    public DateTime RES_heure_fin { get; set; }

    public string SIT_nom { get; set; } = null!;

    public string TER_nom { get; set; } = null!;

    public int? Nb_Joueurs { get; set; }
}
