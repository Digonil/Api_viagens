using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoViagens.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_destinos",
                table: "destinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_depoimentos",
                table: "depoimentos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "destinos");

            migrationBuilder.RenameTable(
                name: "destinos",
                newName: "Destinos");

            migrationBuilder.RenameTable(
                name: "depoimentos",
                newName: "Depoimentos");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Destinos",
                newName: "TextoDescritivo");

            migrationBuilder.AddColumn<string>(
                name: "Foto1",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Foto2",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depoimentos",
                table: "Depoimentos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depoimentos",
                table: "Depoimentos");

            migrationBuilder.DropColumn(
                name: "Foto1",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Foto2",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destinos");

            migrationBuilder.RenameTable(
                name: "Destinos",
                newName: "destinos");

            migrationBuilder.RenameTable(
                name: "Depoimentos",
                newName: "depoimentos");

            migrationBuilder.RenameColumn(
                name: "TextoDescritivo",
                table: "destinos",
                newName: "Foto");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "destinos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_destinos",
                table: "destinos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_depoimentos",
                table: "depoimentos",
                column: "Id");
        }
    }
}
