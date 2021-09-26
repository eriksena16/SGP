using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    public partial class Responsavel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoId",
                table: "Equipamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "ResponsavelDoEquipamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsavelDoEquipamento",
                table: "ResponsavelDoEquipamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelDoEquipamentoId",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoId",
                principalTable: "ResponsavelDoEquipamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelDoEquipamentoId",
                table: "Equipamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsavelDoEquipamento",
                table: "ResponsavelDoEquipamento");

            migrationBuilder.RenameTable(
                name: "ResponsavelDoEquipamento",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoId",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
