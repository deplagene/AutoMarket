using AutoMapper;
using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Cars;
using AutoMarketProject.Presentation.Cars;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Cars.Queries.GetCarById;

public class GetCarByIdQueryHandler : IQueryHandler<GetCarByIdQuery, CarDto>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarByIdQueryHandler(IMapper mapper, ICarRepository carRepository)
    {
        _mapper = mapper;
        _carRepository = carRepository;
    }

    public async Task<Result<CarDto>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);

        if (car is null)
        {
            return Result.Failure<CarDto>($"{nameof(car)} not found");
        }

        var carDto = _mapper.Map<CarDto>(car);

        return carDto;
    }
}