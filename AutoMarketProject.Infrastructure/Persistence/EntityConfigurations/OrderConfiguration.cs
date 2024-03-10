using AutoMarketProject.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoMarketProject.Infrastructure.Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.TotalPrice).IsRequired();  
            
        builder
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders);
        
        builder
            .HasMany(o => o.Cars)
            .WithOne(c => c.Order)
            .HasForeignKey(c => c.OrderId);
    }
}