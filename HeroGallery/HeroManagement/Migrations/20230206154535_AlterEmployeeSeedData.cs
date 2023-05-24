using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroManagement.Migrations
{
    public partial class AlterHeroSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "mary@pragimtech.com", "Mary" });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[] { 2, 0, "john@pragimtech.com", "John" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "mark@pragimtech.com", "Mark" });
        }
    }
}
