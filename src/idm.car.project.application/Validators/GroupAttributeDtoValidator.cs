using FluentValidation;
using idm.car.project.application.Dtos;

namespace idm.car.project.application.Validators;

public class GroupAttributeDtoValidator : AbstractValidator<GroupAttributeDto>
{
    public GroupAttributeDtoValidator()
    {

        RuleFor(x => x.GroupAttributeId)
            .NotEmpty().WithMessage("El GroupAttributeId es obligatorio.");

        RuleFor(x => x.QuantityInformation.GroupAttributeQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("La cantidad de atributos del grupo debe ser mayor o igual a 0.");

        RuleFor(x => x.QuantityInformation.VerifyValue)
            .Must(verifyValue => verifyValue == "EQUAL_THAN" || verifyValue == "LOWER_EQUAL_THAN")
            .WithMessage("VerifyValue debe ser 'EQUAL_THAN' o 'LOWER_EQUAL_THAN'.");


        RuleFor(x => x.Attributes)
            .NotEmpty().WithMessage("Debe haber al menos un atributo en el grupo.");

        RuleForEach(x => x.Attributes).SetValidator(new AttributesDtoValidator());
    }
}
