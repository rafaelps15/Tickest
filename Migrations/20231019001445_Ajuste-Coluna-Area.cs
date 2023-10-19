using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickest.Migrations
{
    /// <inheritdoc />
    public partial class AjusteColunaArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Especialidades",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Especialidades",
                newName: "Area");
        }
    }
}
