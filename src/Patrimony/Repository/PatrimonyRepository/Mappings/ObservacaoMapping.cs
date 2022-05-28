using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Mappings
{
    public class ObservacaoMapping : IEntityTypeConfiguration<Observacao>
    {
        public void Configure(EntityTypeBuilder<Observacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.HasOne(m => m.Equipamento)
            .WithMany(e => e.Observacoes)
            .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
