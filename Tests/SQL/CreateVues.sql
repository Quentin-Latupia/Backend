USE [padel2025]
GO
/****** Object:  View [sp_general].[v_Matchs_Detail]    Script Date: 11/06/2026 21:47:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [sp_general].[v_Matchs_Detail]
AS
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
LEFT JOIN Participation_Reservation p ON p.PAR_reservation = r.RES_id
GROUP BY r.RES_id, s.SIT_nom, t.TER_nom, r.RES_heure_debut, m.MEM_nom;
GO
/****** Object:  View [sp_general].[v_Matchs_Publics_Disponibles]    Script Date: 11/06/2026 21:47:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [sp_general].[v_Matchs_Publics_Disponibles]
AS
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
LEFT JOIN Participation_Reservation p ON p.PAR_reservation = r.RES_id
WHERE r.RES_prive = 0
GROUP BY r.RES_id, r.RES_heure_debut, r.RES_heure_fin, s.SIT_nom, t.TER_nom
HAVING COUNT(p.PAR_id) < 4;
GO
/****** Object:  View [sp_general].[v_Membres_Solde]    Script Date: 11/06/2026 21:47:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [sp_general].[v_Membres_Solde]
AS
SELECT 
    MEM_nom,
    MEM_prenom,
    MEM_matricule,
    MEM_solde
FROM Membre
WHERE MEM_solde > 0;
GO
/****** Object:  View [sp_general].[v_Paiements_En_Attente]    Script Date: 11/06/2026 21:47:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [sp_general].[v_Paiements_En_Attente]
AS
SELECT 
    m.MEM_nom,
    r.RES_id,
    r.RES_heure_debut
FROM Participation_Reservation p
JOIN Membre m ON p.PAR_membre = m.MEM_id
JOIN Reservation r ON p.PAR_reservation = r.RES_id
WHERE p.PAR_statut_paiement = 1;
GO
