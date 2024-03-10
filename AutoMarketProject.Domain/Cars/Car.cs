using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Orders;
using AutoMarketProject.Domain.Users;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Domain.Cars;

public class Car : EntityBase<Guid>
{
    private Car() { }
    public Car(Brand brand, string model, string? description, decimal price)
    {
        if (brand is null)
        {
            throw new ArgumentException("Brand can't be null", nameof(brand));
        }

        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Model can't be null", nameof(model));
        }

        if (price <= 0 )
        {
            throw new ArgumentException("Price can't be less than or equal to zero", nameof(price));
        }

        Brand = brand;
        Model = model;
        Description = description;
        Price = price;
        RegistrationDate = DateTime.UtcNow;
    }
    
    /// <summary>
    /// Идентификатор машины
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Бренд машины
    /// </summary>
    public Brand Brand { get; private set; }

    
    /// <summary>
    /// Идентификатор бренда
    /// </summary>
    public Guid BrandId { get; private set; }
    /// <summary>
    ///  Заказ
    /// </summary>
    public Order Order { get; private set; }
    
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; private set; }
    
    /// <summary>
    /// Модель машины
    /// </summary>
    public string Model { get; private set; }

    /// <summary>
    /// Владелец машины
    /// </summary>
    public User Owner { get; private set; }

    /// <summary>
    /// Идентификатор владелцьа
    /// </summary>
    public Guid OwnerId { get; private set; }
    
    /// <summary>
    /// Стоимость машины
    /// </summary>
    public decimal Price { get; private set; }
    
    /// <summary>
    /// Описание машины
    /// </summary>
    public string? Description { get; private set; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; private set; }
    
    /// <summary>
    /// Установить описание для машины
    /// </summary>
    /// <param name="description"></param>
    public void SetDescription(string description)
    {
        if (Description != description)
            Description = description;
    }
    
    
    /// <summary>
    /// Изменть бренд
    /// </summary>
    /// <param name="brand">Бренд</param>
    public void SetBrand(Brand brand) => Brand = brand;


    public void SetModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model can't be null", nameof(model));
        
        if (Model != model)
            Model = model;
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price can't be less than or equal to zero", nameof(price));
        if (Price != price)
            Price = price;
    }
    
    /// <summary>
    /// Создать машину
    /// </summary>
    /// <param name="brand"></param>
    /// <param name="model"></param>
    /// <param name="description"></param>
    /// <param name="price"></param>
    /// <returns></returns>

    public static Car Create(
        Brand brand,
        string model,
        string? description,
        decimal price)
    {
        var car = new Car(
            brand,
            model,
            description,
            price);

        return car;
    }
}

