using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Service.Mapping
{
    public class ShoppingCartMapping : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
           builder.HasKey(x => x.Id);
            
            builder.Property(x => x.TotalPrice)
                   .IsRequired();
                   
            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.ToTable("TB_ShoppingCart");
        }
    }
}