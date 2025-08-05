using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicalWorkshopManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableBuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusDelivered",
                table: "Buy",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDelivered",
                table: "Buy");
        }
    }
}
