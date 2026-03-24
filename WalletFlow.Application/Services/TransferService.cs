using System;
using System.Collections.Generic;
using System.Text;
using WalletFlow.Application.Interfaces;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Application.Services
{
        public class TransferService : ITransferService
    {
        public Result ExecuteTransfer(Account fromAccount, Account toAccount, decimal amount)
        {
            try 
            {
                fromAccount.Withdraw(amount);
                toAccount.Deposit(amount);
                return Result.success();
            }
            catch (Exception ex)
            {   
                return Result.failure(ex.Message);
            }
        }
    }
}
