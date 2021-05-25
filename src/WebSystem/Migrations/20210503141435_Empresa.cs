using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Migrations
{
    public partial class Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Marcas_MarcaID",
                table: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.RenameColumn(
                name: "taxa",
                table: "Classificacoes",
                newName: "Taxa");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoDeConservacao",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Empresas_MarcaID",
                table: "Equipamentos",
                column: "MarcaID",
                principalTable: "Empresas",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Empresas_MarcaID",
                table: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.RenameColumn(
                name: "Taxa",
                table: "Classificacoes",
                newName: "taxa");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Equipamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoDeConservacao",
                table: "Equipamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Marcas_MarcaID",
                table: "Equipamentos",
                column: "MarcaID",
                principalTable: "Marcas",
                principalColumn: "MarcaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
