using Microsoft.EntityFrameworkCore;
using SGP.Model.Entity;
using System.Linq;

namespace SGP.Patrimony.Repository.PatrimonyRepository
{
    public class SGPContext : DbContext
    {
        public SGPContext(DbContextOptions<SGPContext> options)
            : base(options)
        {
        }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<CategoriaDoItem> Categoria { get; set; }
        public DbSet<ClassificacaoDeAtivos> Classificacao { get; set; }
        public DbSet<ModeloDeEquipamento> ModeloDeEquipamento { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<ResponsavelDoEquipamento> ResponsavelDoEquipamento { get; set; }
        public DbSet<Observacao> Observacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal))))
                property.SetColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

        

    }
}
