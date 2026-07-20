using Models;

namespace Interfaces
{
    public interface IRole_ParticipationService
    {
        Task<List<Role_Participation>> GetAllRPAsync();
        Task AddRPAsync(Role_Participation entity);
        Task UpdateRPAsync(Role_Participation entity);
        Task DeleteRPAsync(int id);
    }
}
