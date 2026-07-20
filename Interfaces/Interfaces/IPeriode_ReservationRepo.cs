using Models;

namespace Interfaces
{
    public interface IPeriode_ReservationRepo
    {
        Task<List<Periode_Reservation>> GetAllPRAsync();
        Task AddPRAsync(Periode_Reservation entity);
        Task UpdatePRAsync(Periode_Reservation entity);
        Task DeletePRAsync(int id);
    }
}
