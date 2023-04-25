using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeautySalon.Migrations
{
    /// <inheritdoc />
    public partial class addEmpOnPos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fkempid",
                table: "employeesonpositions");

            migrationBuilder.DropForeignKey(
                name: "fkposid",
                table: "employeesonpositions");

            migrationBuilder.DropPrimaryKey(
                name: "pkemponposid",
                table: "employeesonpositions");

            migrationBuilder.DropIndex(
                name: "IX_employeesonpositions_posid",
                table: "employeesonpositions");

            migrationBuilder.RenameTable(
                name: "employeesonpositions",
                newName: "EmployeesOnPositions");

            migrationBuilder.RenameColumn(
                name: "posid",
                table: "EmployeesOnPositions",
                newName: "Posid");

            migrationBuilder.RenameColumn(
                name: "empid",
                table: "EmployeesOnPositions",
                newName: "Empid");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "EmployeesOnPositions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesOnPositions",
                table: "EmployeesOnPositions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "employeesonpositions",
                columns: table => new
                {
                    empid = table.Column<long>(type: "bigint", nullable: false),
                    posid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkemponposid", x => new { x.empid, x.posid });
                    table.ForeignKey(
                        name: "fkempid",
                        column: x => x.empid,
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkposid",
                        column: x => x.posid,
                        principalTable: "positions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeesonpositions_posid",
                table: "employeesonpositions",
                column: "posid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeesonpositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesOnPositions",
                table: "EmployeesOnPositions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeesOnPositions");

            migrationBuilder.RenameTable(
                name: "EmployeesOnPositions",
                newName: "employeesonpositions");

            migrationBuilder.RenameColumn(
                name: "Posid",
                table: "employeesonpositions",
                newName: "posid");

            migrationBuilder.RenameColumn(
                name: "Empid",
                table: "employeesonpositions",
                newName: "empid");

            migrationBuilder.AddPrimaryKey(
                name: "pkemponposid",
                table: "employeesonpositions",
                columns: new[] { "empid", "posid" });

            migrationBuilder.CreateIndex(
                name: "IX_employeesonpositions_posid",
                table: "employeesonpositions",
                column: "posid");

            migrationBuilder.AddForeignKey(
                name: "fkempid",
                table: "employeesonpositions",
                column: "empid",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fkposid",
                table: "employeesonpositions",
                column: "posid",
                principalTable: "positions",
                principalColumn: "id");
        }
    }
}
