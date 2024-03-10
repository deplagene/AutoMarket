using AutoMarketProject.Domain.Cars;

namespace AutoMarketProject.Presentation.Cars;

public record CarDto(
    Guid Id,
    Brand Brand,
    string Model,
    decimal Price);