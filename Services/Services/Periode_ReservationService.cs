using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Services;

public class Periode_ReservationService : IPeriode_ReservationService
{
    private readonly IPeriode_ReservationRepo _periode_ReservationRepo;
    public Periode_ReservationService(IPeriode_ReservationRepo periode_ReservationRepo)
    {
        _periode_ReservationRepo = periode_ReservationRepo;
    }

    public async Task AddPRAsync(Periode_Reservation entity)
    {
        await _periode_ReservationRepo.AddPRAsync(entity);
    }

    public async Task DeletePRAsync(int id)
    {
        await _periode_ReservationRepo.DeletePRAsync(id);
    }

    public async Task<List<Periode_Reservation>> GetAllPRAsync()
    {
        return await _periode_ReservationRepo.GetAllPRAsync();
    }

    public async Task UpdatePRAsync(Periode_Reservation entity)
    {
        await _periode_ReservationRepo.UpdatePRAsync(entity);
    }
}
