using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class Type_ReservationRepo : IType_ReservationRepo
{
    private readonly AppDbContext _context;
    public Type_ReservationRepo(AppDbContext context) => _context = context;

    public Task<List<Type_Reservation>> GetAllType_ReservationAsync() => throw new NotImplementedException();
    public Task AddType_ReservationAsync(Type_Reservation entity) => throw new NotImplementedException();
    public Task UpdateType_ReservationAsync(Type_Reservation entity) => throw new NotImplementedException();
    public Task DeleteType_ReservationAsync(int id) => throw new NotImplementedException();
}
