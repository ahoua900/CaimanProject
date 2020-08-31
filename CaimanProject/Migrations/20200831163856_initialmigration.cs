using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    CompetenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetenceName = table.Column<string>(nullable: true),
                    IdMembre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.CompetenceId);
                });

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
                    IsActif = table.Column<bool>(nullable: false),
                    IsSelecte = table.Column<bool>(nullable: false),
                    MemberCommune = table.Column<string>(nullable: true),
                    MemberQuartier = table.Column<string>(nullable: true),
                    MemberMissonFin = table.Column<int>(nullable: false),
                    MemberMissionActive = table.Column<int>(nullable: false),
                    MemberNote = table.Column<int>(nullable: false),
                    Specialite = table.Column<string>(nullable: true),
                    Transport = table.Column<string>(nullable: true),
                    ProjetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "NotePs",
                columns: table => new
                {
                    NotePId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotePDescription = table.Column<string>(nullable: true),
                    NotePDate = table.Column<DateTime>(nullable: false),
                    ProjetNote = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotePs", x => x.NotePId);
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
                    IsArchieved = table.Column<bool>(nullable: false),
                    BilanProjet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.ProjetId);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkName = table.Column<string>(nullable: true),
                    NetworkLink = table.Column<string>(nullable: true),
                    Idmember = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.SocialNetworkId);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associs");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "NotePs");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "Specialites");
        }
    }
}
