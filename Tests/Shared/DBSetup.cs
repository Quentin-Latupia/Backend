using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace Shared
{
    public class DBSetup : BaseRepo, IAsyncDisposable
    {
        private readonly string _connectionStringMaster;
        public string connectionStringDB;
        private string _dbNameCreated = string.Empty;

        public DBSetup(string connectionstring)
        {
            _connectionStringMaster = connectionstring;
        }

        public async Task CreateLogin()
        {
            await RunScript("CreateLogin.sql");
        }

        public async Task CreateDBAsync(string nameDB)
        {
            //using (var connection = new SqlConnection(_connectionStringMaster))
            //{
            //    await connection.ExecuteAsync("CREATE DATABASE [padel2025]");

            //    _connectionStringDB = new SqlConnectionStringBuilder(_connectionStringMaster)
            //    {
            //        InitialCatalog = "padel2025"
            //    }.ConnectionString;

            //}

            using (var connection = new SqlConnection(_connectionStringMaster))
            {
                await connection.ExecuteAsync("IF DB_ID(N'padel2025') IS NULL CREATE DATABASE " + nameDB);
                _dbNameCreated = nameDB;

                connectionStringDB = new SqlConnectionStringBuilder(_connectionStringMaster)
                {
                    InitialCatalog = nameDB
                }.ConnectionString;

            }
        }

        public async Task DropDB()
        {
            using (var connection = new SqlConnection(_connectionStringMaster))
            {
                await connection.ExecuteAsync("IF DB_ID(N'"+_dbNameCreated+"') IS NOT NULL BEGIN ALTER DATABASE " + _dbNameCreated + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE " + _dbNameCreated + "; END ");

              

            }
            //await RunScript("DropDB.sql");
        }
        public async ValueTask DisposeAsync()
        {
            if (!string.IsNullOrEmpty(connectionStringDB))
            {
                var dbName = new SqlConnectionStringBuilder(connectionStringDB).InitialCatalog;
                if (!string.IsNullOrWhiteSpace(dbName))
                    await DropDB();
            }
            else
            {
                // fallback si CreateDBAsync n'a jamais été appelé
                await DropDB();
            }
        }
        public async Task CreateTablesAsync()
        {
            await RunScript("CreateTable.sql");

        }

        public async Task CreateUtilisateurAsync()
        {
            await RunScript("CreateUtilisateur.sql");
        }

        public async Task CreateRoleAsync()
        {
            await RunScript("CreateRole.sql");
        }

        public async Task CreateSchemaAsync()
        {
            await RunScript("CreateSchema.sql");
        }

        public async Task CreateVuesAsync()
        {
            await RunScript("CreateVues.sql");
        }

        public async Task CreateFonctionsAsync()
        {
            await RunScript("CreateFonctions.sql");
        }

        public async Task CreateProceduresAsync()
        {
            await RunScript("CreateProcedures.sql");
        }

        public async Task RunScript(string filename)
        {
            //string sql = await GetFileFromAssemblyAsync(filename);

            //using (IDbConnection connection = new SqlConnection(_connectionStringDB))
            //{
            //    int rowsAffected = await connection.ExecuteAsync(sql);
            //}
            string sql = await GetFileFromAssemblyAsync(filename);

            var batches = Regex.Split(sql, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using (var connection = new SqlConnection(_connectionStringMaster))
            {
                await connection.OpenAsync();
                foreach (var batch in batches)
                {
                    var trimmed = batch.Trim();
                    if (string.IsNullOrWhiteSpace(trimmed))
                        continue;

                    await connection.ExecuteAsync(trimmed);
                }
            }
        }

        
    }
}
