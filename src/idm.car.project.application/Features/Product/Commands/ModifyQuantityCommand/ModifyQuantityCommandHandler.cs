using AutoMapper;
using idm.car.project.application.Contracts.Persistence;
using idm.car.project.application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace idm.car.project.application.Features.Product.Commands.ModifyQuantityCommand;

public class ModifyQuantityCommandHandler : IRequestHandler<ModifyQuantityCommand>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<ModifyQuantityCommandHandler> _logger;

    public ModifyQuantityCommandHandler(ICartRepository repository, IMapper mapper, ILogger<ModifyQuantityCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Handle(ModifyQuantityCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _repository.GetByIdAsync(request.ProductId);
        if (productEntity == null)
        {
            _logger.LogError($"{request.ProductId} producto no existe en el sistema");
            throw new NotFoundException($"{request.ProductId} producto no existe en el sistema");
        }

        var groupAttribute = productEntity.GroupAttributes.Where(x => x.GroupAttributeId == request.GroupAttributeId).FirstOrDefault();
        if (groupAttribute == null)
        {
            _logger.LogError($"{request.GroupAttributeId} grupo no existe en el producto con id {request.ProductId}");
            throw new NotFoundException($"{request.GroupAttributeId} grupo no existe en el producto con id {request.ProductId}");
        }


        var attribute = groupAttribute.Attributes.Where(x => x.AttributeId == request.AttributeId).FirstOrDefault();
        if (attribute == null)
        {
            _logger.LogError($"{request.AttributeId} atributo no existe en el grupo con id {request.GroupAttributeId}");
            throw new NotFoundException($"{request.AttributeId} atributo no existe en el grupo con id {request.GroupAttributeId}");
        }
        // validar si se puede incrmentar la cantidad de los productos
        if(attribute.MaxQuantity <= 1)
        {
            _logger.LogError($"{request.AttributeId} atributo no existe en el grupo con id {request.GroupAttributeId}");
            throw new BadRequestException($"No se puede incrementar o disminuir la cantidad para el producto {productEntity.Name}, grupo con id {request.GroupAttributeId} y atributo con id {request.AttributeId}");
        }

        var attributeQuantityDefault = attribute.DefaultQuantity;

        if (request.Action.Equals("INCREMENT"))
        {
            attributeQuantityDefault++;
        }else if (request.Action.Equals("DECREMENT"))
        {
            attributeQuantityDefault--;
        }

        if (attributeQuantityDefault == 0 )
        {
            _logger.LogError($"{request.AttributeId} atributo no existe en el grupo con id {request.GroupAttributeId}");
            throw new BadRequestException($"No se puede disminuir la cantidad para el producto {productEntity.Name}, grupo con id {request.GroupAttributeId} y atributo con id {request.AttributeId} porque tiene un solo producto agregado");
        }else if (attributeQuantityDefault > attribute.MaxQuantity)
        {
            _logger.LogError($"{request.AttributeId} atributo no existe en el grupo con id {request.GroupAttributeId}");
            throw new BadRequestException($"No se puede incrementar prque la cantidad maxima seleccionbale para el producto {productEntity.Name}, grupo con id {request.GroupAttributeId} y atributo con id {request.AttributeId} es {attribute.MaxQuantity}");
        }

        attribute.DefaultQuantity = attributeQuantityDefault;

        await _repository.UpdateAsync(productEntity);


        _logger.LogInformation($"El {request.ProductId} producto fue eliminado con exito");
    }
}
