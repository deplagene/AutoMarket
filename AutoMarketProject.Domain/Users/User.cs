using AutoMarketProject.Domain.Cars;
using AutoMarketProject.Domain.Orders;
using Microsoft.AspNetCore.Identity;

namespace AutoMarketProject.Domain.Users;

public sealed class User : IdentityUser<Guid>
{
    private readonly HashSet<Car> _cars = new();
    private readonly HashSet<Order> _orders = new();
    
    private User() { }

    public User(FullName fullName, string email, string password)
    {
        if (fullName is null)
        {
            throw new ArgumentException("FullName can't be null", nameof(fullName));
        }
        
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Email can't be empty", nameof(email));
        }
        
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password can't be empty", nameof(password));
        }
        
        FullName = fullName;
        Email = email;
        PasswordHash = password;
    }
    
    
    /// <summary>
    /// Полное имя пользователя
    /// </summary>
    public FullName FullName { get; private set; }
    
    
    /// <summary>
    /// Адресс пользователя
    /// </summary>
    public Address Address { get; private set; }
    
    
    /// <summary>
    /// Коллекция машин
    /// </summary>
    public IReadOnlyCollection<Car> Cars => _cars;
    
    
    /// <summary>
    /// Коллекция заказов
    /// </summary>
    public IReadOnlyCollection<Order> Orders => _orders;
    
    
    /// <summary>
    /// Создать машину
    /// </summary>
    /// <param name="fullName">Полное имя</param>
    /// <param name="email">Эл. почта</param>
    /// <param name="password">Пароль</param>
    /// <returns></returns>
    public static User CreateUser(FullName fullName,
        string email, string password)
    {
        var user = new User(
            fullName,
            email,
            password);

        return user;
    }
    
    /// <summary>
    /// Изменить полное имя
    /// </summary>
    /// <param name="fullName">Полное имя</param>
    public void SetFullName(FullName fullName) => FullName = fullName;
    
    
    /// <summary>
    /// Изменить адресс
    /// </summary>
    /// <param name="address">Адресс</param>
    public void SetAddress(Address address) => Address = address;
    
    
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
    
    
    /// <summary>
    /// Добавить заказ в список
    /// </summary>
    /// <param name="order"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void AddOrder(Order order)
    {
        if (_orders is null)
        {
            throw new InvalidOperationException("Need to _.Include(_ => _.Orders)");
        }

        _orders.Add(order);
    }
    
    
    /// <summary>
    /// Удалит заказ из списка
    /// </summary>
    /// <param name="order"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void RemoveOrder(Order order)
    {
        if (_orders is null)
        {
            throw new InvalidOperationException("Need to _.Include(_ => _.Orders)");
        }

        _orders.Remove(order);
    }
}