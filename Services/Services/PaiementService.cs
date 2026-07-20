using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Services;

public class PaiementService : IPaiementService
{
    private readonly IPaiementRepo _paiementRepo;
    public PaiementService(IPaiementRepo paiementRepo)
    {
        _paiementRepo = paiementRepo;
    } 

    public async Task AddPaiementAsync(Paiement entity)
    {
        await _paiementRepo.AddPaiementAsync(entity);
    }

    public async Task DeletePaiementAsync(int id)
    {
        await _paiementRepo.DeletePaiementAsync(id);
    }

    public async Task<List<Paiement>> GetAllPaiementAsync()
    {
        return await _paiementRepo.GetAllPaiementAsync();
    }

    public async Task UpdatePaiementAsync(Paiement entity)
    {
        await _paiementRepo.UpdatePaiementAsync(entity);
    }
}
