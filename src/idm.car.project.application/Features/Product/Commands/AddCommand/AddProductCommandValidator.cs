using FluentValidation;
using idm.car.project.application.Validators;

namespace idm.car.project.application.Features.Product.Commands.AddCommand;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.ProductId)
                        .GreaterThan(0).WithMessage("El ProductId debe ser mayor que 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del producto es obligatorio.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0.");

        RuleFor(x => x.GroupAttributes)
            .Must(list => list.Count > 0)
            .WithMessage("La lista de grupos no debe estar vacía.");

        RuleForEach(x => x.GroupAttributes).SetValidator(new GroupAttributeDtoValidator());

    }


}