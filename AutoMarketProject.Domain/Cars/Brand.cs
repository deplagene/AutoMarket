using AutoMarketProject.Domain.Abstractions;

namespace AutoMarketProject.Domain.Cars;

public class Brand : EntityBase<Guid>
{
    private readonly HashSet<Car> _cars = new();
    
    private Brand() { }
    
    public Brand(string brandName)
    {
        if (string.IsNullOrEmpty(brandName))
            throw new ArgumentException("Name can't be empty",
                nameof(brandName));
        
        BrandName = brandName;
    }
    
    /// <summary>
    /// Идентификатор бренда
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Имя бренда
    /// </summary>
    public string BrandName { get; private set; }

    /// <summary>
    /// Список машин бренда
    /// </summary>
    public IReadOnlyCollection<Car>? Cars => _cars;
    
    
    /// <summary>
    /// Установить имя бренда
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetBrandName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name can't be empty",
                nameof(name));
        if (BrandName != name)
            BrandName = name;
    }
    
    
    /// <summary>
    /// Добавить машину в список
    /// </summary>
    /// <param name="car"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void AddCar(Car car)
    {
        if (_cars is null)
        {
            throw new InvalidOperationException("Need to _.Include(_ => _.Cars)");
        }

        _cars.Add(car);
    }
    
    
    /// <summary>
    /// Удалить машину из списка
    /// </summary>
    /// <param name="car"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void RemoveCar(Car car)
    {
        if (_cars is null)
        {
            throw new InvalidOperationException("Need to _.Include(_ => _.Cars)");
        }

        _cars.Remove(car);
    }
}