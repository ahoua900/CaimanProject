using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class ajoutdetransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Transport",
                table: "Members",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Transport",
                table: "Members");
        }
    }
}
