﻿// <auto-generated />
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
    [Migration("20210705034511_Atualizacao2")]
    partial class Atualizacao2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGP.Model.Entity.CategoriaDoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxaDeDepreciacao")
                        .HasColumnType("int");

                    b.Property<int>("VidaUtil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classificacao");
                });

            modelBuilder.Entity("SGP.Model.Entity.Equipamento", b =>
                {
                    b.Property<long>("EquipamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoriaDoItemId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClassificacaoDeAtivosId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataDeCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipamentoStatus")
                        .HasColumnType("int");

                    b.Property<int>("EstadoDeConservacao")
                        .HasColumnType("int");

                    b.Property<long>("FabricanteId")
                        .HasColumnType("bigint");

                    b.Property<long>("ModeloDeEquipamentoId")
                        .HasColumnType("bigint");

                    b.Property<string>("NotaFiscalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumeroDePatrmonio")
                        .HasColumnType("bigint");

                    b.Property<string>("NumeroDeSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ResponsavelDoEquipamentoId")
                        .HasColumnType("bigint");

                    b.Property<long>("SetorId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ValorAtual")
                        .HasColumnType("money");

                    b.Property<decimal>("ValorDeCompra")
                        .HasColumnType("money");

                    b.HasKey("EquipamentoID");

                    b.HasIndex("CategoriaDoItemId");

                    b.HasIndex("ClassificacaoDeAtivosId");

                    b.HasIndex("FabricanteId");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("SGP.Model.Entity.ModeloDeEquipamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<long?>("FabricanteId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId1");

                    b.ToTable("ModeloDeEquipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.ResponsavelDoEquipamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SGP.Model.Entity.Setor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("SGP.Model.Entity.Equipamento", b =>
                {
                    b.HasOne("SGP.Model.Entity.CategoriaDoItem", "CategoriaDoItem")
                        .WithMany("Equipment")
                        .HasForeignKey("CategoriaDoItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.ClassificacaoDeAtivos", "ClassificacaoDeAtivos")
                        .WithMany("Equipamento")
                        .HasForeignKey("ClassificacaoDeAtivosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.Fabricante", "Fabricante")
                        .WithMany("Equipamento")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.ModeloDeEquipamento", "ModeloDeEquipamento")
                        .WithMany("Equipment")
                        .HasForeignKey("ModeloDeEquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.ResponsavelDoEquipamento", "ResponsavelDoEquipamento")
                        .WithMany("Equipment")
                        .HasForeignKey("ResponsavelDoEquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Model.Entity.Setor", "Setor")
                        .WithMany("Equipment")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaDoItem");

                    b.Navigation("ClassificacaoDeAtivos");

                    b.Navigation("Fabricante");

                    b.Navigation("ModeloDeEquipamento");

                    b.Navigation("ResponsavelDoEquipamento");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("SGP.Model.Entity.ModeloDeEquipamento", b =>
                {
                    b.HasOne("SGP.Model.Entity.Fabricante", "Fabricante")
                        .WithMany("ModeloDeEquipamento")
                        .HasForeignKey("FabricanteId1");

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("SGP.Model.Entity.CategoriaDoItem", b =>
                {
                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("SGP.Model.Entity.ClassificacaoDeAtivos", b =>
                {
                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.Fabricante", b =>
                {
                    b.Navigation("Equipamento");

                    b.Navigation("ModeloDeEquipamento");
                });

            modelBuilder.Entity("SGP.Model.Entity.ModeloDeEquipamento", b =>
                {
                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("SGP.Model.Entity.ResponsavelDoEquipamento", b =>
                {
                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("SGP.Model.Entity.Setor", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
