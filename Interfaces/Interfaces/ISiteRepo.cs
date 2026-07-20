using Models;

namespace Interfaces
{
    public interface ISiteRepo
    {
        Task<List<Site>> GetAllSiteAsync();
        Task AddSiteAsync(Site entity);
        Task UpdateSiteAsync(Site entity);
        Task DeleteSiteAsync(int id);
    }
}
