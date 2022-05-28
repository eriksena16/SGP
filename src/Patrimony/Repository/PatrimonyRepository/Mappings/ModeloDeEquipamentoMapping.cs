using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Mappings
{
    public class ModeloDeEquipamentoMapping : IEntityTypeConfiguration<ModeloDeEquipamento>
    {
        public void Configure(EntityTypeBuilder<ModeloDeEquipamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FabricanteId)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

               builder.HasOne(s => s.Fabricante)
               .WithMany(t => t.ModeloDeEquipamentos)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
