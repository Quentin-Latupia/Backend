using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Statut_ReservationRepo : IStatut_ReservationRepo
{
    private readonly AppDbContext _context;
    public Statut_ReservationRepo(AppDbContext context) => _context = context;

    public Task<List<Statut_Reservation>> GetAllStatutReservationAsync() => throw new NotImplementedException();
    public Task AddStatutReservationAsync(Statut_Reservation entity) => throw new NotImplementedException();
    public Task UpdateStatutReservationAsync(Statut_Reservation entity) => throw new NotImplementedException();
    public Task DeleteStatutReservationAsync(int id) => throw new NotImplementedException();
}
