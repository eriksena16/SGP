using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Mappings
{
    public class CategoriadoItemMapping : IEntityTypeConfiguration<CategoriaDoItem>
    {
        public void Configure(EntityTypeBuilder<CategoriaDoItem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}
