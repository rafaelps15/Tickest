using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickest.Migrations
{
    /// <inheritdoc />
    public partial class AjusteColunaTitulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Título",
                table: "Tickets",
                newName: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tickets",
                newName: "Título");
        }
    }
}
