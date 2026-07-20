using System;
using System.Collections.Generic;

namespace Models;

public partial class v_Membres_Solde
{
    public string MEM_nom { get; set; } = null!;

    public string MEM_prenom { get; set; } = null!;

    public string MEM_matricule { get; set; } = null!;

    public decimal MEM_solde { get; set; }
}
