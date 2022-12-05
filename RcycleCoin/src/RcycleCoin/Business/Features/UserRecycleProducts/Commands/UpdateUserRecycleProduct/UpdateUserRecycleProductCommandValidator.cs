using FluentValidation;

namespace Business.Features.UserRecycleProducts.Commands.UpdateUserRecycleProduct
{
    public class UpdateUserRecycleProductCommandValidator:AbstractValidator<UpdateUserRecycleProductCommand>
    {
        public UpdateUserRecycleProductCommandValidator()
        {
            RuleFor(r => r.UserId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("User id must be greater than 0");
            RuleFor(r => r.Quantity)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0");
            RuleFor(r => r.RecycleProductId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Recycle product id must be greater than 0");
            RuleFor(r => r.UserId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("User id must be greater than 0");
        }
    }
}
