using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccUmc.Infrastructure.Migrations
{
    public partial class AddUserValidationToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ResetPasswordTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ResetPasswordTokens");
        }
    }
}
