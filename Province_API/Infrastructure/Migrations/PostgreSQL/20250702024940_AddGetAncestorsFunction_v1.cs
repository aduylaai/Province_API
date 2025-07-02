using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Province_API.Migrations
{
    /// <inheritdoc />
    public partial class AddGetAncestorsFunction_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DROP FUNCTION IF EXISTS getancestors(TEXT);

CREATE FUNCTION getancestors(unit_id TEXT)
RETURNS TABLE (
    id TEXT,
    name TEXT,
    ""parentId"" TEXT,
    type TEXT,
    ""IsDelete"" BOOLEAN,
    ""AdminstrativeUnitId"" TEXT
) AS
$$
WITH RECURSIVE parents AS (
    SELECT * FROM ""administrative_unit"" WHERE ""id"" = unit_id
    UNION
    SELECT p.* FROM ""administrative_unit"" p
    JOIN parents c ON p.""id"" = c.""parentId""
)
SELECT 
    ""id"", 
    ""name"", 
    ""parentId"", 
    ""type"", 
    ""IsDelete"", 
    ""AdminstrativeUnitId""
FROM parents
WHERE ""id"" != unit_id;
$$
LANGUAGE SQL;
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP FUNCTION IF EXISTS getancestors(TEXT);
            ");
        }
    }
}
