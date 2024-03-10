using AutoMarketProject.Application.Cars.Commands.CreateCar;
using AutoMarketProject.Application.Cars.Commands.DeleteCar;
using AutoMarketProject.Application.Cars.Commands.UpdateCar;
using AutoMarketProject.Application.Cars.Queries.GetCarById;
using AutoMarketProject.Application.Cars.Queries.GetCarList;
using AutoMarketProject.Application.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarketProject.WebApi.Controllers;

[ApiController]
[Route("api/brands/{brandName}/cars")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Получить список машин
    /// </summary>
    /// <param name="carParameters">Параметры для пагинации</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllCars(CarParameters carParameters, 
        CancellationToken cancellationToken = default)
    {
        var query =  new GetCarsListQuery(carParameters);

        var response = await _mediator.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    /// <summary>
    /// Получить машину по идентификатору
    /// </summary>
    /// <param name="carId">Индетификатор машины</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{carId:guid}")]
    public async Task<IActionResult> GetCarById(Guid carId, 
        CancellationToken cancellationToken = default)
    {
        var query = new GetCarByIdQuery(carId);

        var response = await _mediator.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    
    /// <summary>
    /// Создать машину
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCar(CreateCarCommand command, 
        CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
    
    
    /// <summary>
    /// Удалить машину
    /// </summary>
    /// <param name="carId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("carId:guid")]
    [Authorize]
    public async Task<IActionResult> DeleteCar(Guid carId, 
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteCarCommand(carId);

        var response = await _mediator.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
    
    /// <summary>
    /// Обновить данные машины
    /// </summary>
    /// <param name="carId"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("carId:guid")]
    [Authorize]
    public async Task<IActionResult> UpdateCar(Guid carId,
        UpdateCarCommand request, CancellationToken cancellationToken = default)
    {
        var command = new UpdateCarCommand(
            carId,
            request.Brand,
            request.Model,
            request.Description,
            request.Price);

        var response = await _mediator.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
}