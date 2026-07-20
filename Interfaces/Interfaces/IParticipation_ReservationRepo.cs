using Models;

namespace Interfaces
{
    public interface IParticipation_ReservationRepo
    {
        Task<List<Participation_Reservation>> GetAllPRAsync();
        Task AddPRAsync(Participation_Reservation entity);
        Task UpdatePRAsync(Participation_Reservation entity);
        Task DeletePRAsync(int id);
    }
}
