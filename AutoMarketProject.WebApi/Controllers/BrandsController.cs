using AutoMarketProject.Application.Brands.Queries.GetBrandByName;
using AutoMarketProject.Application.Brands.Queries.GetBrandList;
using AutoMarketProject.Application.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarketProject.WebApi.Controllers;


[ApiController]
[Route("api/brands")]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator) => _mediator = mediator;
    
    /// <summary>
    /// Получить список брендов машины
    /// </summary>
    /// <param name="brandParameters">Параметры для пагинации</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllBrands(BrandParameters brandParameters,
        CancellationToken cancellationToken)
    {
        var query = new GetBrandListQuery(brandParameters);

        var response = await _mediator.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

    
    /// <summary>
    /// Получить бренд по имени
    /// </summary>
    /// <param name="brandName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetBrandByName(string brandName, CancellationToken cancellationToken)
    {
        var query = new GetBrandByNameQuery(brandName);

        var response = await _mediator.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Value);
    }
}