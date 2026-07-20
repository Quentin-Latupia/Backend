using System;
using System.Collections.Generic;

namespace Models;

public partial class v_Paiements_En_Attente
{
    public string MEM_nom { get; set; } = null!;

    public int RES_id { get; set; }

    public DateTime RES_heure_debut { get; set; }
}
