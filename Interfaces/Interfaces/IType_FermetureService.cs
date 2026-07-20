using Models;

namespace Interfaces
{
    public interface IType_FermetureService
    {
        Task<List<Type_Fermeture>> GetAllType_FermetureAsync();
        Task AddType_FermetureAsync(Type_Fermeture entity);
        Task UpdateType_FermetureAsync(Type_Fermeture entity);
        Task DeleteType_FermetureAsync(int id);
    }
}
