using Data;
using DTO;
using Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using profiles;
using AutoMapper;
using Utilisateurs;

namespace WinFormsUtilisateur
{
    public partial class Form1 : Form
    {
        private AppDbContext _context;
        string connectionString = string.Empty;
        SqlConnection conn;
        string userName = string.Empty;
        ServiceProvider _service;
        public Form1()
        {
            InitializeComponent();
        }

        private void membreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionString = @"Server=PC_FAMILIAL\projetSGBD2025;Database=padel2025;User Id=membrePadel;Password=Ephec2025;TrustServerCertificate=True;";
            userName = "membrePadel";

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

            _context = new AppDbContext(options);

            _service = ConfigureService(connectionString);


            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                //var planningToolStripMenuItem = new ToolStripMenuItem("Planning1");
                //menuoptionToolStripMenuItem.ReplaceDropDownItems(planningToolStripMenuItem);
                //MessageBox.Show("Connexion établie avec succès.", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Échec de la connexion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionString = @"Server=PC_FAMILIAL\projetSGBD2025;Database=padel2025;User Id=adminGlobal;Password=Ephec2025;TrustServerCertificate=True;";
            userName = "adminGlobal";

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

            _context = new AppDbContext(options);
            _service = ConfigureService(connectionString);

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                //var planningToolStripMenuItem = new ToolStripMenuItem("Planning2");
                //menuoptionToolStripMenuItem.ReplaceDropDownItems(planningToolStripMenuItem);
                //MessageBox.Show("Connexion établie avec succès.", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Échec de la connexion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void adminSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionString = @"Server=PC_FAMILIAL\projetSGBD2025;Database=padel2025;User Id=adminSite;Password=Ephec2025;TrustServerCertificate=True;";
            userName = "adminSite";

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;

            _context = new AppDbContext(options);
            _service = ConfigureService(connectionString);

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                //var planningToolStripMenuItem = new ToolStripMenuItem("Planning3");
                //menuoptionToolStripMenuItem.ReplaceDropDownItems(planningToolStripMenuItem);
                //MessageBox.Show("Connexion établie avec succès.", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Échec de la connexion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void planingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(conn == null)
            {
                MessageBox.Show("Veuillez d'abord vous connecter avec un rôle.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            try
            {                
                using var scope = _service.CreateScope();
                var repo = scope.ServiceProvider.GetRequiredService<IUtilisateurRepo>();
                List<planningDTO> planning = repo.planingTerrain(1);
                dataGridView1.DataSource = planning;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Échec : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static ServiceProvider ConfigureService(string connectionString)
        {
            var services = new ServiceCollection();

            // AutoMapper (garde IMapper)
            services.AddAutoMapper(cfg => { }, typeof(planingProfile));

            // Enregistrer le DbContext (adapter UseSqlServer à votre provider et connection string)
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repo avec durée de vie scoped (correct pour EF DbContext)
            services.AddScoped<IUtilisateurRepo, Utilisateur>();

            services.AddLogging(configure => configure.AddConsole());

            return services.BuildServiceProvider();
        }
    }
}
