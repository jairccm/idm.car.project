using idm.car.project.api.Responses;
using idm.car.project.application.Exceptions;
using idm.car.project.application.Features.Product.Commands.AddCommand;
using idm.car.project.application.Features.Product.Commands.DeleteCommand;
using idm.car.project.application.Features.Product.Commands.ModifyQuantityCommand;
using idm.car.project.application.Features.Product.Commands.UpdateCommand;
using idm.car.project.application.Features.Product.Queries.GetPeopleList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace idm.car.project.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CartController> _logger;

    public CartController(IMediator mediator, ILogger<CartController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct(AddProductCommand command)
    {
        try
        {
            var validator = new AddProductCommandValidator();

            var result = validator.Validate(command);

            var errors = new List<String>();

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    errors.Add($"Propiedad: {failure.PropertyName}, Error: {failure.ErrorMessage}");
                }

                return BadRequest(new ApiResponse<object> { Message = $"Uno mas campos requieren revision!.",Data = errors });
            }

            await _mediator.Send(command);

            return Ok(new ApiResponse<object> { Message = "Producto creado correctamente." });
        }
        catch (BadRequestException e)
        {
            return BadRequest(new ApiResponse<object> { Message = e.Message });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error no controlado");
            return BadRequest("Ha ocurrido un error!");
        }
        
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
    {
        try
        {

            var validator = new UpdateProductCommandValidator();

            var result = validator.Validate(command);

            var errors = new List<String>();

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    errors.Add($"Propiedad: {failure.PropertyName}, Error: {failure.ErrorMessage}");
                }

                return BadRequest(new ApiResponse<object> { Message = $"Uno mas campos requieren revision!.", Data = errors });
            }

            await _mediator.Send(command);
            return Ok(new ApiResponse<object> { Message = "Producto actualizado correctamente." });
        }
        catch(NotFoundException e)
        {
            return NotFound(new ApiResponse<object> { Message = e.Message});
        }
        catch (BadRequestException e)
        {
            return BadRequest(new ApiResponse<object> { Message = e.Message });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error no controlado");
            return BadRequest(new ApiResponse<object> { Message = $"A ocurrido un error al actualizar el producto {command.Name}" });
        }

    }

    [HttpPost("modify-quantity")]
    public async Task<IActionResult> ModifyQuantity(ModifyQuantityCommand command)
    {
        try
        {

            var validator = new ModifyQuantityCommandValidator();

            var result = validator.Validate(command);

            var errors = new List<String>();

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    errors.Add($"Propiedad: {failure.PropertyName}, Error: {failure.ErrorMessage}");
                }

                return BadRequest(new ApiResponse<object> { Message = $"Uno mas campos requieren revision!.", Data = errors });
            }

            await _mediator.Send(command);
            return Ok(new ApiResponse<object> { Message = "Cantidad de Producto actualizado correctamente." });
        }
        catch (NotFoundException e)
        {
            return NotFound(new ApiResponse<object> { Message = e.Message });
        }
        catch (BadRequestException e)
        {
            return BadRequest(new ApiResponse<object> { Message = e.Message });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error no controlado");
            return BadRequest(new ApiResponse<object> { Message = $"A ocurrido un error al actualizar la cantidad del producto" });
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _mediator.Send(new DeleteProductCommand { productId = id });
            return Ok(new ApiResponse<object> { Message = $"Producto con id {id} eliminado correctamente" });
        }
        catch (NotFoundException e)
        {
            return NotFound(new ApiResponse<object> { Message = e.Message });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error no controlado");
            return BadRequest(new ApiResponse<object> { Message = $"A ocurrido un error al eliminar el producto con id {id}" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var products = await _mediator.Send(new GetProductListQuery());
        return Ok(products);
    }
}
