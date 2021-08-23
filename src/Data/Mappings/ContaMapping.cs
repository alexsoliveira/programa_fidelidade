using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Saldo)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.ToTable("Contas");
        }
    }
}
