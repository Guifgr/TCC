using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccBackendUmc.Infrastructure.Migrations
{
    public partial class fixUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clinics_ClinicId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClinicId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClinicId1",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClinicId1",
                table: "Users",
                column: "ClinicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clinics_ClinicId1",
                table: "Users",
                column: "ClinicId1",
                principalTable: "Clinics",
                principalColumn: "Id");
        }
    }
}
