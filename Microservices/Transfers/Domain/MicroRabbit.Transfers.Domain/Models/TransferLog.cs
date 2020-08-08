namespace MicroRabbit.Transfers.Domain.Models
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int FromAccount { get; set; }
        public int ToAcoount { get; set; }
        public decimal Amount { get; set; }
    }
}