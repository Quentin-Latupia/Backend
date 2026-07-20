using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Type_FermetureRepo : IType_FermetureRepo
{
    private readonly AppDbContext _context;
    public Type_FermetureRepo(AppDbContext context) => _context = context;

    public Task<List<Type_Fermeture>> GetAllType_FermetureAsync() => throw new NotImplementedException();
    public Task AddType_FermetureAsync(Type_Fermeture entity) => throw new NotImplementedException();
    public Task UpdateType_FermetureAsync(Type_Fermeture entity) => throw new NotImplementedException();
    public Task DeleteType_FermetureAsync(int id) => throw new NotImplementedException();
}
