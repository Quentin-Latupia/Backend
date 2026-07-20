using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class FermetureRepo : IFermetureRepo
{
    private readonly AppDbContext _context;
    public FermetureRepo(AppDbContext context) => _context = context;

    public Task<List<Fermeture>> GetAllFermetureAsync() => throw new NotImplementedException();
    public Task AddFermetureAsync(Fermeture entity) => throw new NotImplementedException();
    public Task UpdateFermetureAsync(Fermeture entity) => throw new NotImplementedException();
    public Task DeleteFermetureAsync(int id) => throw new NotImplementedException();
}
