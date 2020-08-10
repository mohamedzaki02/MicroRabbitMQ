using FluentValidation;
using MicroRabbit.Banking.Domain.Commands;

namespace MicroRabbit.Banking.Domain.CommandValidations
{
    public class CreateTransferCommandValidator : AbstractValidator<CreateTransferCommand>
    {
        public CreateTransferCommandValidator()
        {
            RuleFor(t => t.From).NotEmpty();
            RuleFor(t => t.From).GreaterThan(0);
            RuleFor(t => t.To).NotEmpty();
            RuleFor(t => t.Amount).NotEmpty();
        }
    }
}