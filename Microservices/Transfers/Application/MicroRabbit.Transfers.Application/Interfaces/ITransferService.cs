using System.Collections.Generic;
using MicroRabbit.Transfers.Domain.Models;

namespace MicroRabbit.Transfers.Application.Interfaces
{
    public interface ITransferService
    {
         IEnumerable<TransferLog> GetTransferLogs();
    }
}