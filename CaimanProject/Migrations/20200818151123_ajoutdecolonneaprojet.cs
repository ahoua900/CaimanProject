using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class ajoutdecolonneaprojet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjetId",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_ProjetId",
                table: "Members",
                column: "ProjetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Projets_ProjetId",
                table: "Members",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "ProjetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Projets_ProjetId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ProjetId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ProjetId",
                table: "Members");
        }
    }
}
