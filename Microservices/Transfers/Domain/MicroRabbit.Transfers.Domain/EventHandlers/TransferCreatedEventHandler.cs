using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfers.Domain.Events;

namespace MicroRabbit.Transfers.Domain.EventHandlers
{
    public class TransferCreatedEventHandler : IEventHandler<TransferCreatedEvent>
    {
        public TransferCreatedEventHandler() { }
        public Task Handle(TransferCreatedEvent @event) => Task.CompletedTask;
    }
}