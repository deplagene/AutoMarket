using AutoMarketProject.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoMarketProject.Infrastructure.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ComplexProperty(u => u.FullName).IsRequired();
        builder.ComplexProperty(u => u.Address).IsRequired();
        
        builder
            .HasMany(c => c.Cars)
            .WithOne(u => u.Owner)
            .HasForeignKey(u => u.OwnerId);
        
        builder
            .HasMany(o => o.Orders)
            .WithOne(u => u.Customer)
            .HasForeignKey(u => u.CustomerId);

    }
}