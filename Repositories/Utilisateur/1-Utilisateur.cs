using AutoMapper;
using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Data;

namespace Utilisateurs
{
    public class Utilisateur : IUtilisateurRepo
    {
        public int id;
        public string nom;
        public string prenom;
        public string matricule;

        protected readonly AppDbContext? _context;

        public Utilisateur(AppDbContext context)
        {
            _context = context;
        }

        public List<planningDTO> planingTerrain(int idTerrain)
        {
            var result = new List<planningDTO>();
            
            if (_context == null)
                return result;

            var conn = _context.Database.GetDbConnection();
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "sp_general.sp_Planning_Terrain";
                cmd.CommandType = CommandType.StoredProcedure;

                var p = cmd.CreateParameter();
                p.ParameterName = "@idTerrain";
                p.Value = idTerrain;
                p.DbType = DbType.Int32;
                cmd.Parameters.Add(p);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var res_id = reader["RES_id"] != DBNull.Value ? Convert.ToInt32(reader["RES_id"]) : 0;
                    var sit_nom = reader["SIT_nom"] != DBNull.Value ? Convert.ToString(reader["SIT_nom"]) ?? string.Empty : string.Empty;
                    var ter_nom = reader["TER_nom"] != DBNull.Value ? Convert.ToString(reader["TER_nom"]) ?? string.Empty : string.Empty;
                    var heure_debut = reader["RES_heure_debut"] != DBNull.Value ? Convert.ToDateTime(reader["RES_heure_debut"]) : DateTime.MinValue;
                    var heure_fin = reader["RES_heure_fin"] != DBNull.Value ? Convert.ToDateTime(reader["RES_heure_fin"]) : DateTime.MinValue;
                    var prive = reader["RES_prive"] != DBNull.Value ? Convert.ToInt32(reader["RES_prive"]) : 0;
                    var statut = reader["RES_statut"] != DBNull.Value ? Convert.ToInt32(reader["RES_statut"]) : 0;

                    result.Add(new planningDTO(res_id, sit_nom, ter_nom, heure_debut, heure_fin, prive, statut));
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return result;
        }

