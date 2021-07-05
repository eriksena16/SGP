using Microsoft.EntityFrameworkCore.Migrations;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Migrations
{
    public partial class Atualizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Categoria_CategoriaDoItemId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Classificacao_ClassificacaoDeAtivosId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Fabricante_FabricanteId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_ModeloDeEquipamento_ModeloDeEquipamentoId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Setor_SetorId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoId",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "CategoriaDoItemID",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "ClassificacaoDeAtivosID",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "FabricanteID",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "ModeloDeEquipamentoID",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "ResponsavelDoEquipamentoID",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "SetorID",
                table: "Equipamento");

            migrationBuilder.AlterColumn<long>(
                name: "SetorId",
                table: "Equipamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResponsavelDoEquipamentoId",
                table: "Equipamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModeloDeEquipamentoId",
                table: "Equipamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FabricanteId",
                table: "Equipamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClassificacaoDeAtivosId",
                table: "Equipamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CategoriaDoItemId",
                table: "Equipamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Categoria_CategoriaDoItemId",
                table: "Equipamento",
                column: "CategoriaDoItemId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Classificacao_ClassificacaoDeAtivosId",
                table: "Equipamento",
                column: "ClassificacaoDeAtivosId",
                principalTable: "Classificacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Fabricante_FabricanteId",
                table: "Equipamento",
                column: "FabricanteId",
                principalTable: "Fabricante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_ModeloDeEquipamento_ModeloDeEquipamentoId",
                table: "Equipamento",
                column: "ModeloDeEquipamentoId",
                principalTable: "ModeloDeEquipamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Setor_SetorId",
                table: "Equipamento",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoId",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Categoria_CategoriaDoItemId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Classificacao_ClassificacaoDeAtivosId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Fabricante_FabricanteId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_ModeloDeEquipamento_ModeloDeEquipamentoId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Setor_SetorId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoId",
                table: "Equipamento");

            migrationBuilder.AlterColumn<long>(
                name: "SetorId",
                table: "Equipamento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsavelDoEquipamentoId",
                table: "Equipamento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ModeloDeEquipamentoId",
                table: "Equipamento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FabricanteId",
                table: "Equipamento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ClassificacaoDeAtivosId",
                table: "Equipamento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CategoriaDoItemId",
                table: "Equipamento",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaDoItemID",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassificacaoDeAtivosID",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FabricanteID",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModeloDeEquipamentoID",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelDoEquipamentoID",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SetorID",
                table: "Equipamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Categoria_CategoriaDoItemId",
                table: "Equipamento",
                column: "CategoriaDoItemId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Classificacao_ClassificacaoDeAtivosId",
                table: "Equipamento",
                column: "ClassificacaoDeAtivosId",
                principalTable: "Classificacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Fabricante_FabricanteId",
                table: "Equipamento",
                column: "FabricanteId",
                principalTable: "Fabricante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_ModeloDeEquipamento_ModeloDeEquipamentoId",
                table: "Equipamento",
                column: "ModeloDeEquipamentoId",
                principalTable: "ModeloDeEquipamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Setor_SetorId",
                table: "Equipamento",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_User_ResponsavelDoEquipamentoId",
                table: "Equipamento",
                column: "ResponsavelDoEquipamentoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
