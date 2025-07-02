using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Province_API.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToAdministrativeUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "administrative_unit",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "administrative_unit");

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS GetAncestors(TEXT);");
        }
    }
}
