using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Xunit;
using Utilisateurs;

namespace Tests
{
    [Collection("IntegrationDB")]
    public class VuesRepoTests
    {
        private readonly DatabaseFixture _dbFixture;

        public VuesRepoTests(DatabaseFixture dbFixture)
        {
            _dbFixture = dbFixture;
        }

        [Fact]
        public async Task V_Matchs_Detail_View_test()
        {
            DBSetup dBSetup = new DBSetup(_dbFixture.ConnectionString);
            await dBSetup.CreateLogin();
            await dBSetup.CreateDBAsync("padel2025");
            //await dBSetup.RunScript("CreateTable.sql");

        }
    }
}
