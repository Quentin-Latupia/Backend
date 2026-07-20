using Models;

namespace Interfaces
{
    public interface IType_ReservationService
    {
        Task<List<Type_Reservation>> GetAllType_ReservationAsync();
        Task AddType_ReservationAsync(Type_Reservation entity);
        Task UpdateType_ReservationAsync(Type_Reservation entity);
        Task DeleteType_ReservationAsync(int id);
    }
}
