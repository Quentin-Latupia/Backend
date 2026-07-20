using Models;

namespace Interfaces
{
    public interface IStatut_PaiementService
    {
        Task<List<Statut_Paiement>> GetAllStatutPaiementAsync();
        Task AddStatutPaiementAsync(Statut_Paiement entity);
        Task UpdateStatutPaiementAsync(Statut_Paiement entity);
        Task DeleteStatutPaiementAsync(int id);
    }
}
