using System.Data;
using DTO;
using Data;
using Microsoft.EntityFrameworkCore;
using Utilisateurs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configure DbContext if connection string provided in configuration
var conn = builder.Configuration.GetConnectionString("membrePadelConnection");
if (!string.IsNullOrEmpty(conn))
{
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conn));
}

var app = builder.Build();

// Call la procédure stockée sp_PlanningTerrain pour id_terrain = 1 et affiche le résultat
if (!string.IsNullOrEmpty(conn))
{
    //using var scope = app.Services.CreateScope();
    //var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    ////var utilisateur = new Utilisateur(ctx);
    ////var results = utilisateur.planingTerrain(1);

    

    //// Affiche les résultats dans la console
    //Console.WriteLine($"sp_PlanningTerrain results (count = {results.Count}):");
    //foreach (var dto in results)
    //{
    //    Console.WriteLine(dto.ToString());
    //}
}
else
{
    Console.WriteLine("Aucune chaîne de connexion trouvée. Ajoutez 'ConnectionStrings:DefaultConnection' dans appsettings.json ou user secrets.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
