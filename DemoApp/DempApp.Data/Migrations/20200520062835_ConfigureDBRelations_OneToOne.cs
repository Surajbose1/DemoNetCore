using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DempApp.Data.Migrations
{
    public partial class ConfigureDBRelations_OneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBiography",
                columns: table => new
                {
                    AuthorBiographyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Biography = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    AuthorRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBiography", x => x.AuthorBiographyId);
                    table.ForeignKey(
                        name: "FK_AuthorBiography_Author_AuthorRef",
                        column: x => x.AuthorRef,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBiography_AuthorRef",
                table: "AuthorBiography",
                column: "AuthorRef",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBiography");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