        public bool VerifierAutorisationReservation(int membreId)
        {
            if (_context == null)
                return false;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "sp_general.sp_VerifierAutorisationReservation";
                cmd.CommandType = CommandType.StoredProcedure;

                var p = cmd.CreateParameter();
                p.ParameterName = "@MembreId";
                p.Value = membreId;
                p.DbType = DbType.Int32;
                cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool VerifierFermeture(int siteId, DateTime dateReservation)
        {
            if (_context == null)
                return false;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "sp_general.sp_VerifierFermeture";
                cmd.CommandType = CommandType.StoredProcedure;

                var p1 = cmd.CreateParameter();
                p1.ParameterName = "@SiteId";
                p1.Value = siteId;
                p1.DbType = DbType.Int32;
                cmd.Parameters.Add(p1);

                var p2 = cmd.CreateParameter();
                p2.ParameterName = "@DateReservation";
                p2.Value = dateReservation.Date;
                p2.DbType = DbType.Date;
                cmd.Parameters.Add(p2);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public void VerifierMatchPrive()
        {
            if (_context == null)
                return;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "sp_general.sp_VerifierMatchPrive";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // Fonctions table
        public List<TerrainDTO> GetTerrainsBySite(int siteId)
        {
            var result = new List<TerrainDTO>();
            if (_context == null)
                return result;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM sp_general.fn_GetTerrainsBySite(@SiteId)";
                cmd.CommandType = CommandType.Text;

                var p = cmd.CreateParameter();
                p.ParameterName = "@SiteId";
                p.Value = siteId;
                p.DbType = DbType.Int32;
                cmd.Parameters.Add(p);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["TER_id"] != DBNull.Value ? Convert.ToInt32(reader["TER_id"]) : 0;
                    var site = reader["TER_site"] != DBNull.Value ? Convert.ToInt32(reader["TER_site"]) : 0;
                    var nom = reader["TER_nom"] != DBNull.Value ? Convert.ToString(reader["TER_nom"]) ?? string.Empty : string.Empty;
                    result.Add(new TerrainDTO(id, site, nom));
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return result;
        }

        public List<MatchDetailDTO> MatchsDetailByTerrain(int terrainId)
        {
            var result = new List<MatchDetailDTO>();
            if (_context == null)
                return result;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM sp_general.fn_Matchs_Detail_ByTerrain(@TerrainId)";
                cmd.CommandType = CommandType.Text;

                var p = cmd.CreateParameter();
                p.ParameterName = "@TerrainId";
                p.Value = terrainId;
                p.DbType = DbType.Int32;
                cmd.Parameters.Add(p);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["RES_id"] != DBNull.Value ? Convert.ToInt32(reader["RES_id"]) : 0;
                    var hd = reader["RES_heure_debut"] != DBNull.Value ? Convert.ToDateTime(reader["RES_heure_debut"]) : DateTime.MinValue;
                    var hf = reader["RES_heure_fin"] != DBNull.Value ? Convert.ToDateTime(reader["RES_heure_fin"]) : DateTime.MinValue;
                    var reserv = reader["RES_reservataire"] != DBNull.Value ? Convert.ToInt32(reader["RES_reservataire"]) : 0;
                    var prive = reader["RES_prive"] != DBNull.Value ? Convert.ToBoolean(reader["RES_prive"]) : false;
                    var statut = reader["RES_statut"] != DBNull.Value ? Convert.ToInt32(reader["RES_statut"]) : 0;
                    string? reserv_nom = null;
                    string? ter_nom = null;
                    string? sit_nom = null;

                    bool HasColumn(System.Data.Common.DbDataReader r, string col)
                    {
                        try { return r.GetOrdinal(col) >= 0; } catch { return false; }
                    }

                    if (HasColumn(reader, "RES_reservataire_nom")) reserv_nom = Convert.ToString(reader["RES_reservataire_nom"]);
                    if (HasColumn(reader, "TER_nom")) ter_nom = Convert.ToString(reader["TER_nom"]);
                    if (HasColumn(reader, "SIT_nom")) sit_nom = Convert.ToString(reader["SIT_nom"]);

                    result.Add(new MatchDetailDTO(id, hd, hf, reserv, prive, statut, reserv_nom, ter_nom, sit_nom));
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return result;
        }

        public List<TerrainDTO> MatchsPublicsDisponiblesBySite(int siteId)
        {
            // suppose que la fonction retourne les mêmes colonnes que Terrain
            return GetTerrainsBySite(siteId);
        }

        public MembreSoldeDTO? GetMembreSolde(int membreId)
        {
            if (_context == null)
                return null;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM sp_general.fn_Membres_Solde_ByMembre(@MembreId)";
                cmd.CommandType = CommandType.Text;

                var p = cmd.CreateParameter();
                p.ParameterName = "@MembreId";
                p.Value = membreId;
                p.DbType = DbType.Int32;
                cmd.Parameters.Add(p);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var id = reader["MEM_id"] != DBNull.Value ? Convert.ToInt32(reader["MEM_id"]) : 0;
                    var solde = reader["MEM_solde"] != DBNull.Value ? Convert.ToDecimal(reader["MEM_solde"]) : 0m;
                    return new MembreSoldeDTO(id, solde);
                }

                return null;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public List<planningDTO> fn_Planning_Terrain(int terrainId)
        {
            // réutilise planingTerrain
            return planingTerrain(terrainId);
        }

        public List<SiteDTO> SitesDisponibles()
        {
            var result = new List<SiteDTO>();
            if (_context == null)
                return result;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM sp_general.fn_SitesDisponibles()";
                cmd.CommandType = CommandType.Text;

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["SIT_id"] != DBNull.Value ? Convert.ToInt32(reader["SIT_id"]) : 0;
                    var nom = reader["SIT_nom"] != DBNull.Value ? Convert.ToString(reader["SIT_nom"]) ?? string.Empty : string.Empty;
                    var adr = reader["SIT_adresse"] != DBNull.Value ? Convert.ToString(reader["SIT_adresse"]) ?? string.Empty : string.Empty;
                    result.Add(new SiteDTO(id, nom, adr));
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return result;
        }

        public void VerifierPaiementMatch()
        {
            if (_context == null)
                return;

            var conn = _context.Database.GetDbConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = "sp_general.sp_VerifierPaiementMatch";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


    }
}
