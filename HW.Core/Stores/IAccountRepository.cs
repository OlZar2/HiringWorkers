using HW.Core.Entities;

namespace HW.Core.Stores;

public interface IAccountRepository
{
    Task<Account> GetByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email);

    Task<Account> GetByIdAsync(Guid id);
}
