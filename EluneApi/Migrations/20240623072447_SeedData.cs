using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EluneApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Babies",
                columns: table => new
                {
                    BabyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Babies", x => x.BabyId);
                });

            migrationBuilder.InsertData(
                table: "Babies",
                columns: new[] { "BabyId", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Stewie Griffin" },
                    { 2, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Maggie Simpson" },
                    { 3, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Tommy Pickles" },
                    { 4, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Baby Groot" },
                    { 5, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Scrappy Doo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Babies");
        }
    }
}
