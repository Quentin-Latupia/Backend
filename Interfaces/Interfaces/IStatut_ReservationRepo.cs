using Models;

namespace Interfaces
{
    public interface IStatut_ReservationRepo
    {
        Task<List<Statut_Reservation>> GetAllStatutReservationAsync();
        Task AddStatutReservationAsync(Statut_Reservation entity);
        Task UpdateStatutReservationAsync(Statut_Reservation entity);
        Task DeleteStatutReservationAsync(int id);
    }
}
