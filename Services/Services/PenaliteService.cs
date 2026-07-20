using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Services;

public class PenaliteService : IPenaliteService
{
    private readonly IPenaliteRepo _penaliteRepo;
    public PenaliteService(IPenaliteRepo penaliteRepo)
    {
        _penaliteRepo = penaliteRepo;
    }  

    public async Task AddPenaliteAsync(Penalite entity)
    {
        await _penaliteRepo.AddPenaliteAsync(entity);
    }

    public async Task DeletePenaliteAsync(int id)
    {
        await _penaliteRepo.DeletePenaliteAsync(id);
    }

    public async Task<List<Penalite>> GetAllPenaliteAsync()
    {
        return await _penaliteRepo.GetAllPenaliteAsync();
    }

    public async Task UpdatePenaliteAsync(Penalite entity)
    {
        await _penaliteRepo.UpdatePenaliteAsync(entity);
    }
}