using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendAPI.Configrations
{
    public class ProductCofiguration : IEntityTypeConfiguration<Praduct>
    {
        public void Configure(EntityTypeBuilder<Praduct> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(20).IsRequired();
            builder.Property(b => b.SoldPrice).HasColumnType("decimal(6,2)").IsRequired();
            builder.Property(b => b.CostPrice).HasColumnType("decimal(6,2)").IsRequired();
            builder.Property(b => b.DisplayStatus).HasDefaultValue(true);
        }
    }
}
