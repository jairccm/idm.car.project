using FluentValidation;

namespace idm.car.project.application.Features.Product.Commands.ModifyQuantityCommand;

public class ModifyQuantityCommandValidator : AbstractValidator<ModifyQuantityCommand>
{
    public ModifyQuantityCommandValidator()
    {
        // Validar que ProductId, GroupAttributeId y AttributeId sean mayores a cero
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId debe ser mayor a 0.");

        RuleFor(x => x.GroupAttributeId)
            .NotEmpty()
            .NotNull()
            .WithMessage("GroupAttributeId no debe estar vacio");

        RuleFor(x => x.AttributeId)
            .GreaterThan(0)
            .WithMessage("AttributeId debe ser mayor a 0.");

        RuleFor(x => x.Action)
            .NotEmpty()
            .WithMessage("Action no debe estar vacío.")
            .Must(action => action == "INCREMENT" || action == "DECREMENT")
            .WithMessage("Action debe ser 'INCREMENT' o 'DECREMENT'.");
    }
}

