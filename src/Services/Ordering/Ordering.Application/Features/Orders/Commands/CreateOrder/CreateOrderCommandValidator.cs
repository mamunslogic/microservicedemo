using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.Username).NotEmpty().WithMessage("Please enter username")
                .NotNull()
                .EmailAddress().WithMessage("Username should be a valid email");

            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Please enter first name")
                .MaximumLength(100).WithMessage("First name must not exceed 100 character");

            RuleFor(c=>c.EmailAddress).EmailAddress().WithMessage("Username should be a valid email");

            RuleFor(c => c.TotalPrice).GreaterThan(0).WithMessage("Total price should be greater than zero");
        }
    }
}
