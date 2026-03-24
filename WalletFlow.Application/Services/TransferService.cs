using System;
using System.Collections.Generic;
using System.Text;
using WalletFlow.Application.Interfaces;
using WalletFlow.Domain.Entities;
using WalletFlow.Domain.Repositories.Interfaces;

namespace WalletFlow.Application.Services
{
        public class TransferService : ITransferService
    {
        private readonly IAccountRepository _repository;

        public TransferService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> ExecuteTransfer(Guid fromId, Guid toId, decimal amount)
        {
            try 
            {
                var fromAccount = await _repository.GetByIdAsync(fromId);
                var toAccount = await _repository.GetByIdAsync(toId);

                if (fromAccount == null || toAccount == null)
                    return Result.Failure("Uma ou ambas as contas não foram encontradas.");

                
                fromAccount.Withdraw(amount);
                toAccount.Deposit(amount);

                
                await _repository.UpdateAsync(fromAccount);
                await _repository.UpdateAsync(toAccount);

                return Result.Success();
            }
            
            catch (Exception ex)
            {   
                return Result.Failure(ex.Message);
            }
        }
    }
}
