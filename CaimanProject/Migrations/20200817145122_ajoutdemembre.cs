using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class ajoutdemembre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(nullable: true),
                    MemberPnom = table.Column<string>(nullable: true),
                    MemberSex = table.Column<string>(nullable: true),
                    MemberDescription = table.Column<string>(nullable: true),
                    MemberNaissance = table.Column<DateTime>(nullable: false),
                    MemberLieuNaissance = table.Column<string>(nullable: true),
                    MemberMail = table.Column<string>(nullable: true),
                    MemberPhone = table.Column<int>(nullable: false),
                    MemberImageName = table.Column<string>(nullable: true),
                    MemberIsArchived = table.Column<bool>(nullable: true),
                    MemberStatus = table.Column<string>(nullable: true),
                    MemberCommune = table.Column<string>(nullable: true),
                    MemberQuartier = table.Column<string>(nullable: true),
                    MemberMissonFin = table.Column<int>(nullable: false),
                    MemberMissionActive = table.Column<int>(nullable: false),
                    MemberNote = table.Column<int>(nullable: false),
                    Specialite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
