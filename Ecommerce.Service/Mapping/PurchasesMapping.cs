using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Service.Mapping
{
    public class PurchasesMapping : IEntityTypeConfiguration<Purchases>
    {
        public void Configure(EntityTypeBuilder<Purchases> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.TotalPrice)
                   .IsRequired();
                   
            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.Property(x => x.CodePurchase)
                   .IsRequired();

            builder.ToTable("TB_ShoppingCart");
        }
    }
}