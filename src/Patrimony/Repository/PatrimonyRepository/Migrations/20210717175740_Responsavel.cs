using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    public partial class Responsavel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoID",
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
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelDoEquipamentoID",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoID",
                principalTable: "ResponsavelDoEquipamento",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_ResponsavelDoEquipamento_ResponsavelDoEquipamentoID",
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
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoID",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
