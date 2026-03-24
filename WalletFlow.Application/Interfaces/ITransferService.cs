using System;
using System.Collections.Generic;
using System.Text;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Application.Interfaces
{
    public interface ITransferService
    {
        Result ExecuteTransfer(Account fromAccountId, Account toAccountId, decimal amount);
        
            
        
    }
}
