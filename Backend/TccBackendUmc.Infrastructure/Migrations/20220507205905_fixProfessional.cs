using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccBackendUmc.Infrastructure.Migrations
{
    public partial class fixProfessional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClinicId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Professionals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_ClinicId",
                table: "Professionals",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_Clinics_ClinicId",
                table: "Professionals",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_Clinics_ClinicId",
                table: "Professionals");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_ClinicId",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Professionals");

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClinicId",
                table: "Users",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                table: "Users",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");
        }
    }
}
