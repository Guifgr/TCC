using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccBackendUmc.Infrastructure.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionLevelEnum",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "PermissionLevelEnum",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "PermissionLevelEnum",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Clinics",
                newName: "Whatsapp");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Professionals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalDoc",
                table: "Professionals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Clinics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingHoursId",
                table: "Clinics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClinicId",
                table: "Users",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_Guid",
                table: "Professionals",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Guid",
                table: "Clinics",
                column: "Guid",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                table: "Users",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_WorkingHours_WorkingHoursId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clinics_ClinicId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClinicId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_Guid",
                table: "Professionals");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_Guid",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_WorkingHoursId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfessionalDoc",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "WorkingHoursId",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "PermissionLevelEnum");

            migrationBuilder.RenameColumn(
                name: "Whatsapp",
                table: "Clinics",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Professionals",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<int>(
                name: "PermissionLevelEnum",
                table: "Professionals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Clinics",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<int>(
                name: "PermissionLevelEnum",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
