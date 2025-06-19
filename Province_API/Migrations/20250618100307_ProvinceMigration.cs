using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Province_API.Migrations
{
    /// <inheritdoc />
    public partial class ProvinceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrative_unit",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    parentId = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    AdminstrativeUnitId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_unit", x => x.id);
                    table.ForeignKey(
                        name: "FK_administrative_unit_administrative_unit_AdminstrativeUnitId",
                        column: x => x.AdminstrativeUnitId,
                        principalTable: "administrative_unit",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_administrative_unit_AdminstrativeUnitId",
                table: "administrative_unit",
                column: "AdminstrativeUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrative_unit");
        }
    }
}
