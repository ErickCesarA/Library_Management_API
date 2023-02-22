using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_ManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class ILibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksPropety",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookResume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookGenres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookPublisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookEdition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookPublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bookCopies = table.Column<int>(type: "int", nullable: false),
                    bookPgNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksPropety", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksPropety");
        }
    }
}
