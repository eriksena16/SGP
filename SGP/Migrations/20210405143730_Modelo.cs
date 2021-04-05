using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Migrations
{
    public partial class Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Equipamentos");

            migrationBuilder.AddColumn<int>(
                name: "ModeloID",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModeloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModeloID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ModeloID",
                table: "Equipamentos",
                column: "ModeloID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Modelos_ModeloID",
                table: "Equipamentos",
                column: "ModeloID",
                principalTable: "Modelos",
                principalColumn: "ModeloID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Modelos_ModeloID",
                table: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_ModeloID",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "ModeloID",
                table: "Equipamentos");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
