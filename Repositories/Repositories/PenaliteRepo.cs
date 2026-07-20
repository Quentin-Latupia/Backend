using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class PenaliteRepo : IPenaliteRepo
{
    private readonly AppDbContext _context;
    public PenaliteRepo(AppDbContext context) => _context = context;

    public Task<List<Penalite>> GetAllPenaliteAsync() => throw new NotImplementedException();
    public Task AddPenaliteAsync(Penalite entity) => throw new NotImplementedException();
    public Task UpdatePenaliteAsync(Penalite entity) => throw new NotImplementedException();
    public Task DeletePenaliteAsync(int id) => throw new NotImplementedException();
}
