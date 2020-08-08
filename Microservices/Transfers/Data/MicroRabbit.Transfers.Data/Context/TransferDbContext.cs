using MicroRabbit.Transfers.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfers.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}