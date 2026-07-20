using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class ReservationRepo : IReservationRepo
{
    private readonly AppDbContext _context;
    public ReservationRepo(AppDbContext context) => _context = context;

    public Task<List<Reservation>> GetAllReservationAsync() => throw new NotImplementedException();
    public Task AddReservationAsync(Reservation entity) => throw new NotImplementedException();
    public Task UpdateReservationAsync(Reservation entity) => throw new NotImplementedException();
    public Task DeleteReservationAsync(int id) => throw new NotImplementedException();
}
