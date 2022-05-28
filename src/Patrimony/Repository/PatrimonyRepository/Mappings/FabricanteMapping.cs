using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Mappings
{
    public class FabricanteMapping : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");
        }
    }
}
