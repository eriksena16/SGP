﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGP.Data;

namespace SGP.Migrations
{
    [DbContext(typeof(SGPContext))]
    partial class SGPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGP.Models.Categorias.Categoria", b =>
                {
                    b.Property<int>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SGP.Models.Classificacoes.Classificacao", b =>
                {
                    b.Property<int>("ClassificacaoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("taxa")
                        .HasColumnType("int");

                    b.HasKey("ClassificacaoID");

                    b.ToTable("Classificacoes");
                });

            modelBuilder.Entity("SGP.Models.Equipamentos.Equipamento", b =>
                {
                    b.Property<int>("EquipamentoID")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<int>("ClassificacaoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDeCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoDeConservacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FornecedorID")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsavelID")
                        .HasColumnType("int");

                    b.Property<string>("Serie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SetorID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorAtual")
                        .HasColumnType("float");

                    b.Property<double>("ValorDeCompra")
                        .HasColumnType("float");

                    b.HasKey("EquipamentoID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("ClassificacaoID");

                    b.HasIndex("FornecedorID");

                    b.HasIndex("ResponsavelID");

                    b.HasIndex("SetorID");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("SGP.Models.Fornecedores.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FornecedorID");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("SGP.Models.Responsaveis.Responsavel", b =>
                {
                    b.Property<int>("ResponsavelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResponsavelID");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("SGP.Models.Setores.Setor", b =>
                {
                    b.Property<int>("SetorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SetorID");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("SGP.Models.Equipamentos.Equipamento", b =>
                {
                    b.HasOne("SGP.Models.Categorias.Categoria", "Categoria")
                        .WithMany("Equipamentos")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Models.Classificacoes.Classificacao", "Classificacao")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ClassificacaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Models.Fornecedores.Fornecedor", "Fornecedor")
                        .WithMany("Equipamentos")
                        .HasForeignKey("FornecedorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Models.Responsaveis.Responsavel", "Responsavel")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ResponsavelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGP.Models.Setores.Setor", "Setor")
                        .WithMany("Equipamentos")
                        .HasForeignKey("SetorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Classificacao");

                    b.Navigation("Fornecedor");

                    b.Navigation("Responsavel");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("SGP.Models.Categorias.Categoria", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SGP.Models.Classificacoes.Classificacao", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SGP.Models.Fornecedores.Fornecedor", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SGP.Models.Responsaveis.Responsavel", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SGP.Models.Setores.Setor", b =>
                {
                    b.Navigation("Equipamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
