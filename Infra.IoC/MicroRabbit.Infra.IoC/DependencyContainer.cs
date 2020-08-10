
using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Domain.Core.PipelineBehaviors;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfers.Application.Interfaces;
using MicroRabbit.Transfers.Application.Services;
using MicroRabbit.Transfers.Data.Context;
using MicroRabbit.Transfers.Data.Repository;
using MicroRabbit.Transfers.Domain.EventHandlers;
using MicroRabbit.Transfers.Domain.Events;
using MicroRabbit.Transfers.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddTransient<TransferCreatedEventHandler>();

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferCreatedEventHandler>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferService, TransferService>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}