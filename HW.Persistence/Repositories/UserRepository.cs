using HW.Core.Entities;
using HW.Core.Stores;
using HW.Persistence.Context;

namespace HW.Persistence.Repositories;

public class UserRepository : IUserStore
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
}