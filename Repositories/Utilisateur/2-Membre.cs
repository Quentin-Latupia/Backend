using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Utilisateurs
{
    //public class membre : Utilisateur
    //{
    //    public float solde;

    //    public membre(AppDbContext context) : base(context)
    //    {
    //    }

    //    public void AjouterParticipant(int reservationId, int membreId, int roleId)
    //    {
    //        if (_context == null)
    //            return;

    //        var conn = _context.Database.GetDbConnection();
    //        try
    //        {
    //            if (conn.State == ConnectionState.Closed)
    //                conn.Open();

    //            using var cmd = conn.CreateCommand();
    //            cmd.CommandText = "sp_general.sp_AjouterParticipant";
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            var p1 = cmd.CreateParameter();
    //            p1.ParameterName = "@ReservationId";
    //            p1.Value = reservationId;
    //            p1.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p1);

    //            var p2 = cmd.CreateParameter();
    //            p2.ParameterName = "@MembreId";
    //            p2.Value = membreId;
    //            p2.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p2);

    //            var p3 = cmd.CreateParameter();
    //            p3.ParameterName = "@RoleId";
    //            p3.Value = roleId;
    //            p3.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p3);

    //            cmd.ExecuteNonQuery();
    //        }
    //        finally
    //        {
    //            if (conn.State == ConnectionState.Open)
    //                conn.Close();
    //        }
    //    }

    //    public bool CreerReservation(int terrainId, DateTime dateHeureDebut, int reservataireId, bool prive)
    //    {
    //        if (_context == null)
    //            return false;

    //        var conn = _context.Database.GetDbConnection();
    //        try
    //        {
    //            if (conn.State == ConnectionState.Closed)
    //                conn.Open();

    //            using var cmd = conn.CreateCommand();
    //            cmd.CommandText = "sp_general.sp_CreerReservation";
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            var p1 = cmd.CreateParameter();
    //            p1.ParameterName = "@TerrainId";
    //            p1.Value = terrainId;
    //            p1.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p1);

    //            var p2 = cmd.CreateParameter();
    //            p2.ParameterName = "@DateHeureDebut";
    //            p2.Value = dateHeureDebut;
    //            p2.DbType = DbType.DateTime2;
    //            cmd.Parameters.Add(p2);

    //            var p3 = cmd.CreateParameter();
    //            p3.ParameterName = "@ReservataireId";
    //            p3.Value = reservataireId;
    //            p3.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p3);

    //            var p4 = cmd.CreateParameter();
    //            p4.ParameterName = "@Prive";
    //            p4.Value = prive;
    //            p4.DbType = DbType.Boolean;
    //            cmd.Parameters.Add(p4);

    //            cmd.ExecuteNonQuery();
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //        finally
    //        {
    //            if (conn.State == ConnectionState.Open)
    //                conn.Close();
    //        }
    //    }

    //    public bool PayerParticipation(int participationId, decimal montant)
    //    {
    //        if (_context == null)
    //            return false;

    //        var conn = _context.Database.GetDbConnection();
    //        try
    //        {
    //            if (conn.State == ConnectionState.Closed)
    //                conn.Open();

    //            using var cmd = conn.CreateCommand();
    //            cmd.CommandText = "sp_general.sp_PayerParticipation";
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            var p1 = cmd.CreateParameter();
    //            p1.ParameterName = "@ParticipationId";
    //            p1.Value = participationId;
    //            p1.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p1);

    //            var p2 = cmd.CreateParameter();
    //            p2.ParameterName = "@Montant";
    //            p2.Value = montant;
    //            p2.DbType = DbType.Decimal;
    //            cmd.Parameters.Add(p2);

    //            cmd.ExecuteNonQuery();
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //        finally
    //        {
    //            if (conn.State == ConnectionState.Open)
    //                conn.Close();
    //        }
    //    }
    //    // Permet aux membres de voir les matchs publics disponibles pour rejoindre ou participer
    //    public List<Reservation> ListerMatchsPublics()
    //    {
    //        var result = new List<Reservation>();
    //        if (_context == null)
    //            return result;

    //        var conn = _context.Database.GetDbConnection();
    //        try
    //        {
    //            if (conn.State == ConnectionState.Closed)
    //                conn.Open();

    //            using var cmd = conn.CreateCommand();
    //            cmd.CommandText = "sp_general.sp_ListerMatchsPublics";
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            using var reader = cmd.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                var r = new Reservation
    //                {
    //                    RES_id = reader["RES_id"] != DBNull.Value ? Convert.ToInt32(reader["RES_id"]) : 0,
    //                    RES_terrain = reader["RES_terrain"] != DBNull.Value ? Convert.ToInt32(reader["RES_terrain"]) : 0,
    //                    RES_heure_debut = reader["RES_heure_debut"] != DBNull.Value ? Convert.ToDateTime(reader["RES_heure_debut"]) : DateTime.MinValue,
    //                    RES_heure_fin = reader["RES_heure_fin"] != DBNull.Value ? Convert.ToDateTime(reader["RES_heure_fin"]) : DateTime.MinValue,
    //                    RES_type_reservation = reader["RES_type_reservation"] != DBNull.Value ? Convert.ToInt32(reader["RES_type_reservation"]) : 0,
    //                    RES_reservataire = reader["RES_reservataire"] != DBNull.Value ? Convert.ToInt32(reader["RES_reservataire"]) : 0,
    //                    RES_prive = reader["RES_prive"] != DBNull.Value ? Convert.ToBoolean(reader["RES_prive"]) : false,
    //                    RES_statut = reader["RES_statut"] != DBNull.Value ? Convert.ToInt32(reader["RES_statut"]) : 0,
    //                    RES_nb_max = reader["RES_nb_max"] != DBNull.Value ? Convert.ToInt32(reader["RES_nb_max"]) : 0
    //                };

    //                result.Add(r);
    //            }
    //        }
    //        finally
    //        {
    //            if (conn.State == ConnectionState.Open)
    //                conn.Close();
    //        }

    //        return result;
    //    }

    //    //doit se déclencher après chaque ajout de participant ou
    //    //paiement pour vérifier si l'organisateur a suffisamment de solde pour couvrir les frais de réservation
    //    public void VerifierSoldeOrganisateur(int reservationId)
    //    {
    //        if (_context == null)
    //            return;

    //        var conn = _context.Database.GetDbConnection();
    //        try
    //        {
    //            if (conn.State == ConnectionState.Closed)
    //                conn.Open();

    //            using var cmd = conn.CreateCommand();
    //            cmd.CommandText = "sp_general.sp_VerifierSoldeOrganisateur";
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            var p = cmd.CreateParameter();
    //            p.ParameterName = "@ReservationId";
    //            p.Value = reservationId;
    //            p.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p);

    //            cmd.ExecuteNonQuery();
    //        }
    //        finally
    //        {
    //            if (conn.State == ConnectionState.Open)
    //                conn.Close();
    //        }
    //    }
    //    // Applique une pénalité à un membre qui a causé une annulation de réservation ou un no-show
    //    public bool AppliquerPenalite(int membreId)
    //    {
    //        if (_context == null)
    //            return false;

    //        var conn = _context.Database.GetDbConnection();
    //        try
    //        {
    //            if (conn.State == ConnectionState.Closed)
    //                conn.Open();

    //            using var cmd = conn.CreateCommand();
    //            cmd.CommandText = "sp_general.sp_AppliquerPenalite";
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            var p = cmd.CreateParameter();
    //            p.ParameterName = "@MembreId";
    //            p.Value = membreId;
    //            p.DbType = DbType.Int32;
    //            cmd.Parameters.Add(p);

    //            cmd.ExecuteNonQuery();
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //        finally
    //        {
    //            if (conn.State == ConnectionState.Open)
    //                conn.Close();
    //        }
    //    }
    //}
}
