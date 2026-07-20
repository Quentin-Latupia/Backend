using Data;
using Interfaces;
using Models;

namespace Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepo _reservationRepo;
    public ReservationService(IReservationRepo reservationRepo)
    {
        _reservationRepo = reservationRepo;
    }

    public async Task AddReservationAsync(Reservation entity)
    {
        await _reservationRepo.AddReservationAsync(entity);
    }

    public async Task DeleteReservationAsync(int id)
    {
        await _reservationRepo.DeleteReservationAsync(id);
    }

    public async Task<List<Reservation>> GetAllReservationAsync()
    {
        return await _reservationRepo.GetAllReservationAsync();
    }

    public async Task UpdateReservationAsync(Reservation entity)
    {
        await _reservationRepo.UpdateReservationAsync(entity);
    }
}
