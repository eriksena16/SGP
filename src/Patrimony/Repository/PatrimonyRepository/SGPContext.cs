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

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<Sector> Sector { get; set; }

        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<AssetClassification> AssetClassification { get; set; }
        public DbSet<EquipmentModel> EquipmentModel { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Responsible> Responsible { get; set; }

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
