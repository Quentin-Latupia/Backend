using Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services;

public class Participation_ReservationService : IParticipation_ReservationService
{
    private readonly IParticipation_ReservationRepo _participation_ReservationRepo;
    public Participation_ReservationService(IParticipation_ReservationRepo participation_ReservationRepo)
    {
        _participation_ReservationRepo = participation_ReservationRepo;
    }
    

    public async Task AddPRAsync(Participation_Reservation entity)
    {
        await _participation_ReservationRepo.AddPRAsync(entity);
    }

    public async Task DeletePRAsync(int id)
    {
        await _participation_ReservationRepo.DeletePRAsync(id);
    }

    public Task<List<Participation_Reservation>> GetAllPRAsync()
    {
        return _participation_ReservationRepo.GetAllPRAsync();
    }

    public async Task UpdatePRAsync(Participation_Reservation entity)
    {
        await _participation_ReservationRepo.UpdatePRAsync(entity);
    }
}
