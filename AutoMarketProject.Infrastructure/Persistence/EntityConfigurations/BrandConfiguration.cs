using AutoMarketProject.Domain.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoMarketProject.Infrastructure.Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(b => b.BrandName).HasMaxLength(100)
            .IsRequired();


        builder
            .HasMany(b => b.Cars)
            .WithOne(c => c.Brand)
            .HasForeignKey(c => c.BrandId);
    }
}