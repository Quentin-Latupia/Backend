USE [padel2025]
GO
/****** Object:  UserDefinedFunction [sp_general].[fn_GetTerrainsBySite]    Script Date: 11/06/2026 21:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER FUNCTION [sp_general].[fn_GetTerrainsBySite]
(
    @idSite INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        TER_id,
        TER_nom
    FROM Terrain
    WHERE TER_site = @idSite
);
GO
/****** Object:  UserDefinedFunction [sp_general].[fn_Matchs_Detail_ByTerrain]    Script Date: 11/06/2026 21:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER FUNCTION [sp_general].[fn_Matchs_Detail_ByTerrain]
(
    @IdMatch INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        r.RES_id,
        s.SIT_nom,
        t.TER_nom,
        r.RES_heure_debut,
        m.MEM_nom AS Organisateur,
        COUNT(p.PAR_id) AS Nb_Joueurs
    FROM Reservation r
    JOIN Terrain t ON r.RES_terrain = t.TER_id
    JOIN Site s ON t.TER_site = s.SIT_id
    JOIN Membre m ON r.RES_reservataire = m.MEM_id
    LEFT JOIN Participation_Reservation p 
        ON p.PAR_reservation = r.RES_id
    WHERE r.RES_id = @IdMatch
    GROUP BY 
        r.RES_id, 
        s.SIT_nom, 
        t.TER_nom, 
        r.RES_heure_debut, 
        m.MEM_nom
);
GO
/****** Object:  UserDefinedFunction [sp_general].[fn_Matchs_Publics_Disponibles_BySite]    Script Date: 11/06/2026 21:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER FUNCTION [sp_general].[fn_Matchs_Publics_Disponibles_BySite]
(
    @IdSite INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        r.RES_id,
        r.RES_heure_debut,
        r.RES_heure_fin,
        s.SIT_nom,
        t.TER_nom,
        COUNT(p.PAR_id) AS Nb_Joueurs
    FROM Reservation r
    JOIN Terrain t ON r.RES_terrain = t.TER_id
    JOIN Site s ON t.TER_site = s.SIT_id
    LEFT JOIN Participation_Reservation p 
        ON p.PAR_reservation = r.RES_id
    WHERE 
        r.RES_prive = 0
        AND s.SIT_id = @IdSite
    GROUP BY 
        r.RES_id, 
        r.RES_heure_debut, 
        r.RES_heure_fin, 
        s.SIT_nom, 
        t.TER_nom
    HAVING COUNT(p.PAR_id) < 4
);
GO
/****** Object:  UserDefinedFunction [sp_general].[fn_Membres_Solde_ByMembre]    Script Date: 11/06/2026 21:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER FUNCTION [sp_general].[fn_Membres_Solde_ByMembre]
(
    @IdMembre INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        MEM_nom,
        MEM_prenom,
        MEM_matricule,
        MEM_solde
    FROM Membre
    WHERE 
        MEM_solde > 0
        AND MEM_id = @IdMembre
);
GO
/****** Object:  UserDefinedFunction [sp_general].[fn_Planning_Terrain]    Script Date: 11/06/2026 21:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION [sp_general].[fn_Planning_Terrain]
(
    @idTerrain INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        s.SIT_nom,
		s.SIT_id,
        t.TER_nom,
        r.RES_heure_debut,
        r.RES_heure_fin,		
        r.RES_prive,
        r.RES_statut
    FROM Reservation r
    JOIN Terrain t ON r.RES_terrain = t.TER_id
    JOIN Site s ON t.TER_site = s.SIT_id
    WHERE t.TER_id = @idTerrain
);
GO
/****** Object:  UserDefinedFunction [sp_general].[fn_SitesDisponibles]    Script Date: 11/06/2026 21:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER FUNCTION [sp_general].[fn_SitesDisponibles] (@dateRecherche DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        s.SIT_id,
        s.SIT_nom,
        s.SIT_adresse
    FROM dbo.Site s
    WHERE NOT EXISTS (
        SELECT 1
        FROM dbo.Fermeture f
        WHERE f.FER_date = @dateRecherche
        AND  f.FER_site = s.SIT_id        
    )
);
GO
