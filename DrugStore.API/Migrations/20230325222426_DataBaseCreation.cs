using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugStore.API.Migrations
{
    public partial class DataBaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    EIN = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: false),
                    SalePrice = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InsurancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Insurances_InsurancesId",
                        column: x => x.InsurancesId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInvoice",
                columns: table => new
                {
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InvoicesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProductsInvoice_Invoices_InvoicesId",
                        column: x => x.InvoicesId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInvoice_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsReceipt",
                columns: table => new
                {
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReceiptsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProductsReceipt_Invoices_ReceiptsId",
                        column: x => x.ReceiptsId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsReceipt_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Placeholder Category Description", "Placeholder Category Name" });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Placeholder Insurance Description", "Placeholder Insurance Name" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Description", "EIN", "Email", "Name", "Phone", "ZipCode" },
                values: new object[] { 1, "Placeholder Supplier Address", "Placeholder Supplier Description", 0, "PlaceholderSupplier@Email.com", "Placeholder Supplier Name", "0000000000", 0 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Description", "Email", "InsurancesId", "Name", "Phone", "SSN", "ZipCode" },
                values: new object[] { 1, "Placeholder Customer Address", "Placeholder Customer Description", "PlaceholderCustomer@Email.com", 1, "Placeholder Customer Name", "0000000000", 0, 0 });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Date", "Description", "SuppliersId" },
                values: new object[] { 1, new DateTime(2023, 3, 26, 0, 24, 26, 167, DateTimeKind.Local).AddTicks(716), "Placeholder Invoices Description", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoriesId", "Description", "Name", "PurchasePrice", "SalePrice" },
                values: new object[] { 1, 1, "Placeholder Product Description", "Placeholder Product Name", 10m, 20m });

            migrationBuilder.InsertData(
                table: "Receipts",
                columns: new[] { "Id", "CustomersId", "Date", "Description" },
                values: new object[] { 1, 1, new DateTime(2023, 3, 26, 0, 24, 26, 167, DateTimeKind.Local).AddTicks(776), "Placeholder Invoices Description" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_InsurancesId",
                table: "Customers",
                column: "InsurancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name_SSN",
                table: "Customers",
                columns: new[] { "Name", "SSN" });

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_Name",
                table: "Insurances",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Date",
                table: "Invoices",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SuppliersId",
                table: "Invoices",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesId",
                table: "Products",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInvoice_InvoicesId",
                table: "ProductsInvoice",
                column: "InvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInvoice_ProductsId",
                table: "ProductsInvoice",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInvoice_Quantity",
                table: "ProductsInvoice",
                column: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReceipt_ProductsId",
                table: "ProductsReceipt",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReceipt_Quantity",
                table: "ProductsReceipt",
                column: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReceipt_ReceiptsId",
                table: "ProductsReceipt",
                column: "ReceiptsId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CustomersId",
                table: "Receipts",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_Date",
                table: "Receipts",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Name_EIN",
                table: "Suppliers",
                columns: new[] { "Name", "EIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsInvoice");

            migrationBuilder.DropTable(
                name: "ProductsReceipt");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Insurances");
        }
    }
}
