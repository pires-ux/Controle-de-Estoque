using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class addmigratontabela2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Produtos",
                type: "int",
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_usuarioId",
                table: "Produtos",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_usuarioId",
                table: "Produtos",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_usuarioId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_usuarioId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Produtos");
        }
    }
}
