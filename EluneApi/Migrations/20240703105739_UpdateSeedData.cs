using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EluneApi.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SleepTimes",
                columns: table => new
                {
                    SleepTimeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BabyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SleepTimes", x => x.SleepTimeId);
                    table.ForeignKey(
                        name: "FK_SleepTimes_Babies_BabyId",
                        column: x => x.BabyId,
                        principalTable: "Babies",
                        principalColumn: "BabyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SleepTimes",
                columns: new[] { "SleepTimeId", "BabyId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 2, 5, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 1, 20, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 1, new DateTime(2024, 7, 3, 6, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 2, 21, 30, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SleepTimes_BabyId",
                table: "SleepTimes",
                column: "BabyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SleepTimes");
        }
    }
}
