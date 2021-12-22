using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Migrations
{
    public partial class RelacionamentoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_RELACIONAMENTO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(type: "BIGINT", nullable: false),
                    FuncionarioId = table.Column<long>(type: "BIGINT", nullable: false),
                    observacao = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    finalizado = table.Column<string>(type: "CHAR(1)", nullable: false),
                    dtInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtRetorno = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RELACIONAMENTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_RELACIONAMENTO_TB_CLIENTE_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RELACIONAMENTO_TB_FUNCIONARIO_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TB_FUNCIONARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_RELACIONAMENTO_ClienteId",
                table: "TB_RELACIONAMENTO",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RELACIONAMENTO_FuncionarioId",
                table: "TB_RELACIONAMENTO",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_RELACIONAMENTO");
        }
    }
}
