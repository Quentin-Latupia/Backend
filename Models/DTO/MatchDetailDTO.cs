using System;

namespace DTO
{
    public record MatchDetailDTO(
        int RES_id,
        DateTime RES_heure_debut,
        DateTime RES_heure_fin,
        int RES_reservataire,
        bool RES_prive,
        int RES_statut,
        string? RES_reservataire_nom,
        string? TER_nom,
        string? SIT_nom
    );
}
