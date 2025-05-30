﻿using HW.Core.Entities;
using HW.Core.Stores;
using HW.Persistence.Context;
using HW.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HW.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Account> GetByEmailAsync(string email)
    {
        var account = await _context.Accounts
            .Where(a => a.Email.Value == email)
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Аккаунт не найден");

        return account;
    }

    public async Task<Account> GetByIdAsync(Guid id)
    {
        var account = await _context.Accounts
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Аккаунт не найден");

        return account;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Accounts
            .AnyAsync(a => a.Email.Value == email);
    }
}
