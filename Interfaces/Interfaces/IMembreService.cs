using Models;

namespace Interfaces
{
    public interface IMembreService
    {
        Task<List<Membre>> GetAllMembreAsync();
        Task AddMembreAsync(Membre entity);
        Task UpdateMembreAsync(Membre entity);
        Task DeleteMembreAsync(int id);


    }
}
