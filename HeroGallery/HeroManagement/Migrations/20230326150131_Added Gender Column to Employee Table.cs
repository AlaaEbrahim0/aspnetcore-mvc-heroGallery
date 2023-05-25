using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroManagement.Migrations
{
    public partial class AddedGenderColumntoHeroTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Heros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Heros");
        }
    }
}
