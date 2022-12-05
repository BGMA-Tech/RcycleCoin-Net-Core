using FluentValidation;

namespace Business.Features.RecycleProducts.Commands.UpdateRecycleProduct
{
    public class UpdateRecycleProductCommandValidator : AbstractValidator<UpdateRecycleProductCommand>
    {
        public UpdateRecycleProductCommandValidator()
        {
            RuleFor(r => r.RecycleName)
                .NotEmpty()
                .WithMessage("Recycle name cannot be empty");
            RuleFor(r => r.RecyclePoint)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Recycling score must be greater than 0");
            RuleFor(r => r.RecycleTypeId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Recycle type id must be greater than 0");
        }
    }
}
