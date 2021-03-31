using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Migrations
{
    public partial class ClassificacaoVidaUtil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VidaUtil",
                table: "Classificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VidaUtil",
                table: "Classificacoes");
        }
    }
}
