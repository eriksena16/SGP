using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Mappings
{
    public class ClassificacaoDeAtivosMapping : IEntityTypeConfiguration<ClassificacaoDeAtivos>
    {
        public void Configure(EntityTypeBuilder<ClassificacaoDeAtivos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(p => p.TaxaDeDepreciacao)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(p => p.VidaUtil)
               .IsRequired()
               .HasColumnType("int");


            builder.HasOne(m => m.Equipamento)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
