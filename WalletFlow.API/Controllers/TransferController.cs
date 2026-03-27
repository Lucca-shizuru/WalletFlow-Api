using Microsoft.AspNetCore.Mvc;
using WalletFlow.API.Dtos;
using WalletFlow.Application.Interfaces;
using WalletFlow.Application.Services;

namespace WalletFlow.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService traferService)
        {
            _transferService = traferService;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            var result = await _transferService.ExecuteTransfer(request.FromId, request.ToId, request.Amount);

            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(new { message = "Transferência concluída!" });
        }


    }
}
