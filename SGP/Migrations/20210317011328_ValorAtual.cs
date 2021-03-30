using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Migrations
{
    public partial class ValorAtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Classificacoes",
                columns: table => new
                {
                    ClassificacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    taxa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacoes", x => x.ClassificacaoID);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorID);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    ResponsavelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.ResponsavelID);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    SetorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.SetorID);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoID = table.Column<int>(type: "int", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    ClassificacaoID = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorDeCompra = table.Column<double>(type: "float", nullable: false),
                    ValorAtual = table.Column<double>(type: "float", nullable: false),
                    DataDeCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FornecedorID = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsavelID = table.Column<int>(type: "int", nullable: false),
                    SetorID = table.Column<int>(type: "int", nullable: false),
                    EstadoDeConservacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoID);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Classificacoes_ClassificacaoID",
                        column: x => x.ClassificacaoID,
                        principalTable: "Classificacoes",
                        principalColumn: "ClassificacaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Fornecedores_FornecedorID",
                        column: x => x.FornecedorID,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Responsaveis_ResponsavelID",
                        column: x => x.ResponsavelID,
                        principalTable: "Responsaveis",
                        principalColumn: "ResponsavelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Setores_SetorID",
                        column: x => x.SetorID,
                        principalTable: "Setores",
                        principalColumn: "SetorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_CategoriaID",
                table: "Equipamentos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ClassificacaoID",
                table: "Equipamentos",
                column: "ClassificacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_FornecedorID",
                table: "Equipamentos",
                column: "FornecedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ResponsavelID",
                table: "Equipamentos",
                column: "ResponsavelID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_SetorID",
                table: "Equipamentos",
                column: "SetorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Classificacoes");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Setores");
        }
    }
}
