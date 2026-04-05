using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Infrastructure.Context
{
    public class WalletFlowContext : DbContext
    {
        public WalletFlowContext(DbContextOptions<WalletFlowContext> options) : base(options) { }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Account>().Property(a => a.Balance).HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>().HasKey(t => t.TransactionId);
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
