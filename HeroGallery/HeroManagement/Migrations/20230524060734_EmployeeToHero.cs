using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroManagement.Migrations
{
    public partial class EmployeeToHero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Heros",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Heros");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Heros",
                newName: "Series");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Power",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Heros");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Heros");

            migrationBuilder.RenameColumn(
                name: "Series",
                table: "Heros",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Heros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Department", "Email", "Gender", "Name", "PhotoPath" },
                values: new object[] { 1, 0, "mary@pragimtech.com", 1, "Mary", null });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "Department", "Email", "Gender", "Name", "PhotoPath" },
                values: new object[] { 2, 0, "john@pragimtech.com", 0, "John", null });
        }
    }
}
