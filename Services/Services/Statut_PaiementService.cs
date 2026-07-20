using Data;
using Interfaces;
using Models;

namespace Services;

public class Statut_PaiementService : IStatut_PaiementService
{
    private readonly IStatut_PaiementRepo _statut_PaiementRepo;
    public Statut_PaiementService(IStatut_PaiementRepo statut_PaiementRepo)
    {
        _statut_PaiementRepo = statut_PaiementRepo;
    }

    public async Task AddStatutPaiementAsync(Statut_Paiement entity)
    {
        await _statut_PaiementRepo.AddStatutPaiementAsync(entity);
    }

    public async Task DeleteStatutPaiementAsync(int id)
    {
        await _statut_PaiementRepo.DeleteStatutPaiementAsync(id);
    }

    public async Task<List<Statut_Paiement>> GetAllStatutPaiementAsync()
    {
        return await _statut_PaiementRepo.GetAllStatutPaiementAsync();
    }

    public async Task UpdateStatutPaiementAsync(Statut_Paiement entity)
    {
        await _statut_PaiementRepo.UpdateStatutPaiementAsync(entity);
    }
}
