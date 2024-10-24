using MediatR;
using idm.car.project.application.Dtos;

namespace idm.car.project.application.Features.Product.Commands.AddCommand;

public class AddProductCommand : IRequest
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<GroupAttributeDto> GroupAttributes { get; set; }

   
}