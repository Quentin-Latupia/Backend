using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;
using Repositories;

namespace Services;

public class MembreService : IMembreService
{
    private readonly IMembreRepo _membreRepo;
    public MembreService(IMembreRepo membreRepo)
    {
        _membreRepo = membreRepo;
    } 

    public async Task AddMembreAsync(Membre entity)
    {
        await _membreRepo.AddMembreAsync(entity);
    }

    public async Task DeleteMembreAsync(int id)
    {
        await _membreRepo.DeleteMembreAsync(id);
    }

    public async Task<List<Membre>> GetAllMembreAsync()
    {
        return await _membreRepo.GetAllMembreAsync();
    }

    public async Task UpdateMembreAsync(Membre entity)
    {
        await _membreRepo.UpdateMembreAsync(entity);
    }
}
