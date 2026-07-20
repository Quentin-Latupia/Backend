using Models;

namespace Interfaces
{
    public interface IPenaliteRepo
    {
        Task<List<Penalite>> GetAllPenaliteAsync();
        Task AddPenaliteAsync(Penalite entity);
        Task UpdatePenaliteAsync(Penalite entity);
        Task DeletePenaliteAsync(int id);
    }
}
