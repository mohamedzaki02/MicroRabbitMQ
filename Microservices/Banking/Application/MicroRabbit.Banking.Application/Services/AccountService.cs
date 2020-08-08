using System.Collections.Generic;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _bus = bus;
            _accountRepository = accountRepository;

        }
        public IEnumerable<Account> GetAccounts() => _accountRepository.GetAccounts();

        public void Transfer(AccountTransfer accountTransfer)
        {
            _bus.SendCommand(new CreateTransferCommand(accountTransfer.FromAccount, accountTransfer.ToAccount, accountTransfer.TransferAmount));
        }
    }
}