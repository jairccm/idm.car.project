using AutoMapper;
using idm.car.project.application.Contracts.Persistence;
using MediatR;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;

namespace idm.car.project.application.Features.Product.Queries.GetPeopleList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductVm>>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(ICartRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var productsEntity = await _repository.GetAllAsync();
        var products = _mapper.Map<List<ProductVm>>(productsEntity);
        return products;
    }
}
