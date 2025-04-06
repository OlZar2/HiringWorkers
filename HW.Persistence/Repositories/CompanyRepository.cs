using HW.Core.Entities;
using HW.Core.Stores;
using HW.Persistence.Context;
using HW.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HW.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
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

    public async Task<Company> GetByIdAsync(Guid guid)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == guid)
            ?? throw new NotFoundException($"Не найдена компнаия с Id {guid}");

        return company;
    }

    public async Task UpdateAsync(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }
}
