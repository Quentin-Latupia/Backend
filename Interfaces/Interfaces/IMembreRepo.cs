using Models;

namespace Interfaces
{
    public interface IMembreRepo
    {
        Task<List<Membre>> GetAllMembreAsync();
        Task AddMembreAsync(Membre entity);
        Task UpdateMembreAsync(Membre entity);
        Task DeleteMembreAsync(int id);
    }
}
