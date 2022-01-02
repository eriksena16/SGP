using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Mappings
{
    public class EquipamentoMapping : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroDePatrmonio)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.CategoriaDoItemId)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.ClassificacaoDeAtivosId)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.ClassificacaoDeAtivosId)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.ModeloDeEquipamentoId)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.ResponsavelDoEquipamentoId)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.SetorId)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.NotaFiscalUrl)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Serie)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Observacao)
                .IsRequired()
                .HasColumnType("varchar(MAX)");

            builder.Property(p => p.ValorAtual)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder.Property(p => p.ValorDeCompra)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder.HasOne(m => m.ModeloDeEquipamento)
            .WithMany(e => e.Equipamentos)
            .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
