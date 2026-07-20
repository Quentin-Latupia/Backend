using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class PaiementRepo : IPaiementRepo
{
    private readonly AppDbContext _context;
    public PaiementRepo(AppDbContext context) => _context = context;

    public Task<List<Paiement>> GetAllPaiementAsync() => throw new NotImplementedException();
    public Task AddPaiementAsync(Paiement entity) => throw new NotImplementedException();
    public Task UpdatePaiementAsync(Paiement entity) => throw new NotImplementedException();
    public Task DeletePaiementAsync(int id) => throw new NotImplementedException();
}
