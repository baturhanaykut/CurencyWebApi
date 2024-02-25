using CurrencyWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyWebApi.Infrastructre.EntitiesConfiguration
{
    internal class CurrencyDetailConfig : IEntityTypeConfiguration<CurrencyDetail>
    {
        public void Configure(EntityTypeBuilder<CurrencyDetail> builder)
        {
            builder.HasKey(c => new { c.CurrenyId, c.Date });

            builder.Property(x => x.CurrenyId).HasColumnOrder(1);

            builder.Property(x => x.Date).HasColumnOrder(2)
                .IsRequired(true)
                .HasColumnType("DATETIME");

            builder.Property(x => x.Value).HasColumnOrder(3)
                .IsRequired(true)
                .HasColumnType("VARCHAR(10)");

            builder.HasOne(x => x.Currency)
                .WithMany(x => x.CurrencyDetails)
                .HasForeignKey(x => x.CurrenyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
