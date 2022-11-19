using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccUmc.Infrastructure.Migrations
{
    public partial class updateprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultId",
                table: "Procedure",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Procedure",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Procedure_ConsultId",
                table: "Procedure",
                column: "ConsultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Consult_ConsultId",
                table: "Procedure",
                column: "ConsultId",
                principalTable: "Consult",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Consult_ConsultId",
                table: "Procedure");

            migrationBuilder.DropIndex(
                name: "IX_Procedure_ConsultId",
                table: "Procedure");

            migrationBuilder.DropColumn(
                name: "ConsultId",
                table: "Procedure");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Procedure");
        }
    }
}
