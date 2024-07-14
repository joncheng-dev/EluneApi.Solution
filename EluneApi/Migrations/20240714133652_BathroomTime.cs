using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EluneApi.Migrations
{
    public partial class BathroomTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BathroomTime",
                columns: table => new
                {
                    BathroomTimeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPee = table.Column<bool>(type: "boolean", nullable: false),
                    IsPoo = table.Column<bool>(type: "boolean", nullable: false),
                    BabyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BathroomTime", x => x.BathroomTimeId);
                    table.ForeignKey(
                        name: "FK_BathroomTime_Babies_BabyId",
                        column: x => x.BabyId,
                        principalTable: "Babies",
                        principalColumn: "BabyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedingTime",
                columns: table => new
                {
                    FeedingTimeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BabyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingTime", x => x.FeedingTimeId);
                    table.ForeignKey(
                        name: "FK_FeedingTime_Babies_BabyId",
                        column: x => x.BabyId,
                        principalTable: "Babies",
                        principalColumn: "BabyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BathroomTime_BabyId",
                table: "BathroomTime",
                column: "BabyId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingTime_BabyId",
                table: "FeedingTime",
                column: "BabyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BathroomTime");

            migrationBuilder.DropTable(
                name: "FeedingTime");
        }
    }
}
