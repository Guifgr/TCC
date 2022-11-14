using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccUmc.Infrastructure.Migrations
{
    public partial class AddCLinicProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicProcedureId",
                table: "Professional",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClinicProcedure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSpent = table.Column<double>(type: "float", nullable: false),
                    TimeType = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicProcedure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicProcedure_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professional_ClinicProcedureId",
                table: "Professional",
                column: "ClinicProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicProcedure_ClinicId",
                table: "ClinicProcedure",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicProcedure_Guid",
                table: "ClinicProcedure",
                column: "Guid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Professional_ClinicProcedure_ClinicProcedureId",
                table: "Professional",
                column: "ClinicProcedureId",
                principalTable: "ClinicProcedure",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professional_ClinicProcedure_ClinicProcedureId",
                table: "Professional");

            migrationBuilder.DropTable(
                name: "ClinicProcedure");

            migrationBuilder.DropIndex(
                name: "IX_Professional_ClinicProcedureId",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "ClinicProcedureId",
                table: "Professional");
        }
    }
}
