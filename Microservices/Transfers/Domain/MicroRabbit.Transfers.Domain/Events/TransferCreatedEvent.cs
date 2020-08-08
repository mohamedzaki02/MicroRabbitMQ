using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Transfers.Domain.Events
{
    public class TransferCreatedEvent : TransferEvent
    {
        public TransferCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }

       

    }
}