using MediatR;

namespace idm.car.project.application.Features.Product.Commands.ModifyQuantityCommand;

public class ModifyQuantityCommand : IRequest
{
    public int ProductId { get; set; }
    public string GroupAttributeId { get; set; }
    public int AttributeId { get; set; }
    public String Action { get; set; }
}
