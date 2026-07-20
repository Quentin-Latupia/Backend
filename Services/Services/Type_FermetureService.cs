using Data;
using Interfaces;
using Models;

namespace Services;

public class Type_FermetureService : IType_FermetureService
{
    private readonly IType_FermetureRepo _type_FermetureRepo;
    public Type_FermetureService(IType_FermetureRepo type_FermetureRepo)
    {
        _type_FermetureRepo = type_FermetureRepo;
    }

    public async Task AddType_FermetureAsync(Type_Fermeture entity)
    {
        await _type_FermetureRepo.AddType_FermetureAsync(entity);
    }

    public async Task DeleteType_FermetureAsync(int id)
    {
        await _type_FermetureRepo.DeleteType_FermetureAsync(id);
    }

    public async Task<List<Type_Fermeture>> GetAllType_FermetureAsync()
    {
        return await _type_FermetureRepo.GetAllType_FermetureAsync();
    }

    public async Task UpdateType_FermetureAsync(Type_Fermeture entity)
    {
        await _type_FermetureRepo.UpdateType_FermetureAsync(entity);
    }
}
