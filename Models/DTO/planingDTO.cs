using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public record planningDTO(int RES_id, string SIT_nom, string TER_nom, DateTime RES_heure_debut, DateTime RES_heure_fin, int RES_prive, int RES_statut);
}
