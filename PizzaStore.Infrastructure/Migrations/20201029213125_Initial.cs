using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaStore.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsTopping = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderPlaced = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_HouseNumber = table.Column<string>(nullable: true),
                    Address_HouseUnitNumber = table.Column<string>(nullable: true),
                    Customer_Name = table.Column<string>(nullable: true),
                    Customer_Phone = table.Column<string>(nullable: true),
                    Customer_Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ParentItemId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TaxId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "IsTopping", "Name" },
                values: new object[,]
                {
                    { -1, false, "Pizza" },
                    { -2, true, "PizzaTopping" },
                    { -3, false, "MainMeal" },
                    { -4, true, "MainMealTopping" },
                    { -5, false, "Soup" },
                    { -6, false, "Drink" }
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { -1, "basicTax", 23 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "GroupId", "Name", "Price", "TaxId" },
                values: new object[,]
                {
                    { -1, -1, "Margherita", 20m, -1 },
                    { -16, -6, "Coffee", 5m, -1 },
                    { -15, -5, "Chicken soup", 10m, -1 },
                    { -14, -5, "Tomato soup", 12m, -1 },
                    { -13, -4, "Set of sauces", 6m, -1 },
                    { -12, -4, "Salad bar", 5m, -1 },
                    { -11, -3, "Hungarian style potato pancake", 27m, -1 },
                    { -10, -3, "Fish and chips", 28m, -1 },
                    { -9, -3, "Pork chop with chips / rice / potatoes", 30m, -1 },
                    { -8, -2, "Mushrooms", 2m, -1 },
                    { -7, -2, "Ham", 2m, -1 },
                    { -6, -2, "Salami", 2m, -1 },
                    { -5, -2, "Double cheese", 2m, -1 },
                    { -4, -1, "Venecia", 25m, -1 },
                    { -3, -1, "Tosca", 25m, -1 },
                    { -2, -1, "Vegetariana", 22m, -1 },
                    { -17, -6, "Tea", 5m, -1 },
                    { -18, -6, "Coke", 5m, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxId",
                table: "Products",
                column: "TaxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Taxes");
        }
    }
}
