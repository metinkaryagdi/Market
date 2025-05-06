using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.UserId)
                   .IsRequired();

            builder.Property(o => o.OrderDate)
                   .IsRequired();

            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();

            builder.Property(o => o.Status)
                   .HasConversion<string>() // Enum'u string olarak saklamak için
                   .IsRequired();

            builder.ToTable("Orders");

            // İlişki varsa ileride navigation property eklenince şöyle yapılabilir:
            // builder.HasOne<User>()
            //        .WithMany()
            //        .HasForeignKey(o => o.UserId);
        }
    }
}
