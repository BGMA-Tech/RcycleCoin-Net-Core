using FluentValidation;

namespace Business.Features.RecycleTypes.Commands.UpdateRecycleType
{
    public class UpdateRecycleTypeCommandValidator:AbstractValidator<UpdateRecycleTypeCommand>
    {
        public UpdateRecycleTypeCommandValidator()
        {
            RuleFor(r => r.RecycleTypeName)
                .NotEmpty()
                .WithMessage("Recycle type name cannot be empty");
        }
    }
}
