using System;
using System.Collections.Generic;
using System.Text;
using WalletFlow.Domain.Entities;
using WalletFlow.Domain.Repositories.Interfaces;

namespace WalletFlow.Domain.Repositories
{
    public class AccountRepository : IAccountRepository
    {
       
        public Task AddAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
