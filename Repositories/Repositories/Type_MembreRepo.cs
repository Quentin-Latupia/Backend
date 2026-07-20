using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Type_MembreRepo : IType_MembreRepo
{
    private readonly AppDbContext _context;
    public Type_MembreRepo(AppDbContext context) => _context = context;

    public Task<List<Type_Membre>> GetAllType_MembreAsync() => throw new NotImplementedException();
    public Task AddType_MembreAsync(Type_Membre entity) => throw new NotImplementedException();
    public Task UpdateType_MembreAsync(Type_Membre entity) => throw new NotImplementedException();
    public Task DeleteType_MembreAsync(int id) => throw new NotImplementedException();
}
