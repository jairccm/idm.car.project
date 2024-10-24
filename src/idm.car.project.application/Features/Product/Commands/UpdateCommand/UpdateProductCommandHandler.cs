using AutoMapper;
using idm.car.project.application.Contracts.Persistence;
using idm.car.project.application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;


namespace idm.car.project.application.Features.Product.Commands.UpdateCommand;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(ICartRepository repository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = await _repository.GetByIdAsync(request.ProductId);

        if (productToUpdate == null)
        {
            _logger.LogError($"No se encontro el Producto id {request.ProductId}");
            throw new NotFoundException($"No se encontro el Producto id {request.ProductId}");
        }


        int groupIndex = -1;

        foreach (var GroupAttribute in request.GroupAttributes)
        {
            groupIndex++;
            //validar cantidad máxima por atributo
            int attributeIndex = -1;
            foreach (var attribute in GroupAttribute.Attributes)
            {
                attributeIndex++;
                if (attribute.DefaultQuantity > attribute.MaxQuantity)
                {
                    throw new BadRequestException($"grupo [{groupIndex}] la cantidad seleccionada del atributo[{attributeIndex}]  {nameof(attribute.DefaultQuantity)} no debe ser mayor a {attribute.MaxQuantity}");
                }
            }


            //validar cantida de grupo
            var totalAttributeSelecteds = GroupAttribute.Attributes.Where(x => x.DefaultQuantity > 0)?.Count() ?? 0;

            if (GroupAttribute.QuantityInformation.VerifyValue.Equals("EQUAL_THAN"))
            {

                if (GroupAttribute.QuantityInformation.GroupAttributeQuantity != totalAttributeSelecteds)
                {
                    throw new BadRequestException($"Los atributos  del grupo {nameof(GroupAttribute)}[{groupIndex}] seleccionados deben ser igual a {GroupAttribute.QuantityInformation.GroupAttributeQuantity} attributos");
                }
            }
            else if (GroupAttribute.QuantityInformation.VerifyValue.Equals("LOWER_EQUAL_THAN"))
            {
                if (GroupAttribute.QuantityInformation.GroupAttributeQuantity < totalAttributeSelecteds)
                {
                    throw new BadRequestException($"Los atributos del grupo seleccionados {nameof(GroupAttribute)}[{groupIndex}] no deben superar los {GroupAttribute.QuantityInformation.GroupAttributeQuantity} attributos");
                }
            }

        }

        var productEntity = _mapper.Map<domain.Entities.Product>(request);


        await _repository.UpdateAsync(productEntity);


        _logger.LogInformation($"La operacion fue exitosa actualizando el producto {request.ProductId}");
    }
}
