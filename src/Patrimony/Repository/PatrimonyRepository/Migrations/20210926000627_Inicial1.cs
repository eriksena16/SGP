using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    public partial class Inicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipamentoModeloDeEquipamento",
                columns: table => new
                {
                    EquipamentosEquipamentoId = table.Column<long>(type: "bigint", nullable: false),
                    ModeloDeEquipamentosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoModeloDeEquipamento", x => new { x.EquipamentosEquipamentoId, x.ModeloDeEquipamentosId });
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentoId = table.Column<long>(type: "bigint", nullable: true),
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
                name: "GenericEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxaDeDepreciacao = table.Column<int>(type: "int", nullable: true),
                    VidaUtil = table.Column<int>(type: "int", nullable: true),
                    FabricanteId = table.Column<long>(type: "bigint", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericEntity_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDePatrmonio = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaDoItemId = table.Column<long>(type: "bigint", nullable: false),
                    ClassificacaoDeAtivosId = table.Column<long>(type: "bigint", nullable: false),
                    NotaFiscalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorDeCompra = table.Column<decimal>(type: "money", nullable: false),
                    ValorAtual = table.Column<decimal>(type: "money", nullable: false),
                    DataDeCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModeloDeEquipamentoId = table.Column<long>(type: "bigint", nullable: false),
                    FabricanteId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipamentoStatus = table.Column<int>(type: "int", nullable: false),
                    ResponsavelDoEquipamentoId = table.Column<long>(type: "bigint", nullable: false),
                    SetorId = table.Column<long>(type: "bigint", nullable: false),
                    EstadoDeConservacao = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaDoItemId1 = table.Column<long>(type: "bigint", nullable: true),
                    ClassificacaoDeAtivosId1 = table.Column<long>(type: "bigint", nullable: true),
                    ResponsavelDoEquipamentoId1 = table.Column<long>(type: "bigint", nullable: true),
                    SetorId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoId);
                    table.ForeignKey(
                        name: "FK_Equipamento_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_CategoriaDoItemId",
                        column: x => x.CategoriaDoItemId,
                        principalTable: "GenericEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_CategoriaDoItemId1",
                        column: x => x.CategoriaDoItemId1,
                        principalTable: "GenericEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_ClassificacaoDeAtivosId",
                        column: x => x.ClassificacaoDeAtivosId,
                        principalTable: "GenericEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_ClassificacaoDeAtivosId1",
                        column: x => x.ClassificacaoDeAtivosId1,
                        principalTable: "GenericEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_ModeloDeEquipamentoId",
                        column: x => x.ModeloDeEquipamentoId,
                        principalTable: "GenericEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_ResponsavelDoEquipamentoId",
                        column: x => x.ResponsavelDoEquipamentoId,
                        principalTable: "GenericEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_ResponsavelDoEquipamentoId1",
                        column: x => x.ResponsavelDoEquipamentoId1,
                        principalTable: "GenericEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_SetorId",
                        column: x => x.SetorId,
                        principalTable: "GenericEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipamento_GenericEntity_SetorId1",
                        column: x => x.SetorId1,
                        principalTable: "GenericEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CategoriaDoItemId",
                table: "Equipamento",
                column: "CategoriaDoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CategoriaDoItemId1",
                table: "Equipamento",
                column: "CategoriaDoItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ClassificacaoDeAtivosId",
                table: "Equipamento",
                column: "ClassificacaoDeAtivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ClassificacaoDeAtivosId1",
                table: "Equipamento",
                column: "ClassificacaoDeAtivosId1");

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
                name: "IX_Equipamento_ResponsavelDoEquipamentoId1",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_SetorId",
                table: "Equipamento",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_SetorId1",
                table: "Equipamento",
                column: "SetorId1");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoModeloDeEquipamento_ModeloDeEquipamentosId",
                table: "EquipamentoModeloDeEquipamento",
                column: "ModeloDeEquipamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabricante_EquipamentoId",
                table: "Fabricante",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericEntity_FabricanteId",
                table: "GenericEntity",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipamentoModeloDeEquipamento_Equipamento_EquipamentosEquipamentoId",
                table: "EquipamentoModeloDeEquipamento",
                column: "EquipamentosEquipamentoId",
                principalTable: "Equipamento",
                principalColumn: "EquipamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipamentoModeloDeEquipamento_GenericEntity_ModeloDeEquipamentosId",
                table: "EquipamentoModeloDeEquipamento",
                column: "ModeloDeEquipamentosId",
                principalTable: "GenericEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fabricante_Equipamento_EquipamentoId",
                table: "Fabricante",
                column: "EquipamentoId",
                principalTable: "Equipamento",
                principalColumn: "EquipamentoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Fabricante_FabricanteId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_GenericEntity_Fabricante_FabricanteId",
                table: "GenericEntity");

            migrationBuilder.DropTable(
                name: "EquipamentoModeloDeEquipamento");

            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "GenericEntity");
        }
    }
}
