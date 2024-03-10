using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Cars;

namespace AutoMarketProject.Application.Cars.Commands.UpdateCar;

public sealed record UpdateCarCommand(
    Guid Id,
    Brand? Brand,
    string? Model,
    string? Description,
    decimal? Price) : ICommand; 
