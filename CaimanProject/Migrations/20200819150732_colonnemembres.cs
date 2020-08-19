using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class colonnemembres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(nullable: true),
                    ContactPname = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: false),
                    ContactSite = table.Column<string>(nullable: true),
                    ContactFonction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    ProjetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetName = table.Column<string>(nullable: true),
                    ProjetDateDebut = table.Column<DateTime>(nullable: false),
                    ProjetDateFin = table.Column<DateTime>(nullable: false),
                    ProjetDescription = table.Column<string>(nullable: true),
                    ProjetProgressBar = table.Column<int>(nullable: false),
                    ProjetCahierCharge = table.Column<string>(nullable: true),
                    ProjetMoney = table.Column<int>(nullable: false),
                    BilanProjet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.ProjetId);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    SpecialiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialiteName = table.Column<string>(nullable: true),
                    SpecialiteColor = table.Column<string>(nullable: true),
                    SpecialiteDescription = table.Column<string>(nullable: true),
                    ImageSpecialité = table.Column<string>(nullable: true),
                    Url_Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.SpecialiteId);
                });

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
                    Specialite = table.Column<string>(nullable: true),
                    Transport = table.Column<string>(nullable: true),
                    Ischecked = table.Column<bool>(nullable: false),
                    ProjetIds = table.Column<int>(nullable: false),
                    ProjetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "ProjetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ProjetId",
                table: "Members",
                column: "ProjetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Specialites");

            migrationBuilder.DropTable(
                name: "Projets");
        }
    }
}
