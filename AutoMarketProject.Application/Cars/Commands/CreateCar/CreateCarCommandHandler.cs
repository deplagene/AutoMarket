using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Cars;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Cars.Commands.CreateCar;

public class CreateCarCommandHandler : ICommandHandler<CreateCarCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = Car.Create(
            request.Brand,
            request.Model,
            request.Description,
            request.Price);
        
        _carRepository.Add(car);
    
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}