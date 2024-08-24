using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeftOverLove.DataAccess.Migrations;

/// <inheritdoc />
public partial class migrateCustomerLocationToDouble : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Step 1: Add temporary columns for conversion
        migrationBuilder.AddColumn<double>(
            name: "TempLatitude",
            table: "Customers",
            type: "double precision",
            nullable: true);

        migrationBuilder.AddColumn<double>(
            name: "TempLongitude",
            table: "Customers",
            type: "double precision",
            nullable: true);

        // Step 2: Convert existing string data to double and update temporary columns
        migrationBuilder.Sql(@"
        UPDATE ""Customers""
        SET ""TempLatitude"" = 
            CASE
                WHEN ""Latitude"" ~ '^(\+|-)?([0-9]+(\.[0-9]*)?|\.[0-9]+)$' 
                THEN CAST(""Latitude"" AS DOUBLE PRECISION) 
                ELSE 0.00
            END,
            ""TempLongitude"" = 
            CASE
                WHEN ""Longitude"" ~ '^(\+|-)?([0-9]+(\.[0-9]*)?|\.[0-9]+)$' 
                THEN CAST(""Longitude"" AS DOUBLE PRECISION) 
                ELSE 0.00
            END
        WHERE ""Latitude"" IS NOT NULL AND ""Longitude"" IS NOT NULL;
    ");

        // Step 3: Drop the old columns
        migrationBuilder.DropColumn(name: "Latitude", table: "Customers");
        migrationBuilder.DropColumn(name: "Longitude", table: "Customers");

        // Step 4: Rename the temporary columns to the original column names
        migrationBuilder.RenameColumn(
            name: "TempLatitude",
            table: "Customers",
            newName: "Latitude");

        migrationBuilder.RenameColumn(
            name: "TempLongitude",
            table: "Customers",
            newName: "Longitude");

        // Step 5: Alter the columns to not nullable (if necessary)
        migrationBuilder.AlterColumn<double>(
            name: "Latitude",
            table: "Customers",
            type: "double precision",
            nullable: false,
            oldClrType: typeof(double),
            oldNullable: true);

        migrationBuilder.AlterColumn<double>(
            name: "Longitude",
            table: "Customers",
            type: "double precision",
            nullable: false,
            oldClrType: typeof(double),
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Revert the migration (if necessary)
        migrationBuilder.AlterColumn<string>(
            name: "Latitude",
            table: "Customers",
            type: "text",
            nullable: false,
            oldClrType: typeof(double),
            oldType: "double precision");

        migrationBuilder.AlterColumn<string>(
            name: "Longitude",
            table: "Customers",
            type: "text",
            nullable: false,
            oldClrType: typeof(double),
            oldType: "double precision");
    }
}
