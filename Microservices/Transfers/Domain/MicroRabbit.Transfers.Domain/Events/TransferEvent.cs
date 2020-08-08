using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Transfers.Domain.Events
{
    public abstract class TransferEvent : Event
    {
         public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}