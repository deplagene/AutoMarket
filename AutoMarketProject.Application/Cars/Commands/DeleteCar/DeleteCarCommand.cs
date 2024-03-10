using AutoMarketProject.Application.Messaging;

namespace AutoMarketProject.Application.Cars.Commands.DeleteCar;

public sealed record DeleteCarCommand(Guid Id) : ICommand;