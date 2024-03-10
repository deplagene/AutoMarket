using AutoMarketProject.Domain.Abstractions;
using AutoMarketProject.Domain.Cars;
using AutoMarketProject.Domain.Users;
using CSharpFunctionalExtensions;

namespace AutoMarketProject.Domain.Orders;

public class Order : EntityBase<Guid>
{
    private Order() { }
    public Order(User customer, IReadOnlyCollection<Car> cars)
    {
        if (customer is null)
        {
            throw new ArgumentException("Customer can't be null", nameof(customer));
        }

        if (cars is null)
        {
            throw new ArgumentException("Cars can't be null", nameof(cars));
        }
        Customer = customer;
        TotalPrice = cars.Sum(car => car.Price);
        CreatedAt = DateTime.UtcNow;
    }
    
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Покупатель
    /// </summary>
    public User Customer { get; private set; }

    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    public Guid CustomerId { get; private set; }
    
    /// <summary>
    /// Конечная цена
    /// </summary>
    public decimal TotalPrice { get; private set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public OrderStatus OrderStatus { get; private set; }

    /// <summary>
    /// Список машин
    /// </summary>
    public IReadOnlyCollection<Car> Cars { get; private set; }
    
    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    
    /// <summary>
    /// Изменить статус заказа
    /// </summary>
    public void SetStatus(OrderStatus orderStatus)
    {
        switch (orderStatus)
        {
            case OrderStatus.Created:
                throw new InvalidOperationException("Order is already created");
            case OrderStatus.Paid:
                if (OrderStatus != OrderStatus.Created)
                {
                    throw new InvalidOperationException("Order is not created");
                }
                OrderStatus = OrderStatus.Paid;
                break;
            case OrderStatus.Cancelled:
                if (OrderStatus != OrderStatus.Created)
                {
                    throw new InvalidOperationException("Order is not created");
                }
                OrderStatus = OrderStatus.Cancelled;
                break;
            default:
                throw new InvalidOperationException("Invalid Order Status");
        }
    }


    /// <summary>
    /// Создать заказ
    /// </summary>
    /// <param name="customer"></param>
    /// <param name="cars"></param>
    /// <returns></returns>
    public static Order CreateOrder(
        User customer, List<Car> cars)
    {
        var order = new Order(customer, cars);

        order.OrderStatus = OrderStatus.Created;
        
        return order;
    }
}