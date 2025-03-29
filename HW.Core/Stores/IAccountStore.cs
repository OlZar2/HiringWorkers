using HW.Core.Entities;

namespace HW.Core.Stores;

public interface IAccountStore
{
    Task<Account> GetByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email);
}
