using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaVoluntariado.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaAtuacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_Instituicoes_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosHabilidades",
                columns: table => new
                {
                    VoluntarioId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariosHabilidades", x => new { x.VoluntarioId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_VoluntariosHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoluntariosHabilidades_Voluntarios_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadesAtividades",
                columns: table => new
                {
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadesAtividades", x => new { x.AtividadeId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_HabilidadesAtividades_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadesAtividades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosAtividades",
                columns: table => new
                {
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    VoluntarioId = table.Column<int>(type: "int", nullable: false),
                    DataInscricaoAtividade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariosAtividades", x => new { x.AtividadeId, x.VoluntarioId });
                    table.ForeignKey(
                        name: "FK_VoluntariosAtividades_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoluntariosAtividades_Voluntarios_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_InstituicaoId",
                table: "Atividades",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadesAtividades_HabilidadeId",
                table: "HabilidadesAtividades",
                column: "HabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariosAtividades_VoluntarioId",
                table: "VoluntariosAtividades",
                column: "VoluntarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariosHabilidades_HabilidadeId",
                table: "VoluntariosHabilidades",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabilidadesAtividades");

            migrationBuilder.DropTable(
                name: "VoluntariosAtividades");

            migrationBuilder.DropTable(
                name: "VoluntariosHabilidades");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "Instituicoes");
        }
    }
}
