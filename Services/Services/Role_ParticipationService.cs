using Data;
using Interfaces;
using Models;
using Repositories;

namespace Services;

public class Role_ParticipationService : IRole_ParticipationService
{
    private readonly Role_ParticipationRepo _role_ParticipationRepo;
    public Role_ParticipationService(Role_ParticipationRepo role_ParticipationRepo)
    {
        _role_ParticipationRepo = role_ParticipationRepo;
    } 

    public async Task AddRPAsync(Role_Participation entity)
    {
        await _role_ParticipationRepo.AddRPAsync(entity);
    }

    public async Task DeleteRPAsync(int id)
    {
        await _role_ParticipationRepo.DeleteRPAsync(id);
    }

    public async Task<List<Role_Participation>> GetAllRPAsync()
    {
        return await _role_ParticipationRepo.GetAllRPAsync();
    }

    public async Task UpdateRPAsync(Role_Participation entity)
    {
        await _role_ParticipationRepo.UpdateRPAsync(entity);
    }
}
