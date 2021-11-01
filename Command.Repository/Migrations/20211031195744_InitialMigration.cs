using Microsoft.EntityFrameworkCore.Migrations;

namespace Command.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_COMMAND",
                columns: table => new
                {
                    ID_COMMAND = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_HOW_TO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DS_LINE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DS_PLATFORM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMMAND", x => x.ID_COMMAND);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_COMMAND");
        }
    }
}
