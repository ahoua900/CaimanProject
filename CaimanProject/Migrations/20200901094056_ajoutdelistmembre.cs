using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class ajoutdelistmembre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Projets_ProjetId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ProjetId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associs",
                table: "Associs");

            migrationBuilder.DropColumn(
                name: "ProjetId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AssociKey",
                table: "Associs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associs",
                table: "Associs",
                columns: new[] { "MemberId", "ProjetId" });

            migrationBuilder.CreateIndex(
                name: "IX_Associs_ProjetId",
                table: "Associs",
                column: "ProjetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associs_Members_MemberId",
                table: "Associs",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associs_Projets_ProjetId",
                table: "Associs",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "ProjetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associs_Members_MemberId",
                table: "Associs");

            migrationBuilder.DropForeignKey(
                name: "FK_Associs_Projets_ProjetId",
                table: "Associs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associs",
                table: "Associs");

            migrationBuilder.DropIndex(
                name: "IX_Associs_ProjetId",
                table: "Associs");

            migrationBuilder.AddColumn<int>(
                name: "ProjetId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssociKey",
                table: "Associs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associs",
                table: "Associs",
                column: "AssociKey");

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
    }
}
