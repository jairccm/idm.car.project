using idm.car.project.application.Dtos;

namespace paynau.jccm.project.Application.Features.People.Queries.ViewModels;


public class ProductVm
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public List<GroupAttributeDto> GroupAttributes { get; set; }
}


