using Data;
using Interfaces;
using Models;

namespace Services;

public class TerrainService : ITerrainService
{
    private readonly ITerrainRepo _terrainRepo;
    public TerrainService(ITerrainRepo terrainRepo)
    {
        _terrainRepo = terrainRepo;
    }

    public async Task AddTerrainAsync(Terrain entity)
    {
        await _terrainRepo.AddTerrainAsync(entity);
    }

    public async Task DeleteTerrainAsync(int id)
    {
        await _terrainRepo.DeleteTerrainAsync(id);
    }

    public async Task<List<Terrain>> GetAllTerrainAsync()
    {
        return await _terrainRepo.GetAllTerrainAsync();
    }

    public async Task UpdateTerrainAsync(Terrain entity)
    {
        await _terrainRepo.UpdateTerrainAsync(entity);
    }
}
