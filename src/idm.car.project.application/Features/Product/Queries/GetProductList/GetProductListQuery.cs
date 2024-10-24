using MediatR;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;

namespace idm.car.project.application.Features.Product.Queries.GetPeopleList;

public class GetProductListQuery : IRequest<List<ProductVm>>
{
}
