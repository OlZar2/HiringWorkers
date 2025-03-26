using HW.Core.Entities;

namespace HW.Core.Stores;

public interface IUserStore
{
    Task<Guid> CreateAsync(User user);
}