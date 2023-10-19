using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickest.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoId1",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DepartamentoId1",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DepartamentoId1",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId1",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoId1",
                table: "Usuarios",
                column: "DepartamentoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoId1",
                table: "Usuarios",
                column: "DepartamentoId1",
                principalTable: "Departamentos",
                principalColumn: "Id");
        }
    }
}
