using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class ajoutdeprojet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "NoteP",
                columns: table => new
                {
                    NotePId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotePDescription = table.Column<string>(nullable: true),
                    NotePDate = table.Column<DateTime>(nullable: false),
                    ProjetNoteProjetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteP", x => x.NotePId);
                    table.ForeignKey(
                        name: "FK_NoteP_Projets_ProjetNoteProjetId",
                        column: x => x.ProjetNoteProjetId,
                        principalTable: "Projets",
                        principalColumn: "ProjetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteP_ProjetNoteProjetId",
                table: "NoteP",
                column: "ProjetNoteProjetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteP");

            migrationBuilder.DropTable(
                name: "Projets");
        }
    }
}
