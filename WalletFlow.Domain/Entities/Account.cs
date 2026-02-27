using System;
using System.Collections.Generic;
using System.Text;

namespace WalletFlow.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; private set; }
        public string Owner { get; private set; }
        public decimal Balance { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public Account(string owner)
        {
            Id = Guid.NewGuid();
            Owner = owner;
            Balance = 0;
            CreatedAt = DateTime.Now;

            if (string.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentException("Owner name cannot be empty.");
            }
        }



        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
        }
    }
}
     

