using FluentValidation;

namespace Business.Features.RecycleTypes.Commands.CreateRecycleType
{
    public class CreateRecycleTypeCommandValidator:AbstractValidator<CreateRecycleTypeCommand>
    {
        public CreateRecycleTypeCommandValidator()
        {
            RuleFor(r => r.RecycleTypeName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Recycle type name cannot be empty");
        }
    }
}
