using HW.Core.Entities;
using HW.Core.Stores;
using HW.Persistence.Context;
using HW.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HW.Persistence.Repositories;

public class ProfessionRepository : IProfessionRepository
{
    private readonly ApplicationDbContext _context;

    public ProfessionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Profession> GetByIdAsync(Guid id)
    {
        var profession = await _context.Proffesions.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new NotFoundException("Профессия не найдена");

        return profession;
    }

    public async Task<Profession[]> GetAllAsync()
    {
        var professions = await _context.Proffesions.ToArrayAsync();

        return professions;
    }
}
