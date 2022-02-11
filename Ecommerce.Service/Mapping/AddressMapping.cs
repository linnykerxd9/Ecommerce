using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFornecedores.Infra.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ZipCode)
                   .IsRequired()
                   .HasColumnType("varchar(8)");

            builder.Property(x => x.Street)
                   .IsRequired();

            builder.Property(x => x.Number)
                   .IsRequired()
                   .HasColumnType("varchar(10)");

            builder.Property(x => x.Neighborhood)
                   .IsRequired();

            builder.Property(x => x.City)
                   .IsRequired();

            builder.Property(x => x.State)
                   .IsRequired();

            builder.ToTable("TB_Address");
        }
    }
}