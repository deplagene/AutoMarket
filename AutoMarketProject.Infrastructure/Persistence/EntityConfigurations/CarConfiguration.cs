using AutoMarketProject.Domain.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoMarketProject.Infrastructure.Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Model).HasMaxLength(60).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(1000);
        
        
        builder
            .HasOne(c => c.Owner)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.OwnerId);
            
        
        builder
            .HasOne(c => c.Order)
            .WithMany(o => o.Cars)
            .HasForeignKey(o => o.OrderId);

        builder
            .HasOne(c => c.Brand)
            .WithMany(b => b.Cars)
            .HasForeignKey(b => b.Id);
    }
}