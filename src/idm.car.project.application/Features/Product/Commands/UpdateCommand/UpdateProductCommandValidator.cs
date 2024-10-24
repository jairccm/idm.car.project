using FluentValidation;
using idm.car.project.application.Validators;

namespace idm.car.project.application.Features.Product.Commands.UpdateCommand;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.ProductId)
                        .GreaterThan(0).WithMessage("El ProductId debe ser mayor que 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del producto es obligatorio.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0.");

        RuleFor(x => x.GroupAttributes)
            .NotEmpty().WithMessage("Debe haber al menos un grupo de atributos.");

        RuleForEach(x => x.GroupAttributes).SetValidator(new GroupAttributeDtoValidator());

    }
}
