using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeautySalon.Migrations
{
    /// <inheritdoc />
    public partial class empcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "PosId");

            migrationBuilder.RenameColumn(
                name: "Empid",
                table: "employeesonpositions",
                newName: "EmpsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeesonpositions",
                table: "employeesonpositions",
                columns: new[] { "EmpsId", "PosId" });

            migrationBuilder.CreateIndex(
                name: "IX_employeesonpositions_PosId",
                table: "employeesonpositions",
                column: "PosId");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesonpositions_employees_EmpsId",
                table: "employeesonpositions",
                column: "EmpsId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeesonpositions_positions_PosId",
                table: "employeesonpositions",
                column: "PosId",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeesonpositions_employees_EmpsId",
                table: "employeesonpositions");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesonpositions_positions_PosId",
                table: "employeesonpositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeesonpositions",
                table: "employeesonpositions");

            migrationBuilder.DropIndex(
                name: "IX_employeesonpositions_PosId",
                table: "employeesonpositions");

            migrationBuilder.RenameTable(
                name: "employeesonpositions",
                newName: "EmployeesOnPositions");

            migrationBuilder.RenameColumn(
                name: "PosId",
                table: "EmployeesOnPositions",
                newName: "Posid");

            migrationBuilder.RenameColumn(
                name: "EmpsId",
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
    }
}
