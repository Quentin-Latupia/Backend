using Data;
using Interfaces;
using Models;

namespace Services;

public class SiteService : ISiteService
{
    private readonly ISiteRepo _siteRepo;
    public SiteService(ISiteRepo siteRepo)
    {
        _siteRepo = siteRepo;
    }

    public async Task AddSiteAsync(Site entity)
    {
        await _siteRepo.AddSiteAsync(entity);
    }

    public async Task DeleteSiteAsync(int id)
    {
        await _siteRepo.DeleteSiteAsync(id);
    }

    public async Task<List<Site>> GetAllSiteAsync()
    {
        return await _siteRepo.GetAllSiteAsync();
    }

    public async Task UpdateSiteAsync(Site entity)
    {
        await _siteRepo.UpdateSiteAsync(entity);
    }
}
