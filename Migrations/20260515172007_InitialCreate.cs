using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPCRUDAssignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerName", "OrderDate", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, "Bashiir Abshir Ali", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.99m, "Wireless Headphones", 2 },
                    { 2, "Maaido Abdi Said", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 149.95m, "Mechanical Keyboard", 1 },
                    { 3, "Aniso Farah Jama", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.50m, "USB-C Hub", 3 },
                    { 4, "Mohamed Ali Nur", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.99m, "Laptop Stand", 1 },
                    { 5, "Abdirahman Abdi Farah", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 89.00m, "Webcam HD", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
