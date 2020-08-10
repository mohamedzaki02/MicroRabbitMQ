using System.Threading.Tasks;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfers.Domain.Events;
using MicroRabbit.Transfers.Domain.Interfaces;
using MicroRabbit.Transfers.Domain.Models;

namespace MicroRabbit.Transfers.Domain.EventHandlers
{
    public class TransferCreatedEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferCreatedEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAcoount = @event.To,
                Amount = @event.Amount
            });
            _transferRepository.SaveAll();
            return Task.CompletedTask;
        }
    }
}