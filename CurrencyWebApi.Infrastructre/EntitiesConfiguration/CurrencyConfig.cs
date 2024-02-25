using CurrencyWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyWebApi.Infrastructre.EntitiesConfiguration
{
    internal class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(1);


            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnOrder(2)
                .HasColumnType("VARCHAR(20)");

            builder.Property(x => x.AttributeName)
                .IsRequired(true)
                .HasColumnOrder(3)
                .HasColumnType("VARCHAR(20)");


        }
    }
}
