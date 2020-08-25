using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class association : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Idmembre",
                table: "Competences",
                newName: "IdMembre");

            migrationBuilder.CreateTable(
                name: "Associs",
                columns: table => new
                {
                    AssociKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associs", x => x.AssociKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associs");

            migrationBuilder.RenameColumn(
                name: "IdMembre",
                table: "Competences",
                newName: "Idmembre");
        }
    }
}
