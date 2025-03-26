using HW.Core.Entities;

namespace HW.Core.Stores;

public interface IAccountStore
{
    public Task<Account> GetByEmailAsync(string email);
}
