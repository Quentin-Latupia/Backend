using System;
using System.Collections.Generic;

namespace Models;

public partial class Fermeture
{
    public int FER_id { get; set; }

    public DateOnly FER_date { get; set; }

    public int FER_type { get; set; }

    public int? FER_site { get; set; }

    public virtual Site? FER_siteNavigation { get; set; }

    public virtual Type_Fermeture FER_typeNavigation { get; set; } = null!;
}
