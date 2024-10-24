using idm.car.project.application.Contracts.Persistence;
using idm.car.project.application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace idm.car.project.application.Features.Product.Commands.DeleteCommand;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly ICartRepository _repository;
    private readonly ILogger<DeleteProductCommandHandler> _logger;

    public DeleteProductCommandHandler(ICartRepository repository, ILogger<DeleteProductCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var personToDelete = await _repository.GetByIdAsync(request.productId);
        if (personToDelete == null)
        {
            _logger.LogError($"{request.productId} producto no existe en el sistema");
            throw new NotFoundException($"El producto con id {request.productId} no existe en el sistema");
        }

        await _repository.DeleteAsync(personToDelete);


        _logger.LogInformation($"El {request.productId} producto fue eliminado con exito");
    }
}
