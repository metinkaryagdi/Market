using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.CartItemId);

            builder.Property(ci => ci.ProductId).IsRequired();
            builder.Property(ci => ci.UserId).IsRequired();
            builder.Property(ci => ci.Quantity).IsRequired();
            builder.Property(ci => ci.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(ci => ci.AddedAt).IsRequired();

            builder.ToTable("CartItems");
        }
    }
}
