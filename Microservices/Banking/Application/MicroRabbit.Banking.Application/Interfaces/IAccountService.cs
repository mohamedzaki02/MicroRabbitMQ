using System.Collections.Generic;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        // To be changed later using Dtos & AutoMapper
        IEnumerable<Account> GetAccounts();

        void Transfer(AccountTransfer accountTransfer);
    }
}