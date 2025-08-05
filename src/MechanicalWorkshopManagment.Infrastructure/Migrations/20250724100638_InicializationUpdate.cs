using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicalWorkshopManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicializationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartsBudgets_Budgets_BudgetId",
                table: "PartsBudgets");

            migrationBuilder.DropIndex(
                name: "IX_PartsBudgets_BudgetId",
                table: "PartsBudgets");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "PartsBudgets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "PartsBudgets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsBudgets_BudgetId",
                table: "PartsBudgets",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartsBudgets_Budgets_BudgetId",
                table: "PartsBudgets",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id");
        }
    }
}
