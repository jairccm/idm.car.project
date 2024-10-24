using idm.car.project.application.Dtos;
using MediatR;

namespace idm.car.project.application.Features.Product.Commands.UpdateCommand;

public class UpdateProductCommand : IRequest
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<GroupAttributeDto> GroupAttributes { get; set; }
}
