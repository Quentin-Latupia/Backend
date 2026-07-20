using Shared;
using Testcontainers.MsSql;

namespace Shared
{
    public class DatabaseFixture : IAsyncLifetime
    {
        private MsSqlContainer _container;
        public DBSetup DbSetup { get; private set; } = null!;
        public string ConnectionString { get; private set; } = null!;

        public async Task InitializeAsync()
        {
            _container = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPassword("Your_strong(!)Password")
                .Build();

            await _container.StartAsync();

            // Build connection string and DBSetup
            var masterCs = _container.GetConnectionString();
            // ensure DB created, tables created and seeded once
            DbSetup = new DBSetup(masterCs);
            await DbSetup.CreateLogin();
            await DbSetup.CreateDBAsync("padel2025");
            await DbSetup.CreateTablesAsync();
            await DbSetup.CreateRoleAsync();
            await DbSetup.CreateUtilisateurAsync();
            await DbSetup.CreateSchemaAsync();
            await DbSetup.CreateVuesAsync();
            await DbSetup.CreateFonctionsAsync();
            await DbSetup.CreateProceduresAsync();

            ConnectionString = masterCs.Replace("master", "padel2025");
        }

        public async Task DisposeAsync()
        {
            if (_container is not null)
            {
                await _container.StopAsync();
                await _container.DisposeAsync();
                _container = null!;
            }
        }

    }

    [CollectionDefinition("IntegrationDB", DisableParallelization = true)]
    public class IntegrationCollection : ICollectionFixture<DatabaseFixture>
    {
        // No code here - just links the fixture to the collection name
    }
}