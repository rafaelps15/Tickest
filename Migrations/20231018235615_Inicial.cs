using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickest.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketFases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketFases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Departamentos_DepartamentoId1",
                        column: x => x.DepartamentoId1,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Título = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Anexo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    AnalistaId = table.Column<int>(type: "int", nullable: false),
                    AbertoPorId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Usuarios_AbertoPorId",
                        column: x => x.AbertoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Usuarios_AnalistaId",
                        column: x => x.AnalistaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Usuarios_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEspecialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalistaId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEspecialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEspecialidades_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEspecialidades_Usuarios_AnalistaId",
                        column: x => x.AnalistaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Anexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endereco = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anexos_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_TicketId",
                table: "Anexos",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_DepartamentoId",
                table: "Especialidades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AbertoPorId",
                table: "Tickets",
                column: "AbertoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AnalistaId",
                table: "Tickets",
                column: "AnalistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartamentoId",
                table: "Tickets",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SolicitanteId",
                table: "Tickets",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEspecialidades_AnalistaId",
                table: "UsuarioEspecialidades",
                column: "AnalistaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEspecialidades_EspecialidadeId",
                table: "UsuarioEspecialidades",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoId",
                table: "Usuarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoId1",
                table: "Usuarios",
                column: "DepartamentoId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anexos");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "TicketFases");

            migrationBuilder.DropTable(
                name: "UsuarioEspecialidades");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
