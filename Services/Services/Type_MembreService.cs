using Data;
using Interfaces;
using Models;

namespace Services;

public class Type_MembreService : IType_MembreService
{
    private readonly IType_MembreRepo _type_MembreRepo;
    public Type_MembreService(IType_MembreRepo type_MembreRepo)
    {
        _type_MembreRepo = type_MembreRepo;
    }

    public async Task AddType_MembreAsync(Type_Membre entity)
    {
        await _type_MembreRepo.AddType_MembreAsync(entity);
    }

    public async Task DeleteType_MembreAsync(int id)
    {
        await _type_MembreRepo.DeleteType_MembreAsync(id);
    }

    public async Task<List<Type_Membre>> GetAllType_MembreAsync()
    {
        return await _type_MembreRepo.GetAllType_MembreAsync();
    }

    public async Task UpdateType_MembreAsync(Type_Membre entity)
    {
        await _type_MembreRepo.UpdateType_MembreAsync(entity);
    }
}
