using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroManagement.Migrations
{
    public partial class AddPhotoPathColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Heros");
        }
    }
}
