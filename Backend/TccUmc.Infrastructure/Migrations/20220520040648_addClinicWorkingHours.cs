using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccUmc.Infrastructure.Migrations
{
    public partial class addClinicWorkingHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_WorkingHours_WorkingHoursId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_WorkingHoursId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "WorkingHoursId",
                table: "Clinics");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "WorkingHours",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_ClinicId",
                table: "WorkingHours",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Clinics_ClinicId",
                table: "WorkingHours",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Clinics_ClinicId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_ClinicId",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "WorkingHours");

            migrationBuilder.AddColumn<int>(
                name: "WorkingHoursId",
                table: "Clinics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_WorkingHoursId",
                table: "Clinics",
                column: "WorkingHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_WorkingHours_WorkingHoursId",
                table: "Clinics",
                column: "WorkingHoursId",
                principalTable: "WorkingHours",
                principalColumn: "Id");
        }
    }
}
