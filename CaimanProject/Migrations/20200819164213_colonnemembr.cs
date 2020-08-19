using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class colonnemembr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Projets_ProjetId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ProjetId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Ischecked",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ProjetId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ProjetIds",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "Associs",
                columns: table => new
                {
                    ProjetId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associs", x => new { x.ProjetId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_Associs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Associs_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "ProjetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Associs_MemberId",
                table: "Associs",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associs");

            migrationBuilder.AddColumn<bool>(
                name: "Ischecked",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProjetId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetIds",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
