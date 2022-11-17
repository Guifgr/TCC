using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccUmc.Infrastructure.Migrations
{
    public partial class professionals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Consult");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Professional",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Professional",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Professional",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Professional",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Professional",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Professional_Guid",
                table: "Professional",
                column: "Guid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Professional_Guid",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Professional");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Professional");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Professional",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Consult",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
