using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccBackendUmc.Infrastructure.Migrations
{
    public partial class UpdateWorkingHoursAddDayoftheweek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "WorkingHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Close",
                table: "WorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "WorkingHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Open",
                table: "WorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "WorkingHours");
        }
    }
}
