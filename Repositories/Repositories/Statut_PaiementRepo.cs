using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Statut_PaiementRepo : IStatut_PaiementRepo
{
    private readonly AppDbContext _context;
    public Statut_PaiementRepo(AppDbContext context) => _context = context;

    public Task<List<Statut_Paiement>> GetAllStatutPaiementAsync() => throw new NotImplementedException();
    public Task AddStatutPaiementAsync(Statut_Paiement entity) => throw new NotImplementedException();
    public Task UpdateStatutPaiementAsync(Statut_Paiement entity) => throw new NotImplementedException();
    public Task DeleteStatutPaiementAsync(int id) => throw new NotImplementedException();
}
