using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Periode_ReservationRepo : IPeriode_ReservationRepo
{
    private readonly AppDbContext _context;
    public Periode_ReservationRepo(AppDbContext context) => _context = context;

    public Task<List<Periode_Reservation>> GetAllPRAsync() => throw new NotImplementedException();
    public Task AddPRAsync(Periode_Reservation entity) => throw new NotImplementedException();
    public Task UpdatePRAsync(Periode_Reservation entity) => throw new NotImplementedException();
    public Task DeletePRAsync(int id) => throw new NotImplementedException();
}
