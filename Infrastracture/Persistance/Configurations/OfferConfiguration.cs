using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.OfferId);

            builder.Property(o => o.OfferName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(o => o.DiscountPercentage)
                   .HasColumnType("decimal(5,2)")
                   .IsRequired();

            builder.Property(o => o.StartDate)
                   .IsRequired();

            builder.Property(o => o.EndDate)
                   .IsRequired();

            builder.Property(o => o.Description)
                   .HasMaxLength(500);

            builder.Property(o => o.IsActive)
                   .IsRequired();

            builder.Property(o => o.ProductId)
                   .IsRequired();

            builder.ToTable("Offers");
        }
    }
}
