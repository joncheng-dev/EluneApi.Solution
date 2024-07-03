using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EluneApi.Migrations
{
    public partial class UpdateAdditionalSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SleepTimes",
                columns: new[] { "SleepTimeId", "BabyId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2024, 7, 4, 6, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 3, 22, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 3, new DateTime(2024, 7, 3, 4, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 2, 19, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 4, new DateTime(2024, 7, 3, 7, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 2, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 5, new DateTime(2024, 7, 3, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SleepTimes",
                keyColumn: "SleepTimeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SleepTimes",
                keyColumn: "SleepTimeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SleepTimes",
                keyColumn: "SleepTimeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SleepTimes",
                keyColumn: "SleepTimeId",
                keyValue: 6);
        }
    }
}
