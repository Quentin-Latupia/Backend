using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;
using Repositories;

namespace Services;

public class FermetureService : IFermetureService
{
    private readonly IFermetureRepo _fermetureRepo;
    public FermetureService(IFermetureRepo fermetureRepo)
    {
        _fermetureRepo = fermetureRepo;
    } 

    public async Task AddFermetureAsync(Fermeture entity)
    {
        await _fermetureRepo.AddFermetureAsync(entity);
    }

    public async Task DeleteFermetureAsync(int id)
    {
        await _fermetureRepo.DeleteFermetureAsync(id);
    }

    public async Task<List<Fermeture>> GetAllFermetureAsync()
    {
        return await _fermetureRepo.GetAllFermetureAsync();
    }

    public Task UpdateFermetureAsync(Fermeture entity)
    {
        throw new NotImplementedException();
    }
}
