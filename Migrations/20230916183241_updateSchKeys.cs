using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTimeTable.Migrations
{
    /// <inheritdoc />
    public partial class updateSchKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolUniqueId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolUniqueId",
                table: "StudentClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolUniqueId",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolUniqueId",
                table: "ClassArms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolUniqueId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SchoolUniqueId",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "SchoolUniqueId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "SchoolUniqueId",
                table: "ClassArms");
        }
    }
}
