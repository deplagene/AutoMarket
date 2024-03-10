using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Presentation.Cars;

namespace AutoMarketProject.Application.Cars.Queries.GetCarById;

public sealed record GetCarByIdQuery(Guid Id) : IQuery<CarDto>;