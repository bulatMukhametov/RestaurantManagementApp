using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User_UserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPosition_MenuPositions_OrderId",
                table: "OrderPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPosition_Order_OrderId",
                table: "OrderPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInMenuPosition_MenuPositions_MenuPositionId",
                table: "ProductInMenuPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInMenuPosition_Product_ProductId",
                table: "ProductInMenuPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInMenuPosition",
                table: "ProductInMenuPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPosition",
                table: "OrderPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuPositions",
                table: "MenuPositions");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "ProductInMenuPosition",
                newName: "product_in_menu_positions");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "OrderPosition",
                newName: "order_positions");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "MenuPositions",
                newName: "menu_positions");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInMenuPosition_ProductId",
                table: "product_in_menu_positions",
                newName: "IX_product_in_menu_positions_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInMenuPosition_MenuPositionId",
                table: "product_in_menu_positions",
                newName: "IX_product_in_menu_positions_MenuPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPosition_OrderId",
                table: "order_positions",
                newName: "IX_order_positions_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_EmployeeId",
                table: "orders",
                newName: "IX_orders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "orders",
                newName: "IX_orders_CustomerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "menu_positions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "menu_positions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_in_menu_positions",
                table: "product_in_menu_positions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_positions",
                table: "order_positions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_menu_positions",
                table: "menu_positions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_users_UserId",
                table: "Customer",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_users_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_positions_menu_positions_OrderId",
                table: "order_positions",
                column: "OrderId",
                principalTable: "menu_positions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_positions_orders_OrderId",
                table: "order_positions",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Customer_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Employee_EmployeeId",
                table: "orders",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_in_menu_positions_menu_positions_MenuPositionId",
                table: "product_in_menu_positions",
                column: "MenuPositionId",
                principalTable: "menu_positions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_in_menu_positions_products_ProductId",
                table: "product_in_menu_positions",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_users_UserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_users_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_order_positions_menu_positions_OrderId",
                table: "order_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_order_positions_orders_OrderId",
                table: "order_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_Customer_CustomerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_Employee_EmployeeId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_product_in_menu_positions_menu_positions_MenuPositionId",
                table: "product_in_menu_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_product_in_menu_positions_products_ProductId",
                table: "product_in_menu_positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_in_menu_positions",
                table: "product_in_menu_positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_positions",
                table: "order_positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_menu_positions",
                table: "menu_positions");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "menu_positions");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "menu_positions");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "product_in_menu_positions",
                newName: "ProductInMenuPosition");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "order_positions",
                newName: "OrderPosition");

            migrationBuilder.RenameTable(
                name: "menu_positions",
                newName: "MenuPositions");

            migrationBuilder.RenameIndex(
                name: "IX_product_in_menu_positions_ProductId",
                table: "ProductInMenuPosition",
                newName: "IX_ProductInMenuPosition_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_product_in_menu_positions_MenuPositionId",
                table: "ProductInMenuPosition",
                newName: "IX_ProductInMenuPosition_MenuPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_EmployeeId",
                table: "Order",
                newName: "IX_Order_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_order_positions_OrderId",
                table: "OrderPosition",
                newName: "IX_OrderPosition_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInMenuPosition",
                table: "ProductInMenuPosition",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPosition",
                table: "OrderPosition",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuPositions",
                table: "MenuPositions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_User_UserId",
                table: "Customer",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPosition_MenuPositions_OrderId",
                table: "OrderPosition",
                column: "OrderId",
                principalTable: "MenuPositions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPosition_Order_OrderId",
                table: "OrderPosition",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInMenuPosition_MenuPositions_MenuPositionId",
                table: "ProductInMenuPosition",
                column: "MenuPositionId",
                principalTable: "MenuPositions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInMenuPosition_Product_ProductId",
                table: "ProductInMenuPosition",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
