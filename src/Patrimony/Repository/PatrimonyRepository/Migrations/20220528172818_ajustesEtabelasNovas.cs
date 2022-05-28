using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    public partial class ajustesEtabelasNovas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelDoEquipamentoId",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "EstadoDeConservacao",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Equipamento");

            migrationBuilder.RenameColumn(
                name: "ResponsavelDoEquipamentoId",
                table: "Equipamento",
                newName: "ResponsavelId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamento_ResponsavelDoEquipamentoId",
                table: "Equipamento",
                newName: "IX_Equipamento_ResponsavelId");

            migrationBuilder.AddColumn<long>(
                name: "GrupoId",
                table: "ResponsavelDoEquipamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Equipamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Observacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    EquipamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observacao_Equipamento_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observacao_EquipamentoId",
                table: "Observacao",
                column: "EquipamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelId",
                table: "Equipamento",
                column: "ResponsavelId",
                principalTable: "ResponsavelDoEquipamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelId",
                table: "Equipamento");

            migrationBuilder.DropTable(
                name: "Observacao");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "ResponsavelDoEquipamento");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Equipamento");

            migrationBuilder.RenameColumn(
                name: "ResponsavelId",
                table: "Equipamento",
                newName: "ResponsavelDoEquipamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamento_ResponsavelId",
                table: "Equipamento",
                newName: "IX_Equipamento_ResponsavelDoEquipamentoId");

            migrationBuilder.AddColumn<int>(
                name: "EstadoDeConservacao",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Equipamento",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelDoEquipamentoId",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoId",
                principalTable: "ResponsavelDoEquipamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
