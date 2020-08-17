using Microsoft.EntityFrameworkCore.Migrations;

namespace CaimanProject.Migrations
{
    public partial class initialmigration : Migration
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
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Specialites");
        }
    }
}
