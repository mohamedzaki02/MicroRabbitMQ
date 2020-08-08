using System.Collections.Generic;
using MicroRabbit.Transfers.Application.Interfaces;
using MicroRabbit.Transfers.Domain.Interfaces;
using MicroRabbit.Transfers.Domain.Models;

namespace MicroRabbit.Transfers.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        public TransferService(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;

        }

        public IEnumerable<TransferLog> GetTransferLogs() => _transferRepository.GetTransferLogs();
    }
}