using AutoMarketProject.Application.Common.Interfaces;
using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Cars;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Application.Cars.Commands.DeleteCar;

public class DeleteCarCommandHandler : ICommandHandler<DeleteCarCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);

        if (car is null)
        {
            return Result.Failure<Car>($"{nameof(car)} is null");
        }
        
        _carRepository.Remove(car);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}