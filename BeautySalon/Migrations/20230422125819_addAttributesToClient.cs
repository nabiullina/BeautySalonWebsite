using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySalon.Migrations
{
    /// <inheritdoc />
    public partial class addAttributesToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FathersName",
                table: "clients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "clients",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FathersName",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "clients");
        }
    }
}
