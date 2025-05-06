using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.OrderItemId);

            builder.Property(oi => oi.ProductId)
                   .IsRequired();

            builder.Property(oi => oi.OrderId)
                   .IsRequired();

            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.Property(oi => oi.Price)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();

            builder.Property(oi => oi.AddedAt)
                   .IsRequired();

            builder.ToTable("OrderItems");
        }
    }
}
