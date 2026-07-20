using Models;

namespace Interfaces
{
    public interface IType_MembreService
    {
        Task<List<Type_Membre>> GetAllType_MembreAsync();
        Task AddType_MembreAsync(Type_Membre entity);
        Task UpdateType_MembreAsync(Type_Membre entity);
        Task DeleteType_MembreAsync(int id);
    }
}
