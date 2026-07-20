using Models;

namespace Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllReservationAsync();
        Task AddReservationAsync(Reservation entity);
        Task UpdateReservationAsync(Reservation entity);
        Task DeleteReservationAsync(int id);
    }
}
