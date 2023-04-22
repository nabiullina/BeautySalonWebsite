using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeautySalon.Migrations
{
    /// <inheritdoc />
    public partial class addDeleteAttendancesTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fkattid",
                table: "serviceprovisions");

            migrationBuilder.DropTable(
                name: "attendances");

            migrationBuilder.AddForeignKey(
                name: "fkcliid",
                table: "serviceprovisions",
                column: "attid",
                principalTable: "clients",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fkcliid",
                table: "serviceprovisions");

            migrationBuilder.CreateTable(
                name: "attendances",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    clientid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attendances_pkey", x => x.id);
                    table.ForeignKey(
                        name: "attendances_clientid_fkey",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendances_clientid",
                table: "attendances",
                column: "clientid");

            migrationBuilder.AddForeignKey(
                name: "fkattid",
                table: "serviceprovisions",
                column: "attid",
                principalTable: "attendances",
                principalColumn: "id");
        }
    }
}
