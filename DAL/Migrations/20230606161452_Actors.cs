using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Actors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "FullName", "IsDeleted", "ProfilePictureURL" },
                values: new object[,]
                {
                    { 1, "This is the Bio of the first actor", "Actor 1", false, "http://dotnethow.net/images/actors/actor-1.jpeg" },
                    { 2, "This is the Bio of the second actor", "Actor 2", false, "http://dotnethow.net/images/actors/actor-2.jpeg" },
                    { 3, "This is the Bio of the second actor", "Actor 3", false, "http://dotnethow.net/images/actors/actor-3.jpeg" },
                    { 4, "This is the Bio of the second actor", "Actor 4", false, "http://dotnethow.net/images/actors/actor-4.jpeg" },
                    { 5, "This is the Bio of the second actor", "Actor 5", false, "http://dotnethow.net/images/actors/actor-5.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
