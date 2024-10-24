using FluentValidation;
using idm.car.project.application.Dtos;

namespace idm.car.project.application.Validators;

public class AttributesDtoValidator : AbstractValidator<AttributesDto>
{
    public AttributesDtoValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del atributo es obligatorio.");

        RuleFor(x => x.MaxQuantity)
            .GreaterThanOrEqualTo(1).WithMessage("La cantidad máxima del atributo debe ser mayor o igual a 1.");

        RuleFor(x => x.PriceImpactAmount)
            .GreaterThanOrEqualTo(0).WithMessage("El precio de impacto debe ser mayor o igual a 0.");

        RuleFor(x => x.DefaultQuantity)
            .LessThanOrEqualTo(x => x.MaxQuantity)
            .WithMessage("La cantidad por defecto no puede ser mayor que la cantidad máxima.");
    }
}

