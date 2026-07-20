using Data;
using Interfaces;
using Models;

namespace Services;

public class Statut_ReservationService : IStatut_ReservationService
{
    private readonly IStatut_ReservationRepo _statut_ReservationRepo;
    public Statut_ReservationService(IStatut_ReservationRepo statut_ReservationRepo)
    {
        _statut_ReservationRepo = statut_ReservationRepo;
    }

    public async Task AddStatutReservationAsync(Statut_Reservation entity)
    {
        await _statut_ReservationRepo.AddStatutReservationAsync(entity);
    }

    public async Task DeleteStatutReservationAsync(int id)
    {
        await _statut_ReservationRepo.DeleteStatutReservationAsync(id);
    }

    public async Task<List<Statut_Reservation>> GetAllStatutReservationAsync()
    {
        return await _statut_ReservationRepo.GetAllStatutReservationAsync();
    }

    public async Task UpdateStatutReservationAsync(Statut_Reservation entity)
    {
        await _statut_ReservationRepo.UpdateStatutReservationAsync(entity);
    }
}
