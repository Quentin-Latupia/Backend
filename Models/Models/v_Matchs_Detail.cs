using System;
using System.Collections.Generic;

namespace Models;

public partial class v_Matchs_Detail
{
    public int RES_id { get; set; }

    public string SIT_nom { get; set; } = null!;

    public string TER_nom { get; set; } = null!;

    public DateTime RES_heure_debut { get; set; }

    public string Organisateur { get; set; } = null!;

    public int? Nb_Joueurs { get; set; }
}
