using System;
using System.Collections.Generic;

namespace Models;

public partial class Type_Fermeture
{
    public int TF_id { get; set; }

    public string TF_code { get; set; } = null!;

    public string TF_libelle { get; set; } = null!;

    public virtual ICollection<Fermeture> Fermetures { get; set; } = new List<Fermeture>();
}
