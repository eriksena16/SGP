using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classificacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxaDeDepreciacao = table.Column<int>(type: "int", nullable: false),
                    VidaUtil = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloDeEquipamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricanteId = table.Column<int>(type: "int", nullable: false),
                    FabricanteId1 = table.Column<long>(type: "bigint", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloDeEquipamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloDeEquipamento_Fabricante_FabricanteId1",
                        column: x => x.FabricanteId1,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDePatrmonio = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaDoItemID = table.Column<int>(type: "int", nullable: false),
                    CategoriaDoItemId = table.Column<long>(type: "bigint", nullable: true),
                    ClassificacaoDeAtivosID = table.Column<int>(type: "int", nullable: false),
                    ClassificacaoDeAtivosId = table.Column<long>(type: "bigint", nullable: true),
                    NotaFiscalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorDeCompra = table.Column<decimal>(type: "money", nullable: false),
                    ValorAtual = table.Column<decimal>(type: "money", nullable: false),
                    DataDeCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModeloDeEquipamentoID = table.Column<int>(type: "int", nullable: false),
                    ModeloDeEquipamentoId = table.Column<long>(type: "bigint", nullable: true),
                    FabricanteID = table.Column<int>(type: "int", nullable: false),
                    FabricanteId = table.Column<long>(type: "bigint", nullable: true),
                    NumeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipamentoStatus = table.Column<int>(type: "int", nullable: false),
                    ResponsavelDoEquipamentoID = table.Column<int>(type: "int", nullable: false),
                    ResponsavelDoEquipamentoId = table.Column<long>(type: "bigint", nullable: true),
                    SetorID = table.Column<int>(type: "int", nullable: false),
                    SetorId = table.Column<long>(type: "bigint", nullable: true),
                    EstadoDeConservacao = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoID);
                    table.ForeignKey(
                        name: "FK_Equipamento_Categoria_CategoriaDoItemId",
                        column: x => x.CategoriaDoItemId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_Classificacao_ClassificacaoDeAtivosId",
                        column: x => x.ClassificacaoDeAtivosId,
                        principalTable: "Classificacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_ModeloDeEquipamento_ModeloDeEquipamentoId",
                        column: x => x.ModeloDeEquipamentoId,
                        principalTable: "ModeloDeEquipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_User_ResponsavelDoEquipamentoId",
                        column: x => x.ResponsavelDoEquipamentoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CategoriaDoItemId",
                table: "Equipamento",
                column: "CategoriaDoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ClassificacaoDeAtivosId",
                table: "Equipamento",
                column: "ClassificacaoDeAtivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_FabricanteId",
                table: "Equipamento",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ModeloDeEquipamentoId",
                table: "Equipamento",
                column: "ModeloDeEquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ResponsavelDoEquipamentoId",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_SetorId",
                table: "Equipamento",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloDeEquipamento_FabricanteId1",
                table: "ModeloDeEquipamento",
                column: "FabricanteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Classificacao");

            migrationBuilder.DropTable(
                name: "ModeloDeEquipamento");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Fabricante");
        }
    }
}
