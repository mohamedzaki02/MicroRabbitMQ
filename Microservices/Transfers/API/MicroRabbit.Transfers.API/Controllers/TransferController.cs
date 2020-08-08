using MicroRabbit.Transfers.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Transfers.API.Controllers
{

    [Route("api/transfers")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;

        }

        [HttpGet]
        public IActionResult Get() => Ok(_transferService.GetTransferLogs());
    }
}
