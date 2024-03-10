using AutoMapper;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Application.Pagination;
using AutoMarketProject.Presentation.Cars;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Cars.Queries.GetCarList;

public class GetCarsListQueryHandler : IQueryHandler<GetCarsListQuery, PagedList<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarsListQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<CarDto>>> Handle(GetCarsListQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllUsePagination(request.CarParameters, cancellationToken);

        var carsDto = _mapper.Map<PagedList<CarDto>>(cars);

        return carsDto;
    }
}