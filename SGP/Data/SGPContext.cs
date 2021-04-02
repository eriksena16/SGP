using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGP.Models.Equipamentos;
using SGP.Models.Setores;
using SGP.Models.Categorias;
using SGP.Models.Fornecedores;
using SGP.Models.Responsaveis;
using SGP.Models.Classificacoes;
using System.IO;

namespace SGP.Data
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

        public DbSet<SGP.Models.Equipamentos.Equipamento> Equipamentos { get; set; }

        public DbSet<SGP.Models.Setores.Setor> Setor { get; set; }

        public DbSet<SGP.Models.Categorias.Categoria> Categoria { get; set; }
        public DbSet<SGP.Models.Classificacoes.Classificacao> Classificacao { get; set; }

        public DbSet<SGP.Models.Fornecedores.Fornecedor> Fornecedores { get; set; }

        public DbSet<SGP.Models.Responsaveis.Responsavel> Responsavel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipamento>().ToTable("Equipamentos");
            modelBuilder.Entity<Setor>().ToTable("Setores");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Classificacao>().ToTable("Classificacoes");
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedores");
            modelBuilder.Entity<Responsavel>().ToTable("Responsaveis");

        }

        

    }
}
