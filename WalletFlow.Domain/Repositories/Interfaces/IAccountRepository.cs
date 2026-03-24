using System;
using System.Collections.Generic;
using System.Text;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Domain.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(Guid id);

        Task UpdateAsync(Account account);

        Task AddAsync(Account account);
    }
}
