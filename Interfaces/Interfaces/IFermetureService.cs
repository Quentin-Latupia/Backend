using Models;

namespace Interfaces
{
    public interface IFermetureService
    {
        Task<List<Fermeture>> GetAllFermetureAsync();
        Task AddFermetureAsync(Fermeture entity);
        Task UpdateFermetureAsync(Fermeture entity);
        Task DeleteFermetureAsync(int id);
    }
}
