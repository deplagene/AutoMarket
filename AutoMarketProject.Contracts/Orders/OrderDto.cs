using AutoMarketProject.Domain.Orders;
using AutoMarketProject.Domain.Users;

namespace AutoMarketProject.Presentation.Orders;

public record OrderDto(
    User Customer, 
    decimal TotalPrice, 
    OrderStatus OrderStatus);