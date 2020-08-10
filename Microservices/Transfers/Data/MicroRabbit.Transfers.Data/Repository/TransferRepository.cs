using System.Collections.Generic;
using System.Linq;
using MicroRabbit.Transfers.Data.Context;
using MicroRabbit.Transfers.Domain.Interfaces;
using MicroRabbit.Transfers.Domain.Models;

namespace MicroRabbit.Transfers.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _ctx;
        public TransferRepository(TransferDbContext transferContext)
        {
            _ctx = transferContext;

        }

        public IEnumerable<TransferLog> GetTransferLogs() => _ctx.TransferLogs.ToList();

        public void Add(TransferLog log)
        {
            _ctx.TransferLogs.Add(log);
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}