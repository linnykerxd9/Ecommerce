using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Service.Mapping
{
    public class CostumerMapping : IEntityTypeConfiguration<Costumer>
    {
        public void Configure(EntityTypeBuilder<Costumer> builder)
        {
             builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Cpf)
                   .IsRequired();

            builder.Property(x => x.FullName)
                   .IsRequired();
        

            builder.ToTable("TB_Costumer");
        }
    }
}