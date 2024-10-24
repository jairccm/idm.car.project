using MediatR;

namespace idm.car.project.application.Features.Product.Commands.DeleteCommand;

public class DeleteProductCommand : IRequest
{
    public int productId { get; set; }
}
