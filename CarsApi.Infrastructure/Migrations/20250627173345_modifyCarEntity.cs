using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyCarEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            "ALTER TABLE \"Cars\" ALTER COLUMN \"Gas_type\" TYPE integer USING \"Gas_type\"::integer;"
        );
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"Cars\" ALTER COLUMN \"Gas_type\" TYPE text USING \"Gas_type\"::text;"
            );
        }

    }
}
