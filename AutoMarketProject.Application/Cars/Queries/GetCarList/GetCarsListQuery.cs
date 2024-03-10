using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Presentation.Cars;

namespace AutoMarketProject.Application.Cars.Queries.GetCarList;

public record GetCarsListQuery(CarParameters CarParameters) : IQuery<PagedList<CarDto>>;