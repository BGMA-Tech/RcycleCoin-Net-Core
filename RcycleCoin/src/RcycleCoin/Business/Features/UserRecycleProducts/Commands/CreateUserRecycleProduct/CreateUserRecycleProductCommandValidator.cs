using FluentValidation;

namespace Business.Features.UserRecycleProducts.Commands.CreateUserRecycleProduct
{
    public class CreateUserRecycleProductCommandValidator:AbstractValidator<CreateUserRecycleProductCommand>
    {
        public CreateUserRecycleProductCommandValidator()
        {
            RuleFor(r => r.UserId)
                .NotEmpty();
            RuleFor(r => r.Quantity)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0");
            RuleFor(r => r.RecycleProductId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Recycle product id must be greater than 0");
            RuleFor(r => r.UserId).NotEmpty();
        }
    }
}
