using HW.Core.Entities;
using HW.Core.Stores;
using HW.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HW.Persistence.Repositories;

public class CompanyRepository : ICompanyStore
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return company.Id;
    }
}
