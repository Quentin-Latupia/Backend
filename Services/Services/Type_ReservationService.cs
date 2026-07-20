using Data;
using Interfaces;
using Models;

namespace Services;

public class Type_ReservationService : IType_ReservationService
{
    private readonly IType_ReservationRepo _type_ReservationRepo;
    public Type_ReservationService(IType_ReservationRepo type_ReservationRepo)
    {
        _type_ReservationRepo = type_ReservationRepo;
    }

    public async Task AddType_ReservationAsync(Type_Reservation entity)
    {
        await _type_ReservationRepo.AddType_ReservationAsync(entity);
    }

    public async Task DeleteType_ReservationAsync(int id)
    {
        await DeleteType_ReservationAsync(id);
    }

    public async Task<List<Type_Reservation>> GetAllType_ReservationAsync()
    {
        return await _type_ReservationRepo.GetAllType_ReservationAsync();
    }

    public async Task UpdateType_ReservationAsync(Type_Reservation entity)
    {
        await _type_ReservationRepo.UpdateType_ReservationAsync(entity);
    }
}
