using Microsoft.EntityFrameworkCore;
using SGP.Model.Entity;

namespace SGP.Patrimony.Repository.PatrimonyRepository
{
    public class SGPContext : DbContext
    {
        public SGPContext(DbContextOptions<SGPContext> options)
            : base(options)
        {
        }
       /* private readonly StreamWriter _logStream = new StreamWriter("mylog.txt", append: true);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(_logStream.WriteLine).EnableSensitiveDataLogging();

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }*/

        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<CategoriaDoItem> Categoria { get; set; }
        public DbSet<ClassificacaoDeAtivos> Classificacao { get; set; }
        public DbSet<ModeloDeEquipamento> ModeloDeEquipamento { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<ResponsavelDoEquipamento> ResponsavelDoEquipamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Equipamento>().ToTable("Equipamentos");
            modelBuilder.Entity<Setor>().ToTable("Setores");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Classificacao>().ToTable("Classificacoes");
            modelBuilder.Entity<Modelo>().ToTable("Modelos");
            modelBuilder.Entity<Empresa>().ToTable("Empresas");
            modelBuilder.Entity<Responsavel>().ToTable("Responsaveis");*/

        }

        

    }
}
