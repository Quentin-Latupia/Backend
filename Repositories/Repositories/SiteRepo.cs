using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Interfaces;

namespace Repositories;

public class SiteRepo : ISiteRepo
{
    private readonly AppDbContext _context;
    public SiteRepo(AppDbContext context) => _context = context;

    public Task<List<Site>> GetAllSiteAsync() => throw new NotImplementedException();
    public Task AddSiteAsync(Site entity) => throw new NotImplementedException();
    public Task UpdateSiteAsync(Site entity) => throw new NotImplementedException();
    public Task DeleteSiteAsync(int id) => throw new NotImplementedException();
}
