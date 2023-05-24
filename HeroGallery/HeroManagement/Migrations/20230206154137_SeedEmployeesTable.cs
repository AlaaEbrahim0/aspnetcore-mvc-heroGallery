using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroManagement.Migrations
{
    public partial class SeedHerosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 1, 0, "mark@pragimtech.com", "Mark" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
