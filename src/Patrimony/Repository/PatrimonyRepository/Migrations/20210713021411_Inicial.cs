using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Classificacao",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxaDeDepreciacao = table.Column<int>(type: "int", nullable: false),
                    VidaUtil = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
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
                    table.PrimaryKey("PK_Fabricante", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModeloDeEquipamento",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricanteID = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloDeEquipamento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModeloDeEquipamento_Fabricante_FabricanteID",
                        column: x => x.FabricanteID,
                        principalTable: "Fabricante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDePatrmonio = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaDoItemID = table.Column<long>(type: "bigint", nullable: false),
                    ClassificacaoDeAtivosID = table.Column<long>(type: "bigint", nullable: false),
                    NotaFiscalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorDeCompra = table.Column<decimal>(type: "money", nullable: false),
                    ValorAtual = table.Column<decimal>(type: "money", nullable: false),
                    DataDeCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModeloDeEquipamentoID = table.Column<long>(type: "bigint", nullable: false),
                    FabricanteID = table.Column<long>(type: "bigint", nullable: false),
                    NumeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipamentoStatus = table.Column<int>(type: "int", nullable: false),
                    ResponsavelDoEquipamentoID = table.Column<long>(type: "bigint", nullable: false),
                    SetorID = table.Column<long>(type: "bigint", nullable: false),
                    EstadoDeConservacao = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoID);
                    table.ForeignKey(
                        name: "FK_Equipamento_Categoria_CategoriaDoItemID",
                        column: x => x.CategoriaDoItemID,
                        principalTable: "Categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_Classificacao_ClassificacaoDeAtivosID",
                        column: x => x.ClassificacaoDeAtivosID,
                        principalTable: "Classificacao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_Fabricante_FabricanteID",
                        column: x => x.FabricanteID,
                        principalTable: "Fabricante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_ModeloDeEquipamento_ModeloDeEquipamentoID",
                        column: x => x.ModeloDeEquipamentoID,
                        principalTable: "ModeloDeEquipamento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Equipamento_Setor_SetorID",
                        column: x => x.SetorID,
                        principalTable: "Setor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_User_ResponsavelDoEquipamentoID",
                        column: x => x.ResponsavelDoEquipamentoID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CategoriaDoItemID",
                table: "Equipamento",
                column: "CategoriaDoItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ClassificacaoDeAtivosID",
                table: "Equipamento",
                column: "ClassificacaoDeAtivosID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_FabricanteID",
                table: "Equipamento",
                column: "FabricanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ModeloDeEquipamentoID",
                table: "Equipamento",
                column: "ModeloDeEquipamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ResponsavelDoEquipamentoID",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_SetorID",
                table: "Equipamento",
                column: "SetorID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloDeEquipamento_FabricanteID",
                table: "ModeloDeEquipamento",
                column: "FabricanteID");
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
