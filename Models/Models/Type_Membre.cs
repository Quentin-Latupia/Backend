using System;
using System.Collections.Generic;

namespace Models;

public partial class Type_Membre
{
    public int TM_id { get; set; }

    public string TM_code { get; set; } = null!;

    public string TM_libelle { get; set; } = null!;

    public int TM_periode_reservable { get; set; }

    public virtual ICollection<Membre> Membres { get; set; } = new List<Membre>();
}
