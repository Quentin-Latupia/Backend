USE [padel2025]
GO
/****** Object:  StoredProcedure [dbo].[SP_VerifierParticipantsJourPrecedent]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[SP_VerifierParticipantsJourPrecedent]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @dateHier DATE = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE);

    /*
        Hypothèse :
        - PAR_montant identique pour tous (DEFAULT = 15)
        - On récupère un montant de référence (MAX ou AVG)
    */
    DECLARE @montantParticipation DECIMAL(6,2);

    SELECT @montantParticipation = MAX(PAR_montant)
    FROM Participation_Reservation;

    ;WITH ParticipantsParReservation AS (
        SELECT 
            r.RES_id,
            r.RES_reservataire,
            COUNT(pr.PAR_id) AS nb_participants
        FROM Reservation r
        LEFT JOIN Participation_Reservation pr 
            ON pr.PAR_reservation = r.RES_id
        WHERE CAST(r.RES_heure_debut AS DATE) = @dateHier
        GROUP BY r.RES_id, r.RES_reservataire
    ),
    CalculManque AS (
        SELECT 
            RES_id,
            RES_reservataire,
            nb_participants,
            CASE 
                WHEN nb_participants < 4 THEN (4 - nb_participants)
                ELSE 0
            END AS nb_manquant
        FROM ParticipantsParReservation
    )

    -- Mise à jour du solde des organisateurs
    UPDATE m
    SET m.MEM_solde = m.MEM_solde + (c.nb_manquant * @montantParticipation)
    FROM Membre m
    INNER JOIN CalculManque c 
        ON m.MEM_id = c.RES_reservataire
    WHERE c.nb_manquant > 0;

END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_AjouterParticipant]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_AjouterParticipant]
    @ReservationId INT,
    @MembreId INT,
    @RoleId INT
AS
BEGIN
    INSERT INTO Participation_Reservation(PAR_reservation,PAR_membre,PAR_role,PAR_statut_paiement,PAR_date_paiement)
    VALUES (@ReservationId, @MembreId, @RoleId, 1, NULL);
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_AppliquerPenalite]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_AppliquerPenalite]
    @MembreId INT
AS
BEGIN
    INSERT INTO Penalite(PEN_membre,PEN_date_debut,PEN_date_fin,PEN_raison)
    VALUES (
        @MembreId,
        GETDATE(),
        DATEADD(DAY,7,GETDATE()),
        'Match non complété'
    );
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_CreerReservation]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_CreerReservation]
    @TerrainId INT,
    @DateHeureDebut DATETIME2,
    @ReservataireId INT,
    @Prive BIT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TypeMembre INT, @DelaiMax INT;

    -- récupération type + délai
    SELECT @TypeMembre = MEM_type
    FROM Membre
    WHERE MEM_id = @ReservataireId;

    SELECT @DelaiMax = TM_periode_reservable
    FROM Type_Membre
    WHERE TM_id = @TypeMembre;

    -- vérification délai
    IF DATEDIFF(DAY, GETDATE(), @DateHeureDebut) > @DelaiMax
    BEGIN
        RAISERROR('Délai de réservation dépassé', 16, 1);
        RETURN;
    END;

    -- Vérifier conflit réservation
    IF EXISTS (
        SELECT 1 FROM Reservation
        WHERE RES_terrain = @TerrainId
        AND @DateHeureDebut < RES_heure_fin
        AND DATEADD(MINUTE, 90, @DateHeureDebut) > RES_heure_debut
    )
    BEGIN
        RAISERROR('Terrain déjà réservé',16,1);
        RETURN;
    END;

    -- Création (durée 1h30)
    INSERT INTO Reservation(RES_terrain,RES_heure_debut,RES_heure_fin,RES_type_reservation,RES_reservataire,RES_prive,RES_statut)
    VALUES (@TerrainId, @DateHeureDebut,
            DATEADD(MINUTE,90,@DateHeureDebut),
            1, @ReservataireId, @Prive, 1);
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_GestionReservationsJPlus1]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_GestionReservationsJPlus1]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DateDemain DATE = CAST(DATEADD(DAY, 1, GETDATE()) AS DATE);

    DECLARE @ResId INT;
    DECLARE @Organisateur INT;
    DECLARE @NbTotal INT;
    DECLARE @NbPayes INT;
    DECLARE @IsPrive BIT;

    DECLARE curseur_res CURSOR FOR
    SELECT 
        r.RES_id,
        r.RES_reservataire,
        r.RES_prive
    FROM Reservation r
    WHERE CAST(r.RES_heure_debut AS DATE) = @DateDemain;

    OPEN curseur_res;

    FETCH NEXT FROM curseur_res INTO @ResId, @Organisateur, @IsPrive;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        /*
            Étape 1 : vérification nombre de participant
        */
        SELECT @NbTotal = COUNT(*)
        FROM Participation_Reservation
        WHERE PAR_reservation = @ResId;

        SELECT @NbPayes = COUNT(*)
        FROM Participation_Reservation
        WHERE PAR_reservation = @ResId
        AND PAR_date_paiement IS NOT NULL;

        /*
           Étape 2 : pénalité si match privé && NbTotal < 4
        */
        IF @IsPrive = 1 AND @NbTotal < 4  
        BEGIN
            EXEC [sp_general].[sp_AppliquerPenalite] @Organisateur;
        END

        /*
            suppression des impayés
        */
        DELETE FROM Participation_Reservation
        WHERE PAR_reservation = @ResId
        AND PAR_date_paiement IS NULL;

        /*
            recalcul suppression des impayés
        */
        SELECT @NbPayes = COUNT(*)
        FROM Participation_Reservation
        WHERE PAR_reservation = @ResId;

        /*
            privé → public si incomplet
        */
        IF @IsPrive = 1 AND @NbPayes < 4
        BEGIN
            UPDATE Reservation
            SET RES_prive = 0
            WHERE RES_id = @ResId;
        END

        FETCH NEXT FROM curseur_res INTO @ResId, @Organisateur, @IsPrive;
    END;

    CLOSE curseur_res;
    DEALLOCATE curseur_res;
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_ListerMatchsPublics]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_ListerMatchsPublics]
AS
BEGIN
    SELECT *
    FROM Reservation r
    WHERE RES_prive = 0
    AND (
        SELECT COUNT(*) 
        FROM Participation_Reservation p
        WHERE p.PAR_reservation = r.RES_id
    ) < 4;
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_PayerParticipation]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_PayerParticipation]
    @ParticipationId INT,
    @Montant DECIMAL(6,2)
