using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infra.Migrations
{
    public partial class ClienteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    cpf = table.Column<float>(type: "FLOAT(11)", maxLength: 11, nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    telefone = table.Column<float>(type: "FLOAT(20)", maxLength: 20, nullable: false),
                    ativo = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLIENTE");
        }
    }
}
