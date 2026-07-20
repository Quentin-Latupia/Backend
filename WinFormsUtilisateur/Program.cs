using Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using profiles;
using Utilisateurs;

namespace WinFormsUtilisateur
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new formCalendrier());
        }

        //private static ServiceProvider ConfigureService()
        //{
        //    var services = new ServiceCollection();

        //    // AutoMapper (garde IMapper)
        //    services.AddAutoMapper(cfg => { }, typeof(planingProfile));

        //    // Enregistrer le DbContext (adapter UseSqlServer à votre provider et connection string)
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseSqlServer("Server=.;Database=VotreDb;Trusted_Connection=True;"));

        //    // Repo avec durée de vie scoped (correct pour EF DbContext)
        //    services.AddScoped<IUtilisateurRepo, Utilisateur>();

        //    services.AddLogging(configure => configure.AddConsole());

        //    return services.BuildServiceProvider();
        //}
    }
}