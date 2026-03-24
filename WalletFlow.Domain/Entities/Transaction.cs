using System;
using System.Collections.Generic;
using System.Text;

namespace WalletFlow.Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; private set; }

        public Guid FromAccountId { get; private set; }
        public Guid ToAccountId { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime Timestamp { get; private set; }

        public Transaction( Guid FromAccountId, Guid ToAccountId, decimal Amount) 
        {
            if (Amount <= 0)
            {
                throw new ArgumentException("Transaction amount must be positive.");
            }

            if (FromAccountId == ToAccountId)
            {
                throw new ArgumentException("From and To account cannot be the same.");
            }

            if(FromAccountId == Guid.Empty || ToAccountId == Guid.Empty)
            {
                throw new ArgumentException("Account IDs cannot be empty.");
            }

            TransactionId = Guid.NewGuid();
            this.FromAccountId = FromAccountId;
            this.ToAccountId = ToAccountId;
            this.Amount = Amount;
            Timestamp = DateTime.UtcNow;

        }

        private Transaction() { }


    }
}
