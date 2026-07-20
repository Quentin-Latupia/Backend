using Models;

namespace Interfaces
{
    public interface ITerrainService
    {
        Task<List<Terrain>> GetAllTerrainAsync();
        Task AddTerrainAsync(Terrain entity);
        Task UpdateTerrainAsync(Terrain entity);
        Task DeleteTerrainAsync(int id);
    }
}
