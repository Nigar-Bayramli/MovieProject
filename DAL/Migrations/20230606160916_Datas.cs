using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "Email", "EmailConfirmed", "FullName", "IsDeleted", "Password", "Roles", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@etickets.com", true, "Leyla", false, "Leyla123", 1, "Selimli" },
                    { 2, "kamran@gmail.com", true, "Kamran", false, "Admin123", 2, "Ehmedli" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Description", "IsDeleted", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, "This is the description of the first cinema", false, "http://dotnethow.net/images/cinemas/cinema-1.jpeg", "Cinema 1" },
                    { 2, "This is the description of the first cinema", false, "http://dotnethow.net/images/cinemas/cinema-2.jpeg", "Cinema 2" },
                    { 3, "This is the description of the first cinema", false, "http://dotnethow.net/images/cinemas/cinema-3.jpeg", "Cinema 3" },
                    { 4, "This is the description of the first cinema", false, "http://dotnethow.net/images/cinemas/cinema-4.jpeg", "Cinema 4" },
                    { 5, "This is the description of the first cinema", false, "http://dotnethow.net/images/cinemas/cinema-5.jpeg", "Cinema 5" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Bio", "FullName", "IsDeleted", "ProfilePictureURL" },
                values: new object[,]
                {
                    { 1, "This is the Bio of the first ", "Producer 1", false, "http://dotnethow.net/images/producers/producer-1.jpeg" },
                    { 2, "This is the Bio of the second ", "Producer 2", false, "http://dotnethow.net/images/producers/producer-2.jpeg" },
                    { 3, "This is the Bio of the second ", "Producer 3", false, "http://dotnethow.net/images/producers/producer-3.jpeg" },
                    { 4, "This is the Bio of the second ", "Producer 4", false, "http://dotnethow.net/images/producers/producer-4.jpeg" },
                    { 5, "This is the Bio of the second ", "Producer 5", false, "http://dotnethow.net/images/producers/producer-5.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CinemaId", "Description", "EndDate", "ImageURL", "IsDeleted", "MovieCategory", "Name", "Price", "ProducerId", "StartDate" },
                values: new object[,]
                {
                    { 1, 3, "This is the Life movie description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://dotnethow.net/images/movies/movie-3.jpeg", false, 4, "Life", 39.5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "This is the Shawshank Redemption description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://dotnethow.net/images/movies/movie-1.jpeg", false, 1, "The Shawshank Redemption", 29.5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, "This is the Ghost movie description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://dotnethow.net/images/movies/movie-4.jpeg", false, 6, "Ghost", 39.5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "This is the Race movie description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://dotnethow.net/images/movies/movie-6.jpeg", false, 4, "Race", 39.5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, "This is the Scoob movie description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://dotnethow.net/images/movies/movie-7.jpeg", false, 5, "Scoob", 39.5, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, "This is the Cold Soles movie description", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://dotnethow.net/images/movies/movie-8.jpeg", false, 3, "Cold Soles", 39.5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
