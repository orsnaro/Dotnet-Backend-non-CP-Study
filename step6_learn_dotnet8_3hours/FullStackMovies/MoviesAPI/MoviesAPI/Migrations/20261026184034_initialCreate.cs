using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Sci-Fi" },
                    { 3, "Fantasy" },
                    { 4, "Horror" },
                    { 5, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "GenreId", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, "Inception", 12.99m, new DateOnly(2003, 1, 1) },
                    { 2, 1, "The Dark Knight", 125.99m, new DateOnly(2005, 1, 1) },
                    { 3, 2, "Interstellar", 13.99m, new DateOnly(2007, 9, 22) },
                    { 4, 2, "The Matrix", 11.99m, new DateOnly(1999, 1, 17) },
                    { 5, 3, "The Lord of the Rings: The Fellowship of the Ring", 10.99m, new DateOnly(2003, 8, 3) },
                    { 6, 3, "The Lord of the Rings: The Two Towers", 50.99m, new DateOnly(2003, 9, 1) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
