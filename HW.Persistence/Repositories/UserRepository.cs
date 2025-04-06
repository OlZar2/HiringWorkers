using HW.Core.Entities;
using HW.Core.Stores;
using HW.Persistence.Context;
using HW.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HW.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return user.Id;
    }

    public async Task<User> GetByIdAsync(Guid userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId)
            ?? throw new NotFoundException($"Не найден пользователь с Id {userId}");

        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}