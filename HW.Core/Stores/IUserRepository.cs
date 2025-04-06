using HW.Core.Entities;

namespace HW.Core.Stores;

public interface IUserRepository
{
    Task<Guid> CreateAsync(User user);

    Task<User> GetByIdAsync(Guid id);

    Task UpdateAsync(User user);
}