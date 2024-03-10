using AutoMarketProject.Application.Messaging;
using AutoMarketProject.Domain.Cars;

namespace AutoMarketProject.Application.Cars.Commands.CreateCar;

/// <summary>
/// Команда для создания машины
/// </summary>
/// <param name="Brand">Бренд машины</param>
/// <param name="Model">Модель машины</param>
/// <param name="Description">Описание машины</param>
/// <param name="Price">Цена машины</param>
public sealed record CreateCarCommand(
    Brand Brand,
    string Model,
    string Description,
    decimal Price
    ) : ICommand;