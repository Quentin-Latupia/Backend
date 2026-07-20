using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Participation_ReservationRepo : IParticipation_ReservationRepo
{
    private readonly AppDbContext _context;
    public Participation_ReservationRepo(AppDbContext context) => _context = context;

    public Task<List<Participation_Reservation>> GetAllPRAsync() => throw new NotImplementedException();
    public Task AddPRAsync(Participation_Reservation entity) => throw new NotImplementedException();
    public Task UpdatePRAsync(Participation_Reservation entity) => throw new NotImplementedException();
    public Task DeletePRAsync(int id) => throw new NotImplementedException();
}
