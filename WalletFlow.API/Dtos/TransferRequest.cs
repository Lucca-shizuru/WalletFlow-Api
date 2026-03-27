namespace WalletFlow.API.Dtos
{
    public record TransferRequest(Guid FromId, Guid ToId, decimal Amount);
    
    
}