AS
BEGIN
    INSERT INTO Paiement
    VALUES (@ParticipationId, @Montant, GETDATE());

    UPDATE Participation_Reservation
    SET PAR_statut_paiement = 2,
        PAR_date_paiement = GETDATE()
    WHERE PAR_id = @ParticipationId;
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_Planning_Terrain]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [sp_general].[sp_Planning_Terrain]
AS
BEGIN
    SET NOCOUNT ON;

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
    JOIN Site s ON t.TER_site = s.SIT_id;

END
GO
/****** Object:  StoredProcedure [sp_general].[sp_VerifierAutorisationReservation]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_VerifierAutorisationReservation]
    @MembreId INT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Membre
        WHERE MEM_id = @MembreId
        AND MEM_solde > 0
    )
    BEGIN
        RAISERROR('Solde impayé - réservation impossible',16,1);
    END;
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_VerifierFermeture]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_VerifierFermeture]
    @SiteId INT,
    @DateReservation DATE
AS
BEGIN
    IF EXISTS(
        SELECT 1 FROM Fermeture
        WHERE FER_date = @DateReservation
        AND (FER_site = @SiteId OR FER_site IS NULL)
    )
    BEGIN
        RAISERROR('Site fermé à cette date',16,1);
    END;
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_VerifierMatchPrive]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_VerifierMatchPrive]
AS
BEGIN
    UPDATE Reservation
    SET RES_prive = 0
    WHERE RES_prive = 1
    AND DATEDIFF(DAY, GETDATE(), RES_heure_debut) = 1
    AND (
        SELECT COUNT(*) 
        FROM Participation_Reservation 
        WHERE PAR_reservation = RES_id
    ) < 4;
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_VerifierPaiementMatch]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_VerifierPaiementMatch]
AS
BEGIN
    UPDATE Reservation
    SET RES_prive = 0
    WHERE EXISTS (
        SELECT 1
        FROM Participation_Reservation
        WHERE PAR_reservation = RES_id
        AND PAR_statut_paiement != 2
    )
    AND DATEDIFF(DAY, GETDATE(), RES_heure_debut) <= 1;
END;
GO
/****** Object:  StoredProcedure [sp_general].[sp_VerifierSoldeOrganisateur]    Script Date: 15/06/2026 10:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [sp_general].[sp_VerifierSoldeOrganisateur]
    @ReservationId INT
AS
BEGIN
    DECLARE @NbJoueurs INT;

    SELECT @NbJoueurs = COUNT(*)
    FROM Participation_Reservation
    WHERE PAR_reservation = @ReservationId;

    IF @NbJoueurs < 4
    BEGIN
        DECLARE @Manque INT = 4 - @NbJoueurs;

        UPDATE Membre
        SET MEM_solde = MEM_solde + (@Manque * 15)
        WHERE MEM_id = (
            SELECT RES_reservataire FROM Reservation WHERE RES_id = @ReservationId
        );
    END
END;
GO
