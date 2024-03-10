using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Cars;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Cars.Commands.UpdateCar;

public class UpdateCarCommandHandler : ICommandHandler<UpdateCarCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);

        if (car is null)
        {
            return Result.Failure<Car>($"{nameof(car)} is null");
        }

        if (request.Brand is not null)
        {
            car.SetBrand(request.Brand);
        }

        if (!string.IsNullOrWhiteSpace(request.Model))
        {
            car.SetModel(request.Model);
        }
        
        if (!string.IsNullOrWhiteSpace(request.Description))
        {
            car.SetDescription(request.Description);
        }

        if (request.Price.HasValue)
        {
            car.SetPrice(request.Price.Value);
        }
        
        _carRepository.Update(car);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}