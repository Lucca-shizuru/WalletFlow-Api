using WalletFlow.Domain.Entities;
using WalletFlow.Domain.Repositories.Interfaces;
using WalletFlow.Infrastructure.Context;

namespace WalletFlow.Domain.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly WalletFlowContext _context;

        public AccountRepository(WalletFlowContext context)
        {
            _context = context;
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }
}
