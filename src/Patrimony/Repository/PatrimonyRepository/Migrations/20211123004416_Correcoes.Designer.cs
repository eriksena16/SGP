// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGP.Patrimony.Repository.PatrimonyRepository;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    [DbContext(typeof(SGPContext))]
    [Migration("20211123004416_Correcoes")]
    partial class Correcoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGP.Model.Entity.CategoriaDoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("SGP.Model.Entity.ClassificacaoDeAtivos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TaxaDeDepreciacao")
                        .HasColumnType("int");

                    b.Property<int>("VidaUtil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classificacao");
                });

            modelBuilder.Entity("SGP.Model.Entity.Equipamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoriaDoItemId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClassificacaoDeAtivosId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataDeCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoDeConservacao")
                        .HasColumnType("int");

                    b.Property<long>("ModeloDeEquipamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("NotaFiscalUrl")
                        .HasColumnType("varchar(100)");

                    b.Property<long>("NumeroDePatrmonio")
                        .HasColumnType("bigint");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(100)");

                    b.Property<long>("ResponsavelDoEquipamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Serie")
                        .HasColumnType("varchar(100)");

                    b.Property<long>("SetorId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorAtual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorDeCompra")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaDoItemId");

                    b.HasIndex("ClassificacaoDeAtivosId");

                    b.HasIndex("ModeloDeEquipamentoId");

                    b.HasIndex("ResponsavelDoEquipamentoId");

                    b.HasIndex("SetorId");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.Fabricante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("SGP.Model.Entity.ModeloDeEquipamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FabricanteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.ToTable("ModeloDeEquipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.ResponsavelDoEquipamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ResponsavelDoEquipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.Setor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("SGP.Model.Entity.Equipamento", b =>
                {
                    b.HasOne("SGP.Model.Entity.CategoriaDoItem", "CategoriaDoItem")
                        .WithMany()
                        .HasForeignKey("CategoriaDoItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.ClassificacaoDeAtivos", "ClassificacaoDeAtivos")
                        .WithMany("Equipamento")
                        .HasForeignKey("ClassificacaoDeAtivosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.ModeloDeEquipamento", "ModeloDeEquipamento")
                        .WithMany()
                        .HasForeignKey("ModeloDeEquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.ResponsavelDoEquipamento", "ResponsavelDoEquipamento")
                        .WithMany("Equipamento")
                        .HasForeignKey("ResponsavelDoEquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.Setor", "Setor")
                        .WithMany("Equipamento")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaDoItem");

                    b.Navigation("ClassificacaoDeAtivos");

                    b.Navigation("ModeloDeEquipamento");

                    b.Navigation("ResponsavelDoEquipamento");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("SGP.Model.Entity.ModeloDeEquipamento", b =>
                {
                    b.HasOne("SGP.Model.Entity.Fabricante", "Fabricante")
                        .WithMany("ModeloDeEquipamento")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("SGP.Model.Entity.ClassificacaoDeAtivos", b =>
                {
                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.Fabricante", b =>
                {
                    b.Navigation("ModeloDeEquipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.ResponsavelDoEquipamento", b =>
                {
                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.Setor", b =>
                {
                    b.Navigation("Equipamento");
                });
#pragma warning restore 612, 618
        }
    }
}
