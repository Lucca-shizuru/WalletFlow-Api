using System;
using System.Collections.Generic;
using System.Text;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Application.Interfaces
{
    public interface ITransferService
    {
        Task<Result> ExecuteTransfer(Guid fromId, Guid toId, decimal amount);
        
            
        
    }
}
