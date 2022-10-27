using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReastaurantManagement.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_positions_menu_positions_OrderId",
                table: "order_positions");

            migrationBuilder.CreateIndex(
                name: "IX_order_positions_MenuPositionId",
                table: "order_positions",
                column: "MenuPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_positions_menu_positions_MenuPositionId",
                table: "order_positions",
                column: "MenuPositionId",
                principalTable: "menu_positions",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_positions_menu_positions_MenuPositionId",
                table: "order_positions");

            migrationBuilder.DropIndex(
                name: "IX_order_positions_MenuPositionId",
                table: "order_positions");

            migrationBuilder.AddForeignKey(
                name: "FK_order_positions_menu_positions_OrderId",
                table: "order_positions",
                column: "OrderId",
                principalTable: "menu_positions",
                principalColumn: "id");
        }
    }
}
