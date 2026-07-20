using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Role_ParticipationRepo : IRole_ParticipationRepo
{
    private readonly AppDbContext _context;
    public Role_ParticipationRepo(AppDbContext context) => _context = context;

    public Task<List<Role_Participation>> GetAllRPAsync() => throw new NotImplementedException();
    public Task AddRPAsync(Role_Participation entity) => throw new NotImplementedException();
    public Task UpdateRPAsync(Role_Participation entity) => throw new NotImplementedException();
    public Task DeleteRPAsync(int id) => throw new NotImplementedException();
}
