using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class TerrainRepo : ITerrainRepo
{
    private readonly AppDbContext _context;
    public TerrainRepo(AppDbContext context) => _context = context;

    public Task<List<Terrain>> GetAllTerrainAsync() => throw new NotImplementedException();
    public Task AddTerrainAsync(Terrain entity) => throw new NotImplementedException();
    public Task UpdateTerrainAsync(Terrain entity) => throw new NotImplementedException();
    public Task DeleteTerrainAsync(int id) => throw new NotImplementedException();
}
