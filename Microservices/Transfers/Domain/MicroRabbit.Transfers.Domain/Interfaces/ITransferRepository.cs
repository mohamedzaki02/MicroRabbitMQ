using System.Collections.Generic;
using MicroRabbit.Transfers.Domain.Models;

namespace MicroRabbit.Transfers.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}