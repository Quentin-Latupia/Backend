using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fermeture> Fermetures { get; set; }

    public virtual DbSet<Membre> Membres { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Participation_Reservation> Participation_Reservations { get; set; }

    public virtual DbSet<Penalite> Penalites { get; set; }

    public virtual DbSet<Periode_Reservation> Periode_Reservations { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role_Participation> Role_Participations { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Statut_Paiement> Statut_Paiements { get; set; }

    public virtual DbSet<Statut_Reservation> Statut_Reservations { get; set; }

    public virtual DbSet<Terrain> Terrains { get; set; }

    public virtual DbSet<Type_Fermeture> Type_Fermetures { get; set; }

    public virtual DbSet<Type_Membre> Type_Membres { get; set; }

    public virtual DbSet<Type_Reservation> Type_Reservations { get; set; }

    public virtual DbSet<v_Matchs_Detail> v_Matchs_Details { get; set; }

    public virtual DbSet<v_Matchs_Publics_Disponible> v_Matchs_Publics_Disponibles { get; set; }

    public virtual DbSet<v_Membres_Solde> v_Membres_Soldes { get; set; }

    public virtual DbSet<v_Paiements_En_Attente> v_Paiements_En_Attentes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fermeture>(entity =>
        {
            entity.HasKey(e => e.FER_id).HasName("PK__Fermetur__4D246E8FC28F1693");

            entity.ToTable("Fermeture");

            entity.HasOne(d => d.FER_siteNavigation).WithMany(p => p.Fermetures)
                .HasForeignKey(d => d.FER_site)
                .HasConstraintName("FK__Fermeture__FER_s__4E88ABD4");

            entity.HasOne(d => d.FER_typeNavigation).WithMany(p => p.Fermetures)
                .HasForeignKey(d => d.FER_type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fermeture__FER_t__4D94879B");
        });

        modelBuilder.Entity<Membre>(entity =>
        {
            entity.HasKey(e => e.MEM_id).HasName("PK__Membre__1B325434D3D0C39D");

            entity.ToTable("Membre");

            entity.HasIndex(e => e.MEM_matricule, "UQ__Membre__EF4455EC6D409A7C").IsUnique();

            entity.Property(e => e.MEM_matricule)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MEM_nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MEM_prenom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MEM_solde).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.MEM_siteNavigation).WithMany(p => p.Membres)
                .HasForeignKey(d => d.MEM_site)
                .HasConstraintName("FK__Membre__MEM_site__5812160E");

            entity.HasOne(d => d.MEM_typeNavigation).WithMany(p => p.Membres)
                .HasForeignKey(d => d.MEM_type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Membre__MEM_type__571DF1D5");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.PAY_id).HasName("PK__Paiement__8C7E5CD07773A86B");

            entity.ToTable("Paiement");

            entity.Property(e => e.PAY_montant).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.PAY_participationNavigation).WithMany(p => p.Paiements)
                .HasForeignKey(d => d.PAY_participation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paiement__PAY_pa__68487DD7");
        });

        modelBuilder.Entity<Participation_Reservation>(entity =>
        {
            entity.HasKey(e => e.PAR_id).HasName("PK__Particip__98A20B2F4542E412");

            entity.ToTable("Participation_Reservation");

            entity.Property(e => e.PAR_montant)
                .HasDefaultValue(15m)
                .HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.PAR_membreNavigation).WithMany(p => p.Participation_Reservations)
                .HasForeignKey(d => d.PAR_membre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__PAR_m__6383C8BA");

            entity.HasOne(d => d.PAR_reservationNavigation).WithMany(p => p.Participation_Reservations)
                .HasForeignKey(d => d.PAR_reservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__PAR_r__628FA481");

            entity.HasOne(d => d.PAR_roleNavigation).WithMany(p => p.Participation_Reservations)
                .HasForeignKey(d => d.PAR_role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__PAR_r__6477ECF3");

            entity.HasOne(d => d.PAR_statut_paiementNavigation).WithMany(p => p.Participation_Reservations)
                .HasForeignKey(d => d.PAR_statut_paiement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__PAR_s__656C112C");
        });

        modelBuilder.Entity<Penalite>(entity =>
        {
            entity.HasKey(e => e.PEN_id).HasName("PK__Penalite__67EB53AE31081608");

            entity.ToTable("Penalite");

            entity.Property(e => e.PEN_raison)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.PEN_membreNavigation).WithMany(p => p.Penalites)
                .HasForeignKey(d => d.PEN_membre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Penalite__PEN_me__6B24EA82");

            entity.HasOne(d => d.PEN_reservationNavigation).WithMany(p => p.Penalites)
                .HasForeignKey(d => d.PEN_reservation)
                .HasConstraintName("FK__Penalite__PEN_re__6C190EBB");
        });

        modelBuilder.Entity<Periode_Reservation>(entity =>
        {
            entity.HasKey(e => e.PR_id).HasName("PK__Periode___7FD2767D0D83D783");

            entity.ToTable("Periode_Reservation");

            entity.HasOne(d => d.PR_siteNavigation).WithMany(p => p.Periode_Reservations)
                .HasForeignKey(d => d.PR_site)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Periode_R__PR_si__4AB81AF0");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.RES_id).HasName("PK__Reservat__3D211BABA95861CE");

            entity.ToTable("Reservation");

            entity.Property(e => e.RES_nb_max).HasDefaultValue(4);

            entity.HasOne(d => d.RES_reservataireNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RES_reservataire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__RES_r__5DCAEF64");

            entity.HasOne(d => d.RES_statutNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RES_statut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__RES_s__5EBF139D");

            entity.HasOne(d => d.RES_terrainNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RES_terrain)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__RES_t__5BE2A6F2");

            entity.HasOne(d => d.RES_type_reservationNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RES_type_reservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__RES_t__5CD6CB2B");
        });

        modelBuilder.Entity<Role_Participation>(entity =>
        {
            entity.HasKey(e => e.RP_id).HasName("PK__Role_Par__85098BC9F3D8E684");

            entity.ToTable("Role_Participation");

            entity.HasIndex(e => e.RP_code, "UQ__Role_Par__11BCA33ABDF1416D").IsUnique();

            entity.Property(e => e.RP_code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RP_libelle)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.SIT_id).HasName("PK__Site__9B1A77876DE2E171");

            entity.ToTable("Site");

            entity.Property(e => e.SIT_adresse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SIT_nom)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Statut_Paiement>(entity =>
        {
            entity.HasKey(e => e.SP_id).HasName("PK__Statut_P__AA29CE3BBB487D7D");

            entity.ToTable("Statut_Paiement");

            entity.HasIndex(e => e.SP_code, "UQ__Statut_P__76E8B66B6368E815").IsUnique();

            entity.Property(e => e.SP_code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SP_libelle)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Statut_Reservation>(entity =>
        {
            entity.HasKey(e => e.SR_id).HasName("PK__Statut_R__1D8A1CE941E17B12");

            entity.ToTable("Statut_Reservation");

            entity.HasIndex(e => e.SR_code, "UQ__Statut_R__958906C2154CC4BE").IsUnique();

            entity.Property(e => e.SR_code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SR_libelle)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Terrain>(entity =>
        {
            entity.HasKey(e => e.TER_id).HasName("PK__Terrain__0137966A4D4015D6");

            entity.ToTable("Terrain");

            entity.Property(e => e.TER_nom)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TER_siteNavigation).WithMany(p => p.Terrains)
                .HasForeignKey(d => d.TER_site)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Terrain__TER_sit__47DBAE45");
        });

        modelBuilder.Entity<Type_Fermeture>(entity =>
        {
            entity.HasKey(e => e.TF_id).HasName("PK__Type_Fer__B2BE5D6D2BAC21C2");

            entity.ToTable("Type_Fermeture");

            entity.HasIndex(e => e.TF_code, "UQ__Type_Fer__B7F7C8B542C91BB9").IsUnique();

            entity.Property(e => e.TF_code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TF_libelle)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Type_Membre>(entity =>
        {
            entity.HasKey(e => e.TM_id).HasName("PK__Type_Mem__974CA1F84B0A459E");

            entity.ToTable("Type_Membre");

            entity.HasIndex(e => e.TM_code, "UQ__Type_Mem__86AB25446B595D77").IsUnique();

            entity.Property(e => e.TM_code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TM_libelle)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Type_Reservation>(entity =>
        {
            entity.HasKey(e => e.TR_id).HasName("PK__Type_Res__98993C497283BA92");

            entity.ToTable("Type_Reservation");

            entity.HasOne(d => d.TR_periode_reservationNavigation).WithMany(p => p.Type_Reservations)
                .HasForeignKey(d => d.TR_periode_reservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Type_Rese__TR_pe__5165187F");
        });

        modelBuilder.Entity<v_Matchs_Detail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Matchs_Detail", "sp_general");

            entity.Property(e => e.Organisateur)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SIT_nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TER_nom)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<v_Matchs_Publics_Disponible>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Matchs_Publics_Disponibles", "sp_general");

            entity.Property(e => e.SIT_nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TER_nom)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<v_Membres_Solde>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Membres_Solde", "sp_general");

            entity.Property(e => e.MEM_matricule)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MEM_nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MEM_prenom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MEM_solde).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<v_Paiements_En_Attente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Paiements_En_Attente", "sp_general");

            entity.Property(e => e.MEM_nom)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
