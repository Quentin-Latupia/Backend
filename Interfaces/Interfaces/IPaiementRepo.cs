using Models;

namespace Interfaces
{
    public interface IPaiementRepo 
    {
        Task<List<Paiement>> GetAllPaiementAsync();
        Task AddPaiementAsync(Paiement entity);
        Task UpdatePaiementAsync(Paiement entity);
        Task DeletePaiementAsync(int id);
    }
}
