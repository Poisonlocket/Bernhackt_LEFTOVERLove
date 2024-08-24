using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeftOverLove.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Customers");
        }
    }
}
