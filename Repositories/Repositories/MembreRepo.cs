using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class MembreRepo : IMembreRepo
{
    private readonly AppDbContext _context;
    public MembreRepo(AppDbContext context) => _context = context;

    public Task<List<Membre>> GetAllMembreAsync() => throw new NotImplementedException();
    public Task AddMembreAsync(Membre entity) => throw new NotImplementedException();
    public Task UpdateMembreAsync(Membre entity) => throw new NotImplementedException();
    public Task DeleteMembreAsync(int id) => throw new NotImplementedException();
}
