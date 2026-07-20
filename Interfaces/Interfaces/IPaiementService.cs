using Models;

namespace Interfaces
{
    public interface IPaiementService
    {
        Task<List<Paiement>> GetAllPaiementAsync();
        Task AddPaiementAsync(Paiement entity);
        Task UpdatePaiementAsync(Paiement entity);
        Task DeletePaiementAsync(int id);
    }
}
