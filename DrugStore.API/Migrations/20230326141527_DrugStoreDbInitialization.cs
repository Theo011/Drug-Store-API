using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugStore.API.Migrations
{
    public partial class DrugStoreDbInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Ein = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: false),
                    SalePrice = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInvoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInvoice", x => new { x.InvoiceId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInvoice_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInvoice_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReceipt",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReceipt", x => new { x.ReceiptId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductReceipt_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReceipt_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Placeholder Category Description", "Placeholder Category Name" });

            migrationBuilder.InsertData(
                table: "Insurance",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Placeholder Insurance Description", "Placeholder Insurance Name" });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Address", "Description", "Ein", "Email", "Name", "Phone", "ZipCode" },
                values: new object[] { 1, "Placeholder Supplier Address", "Placeholder Supplier Description", "000000000", "PlaceholderSupplier@Email.com", "Placeholder Supplier Name", "0000000000", "00000" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Description", "Email", "InsuranceId", "Name", "Phone", "Ssn", "ZipCode" },
                values: new object[] { 1, "Placeholder Customer Address", "Placeholder Customer Description", "PlaceholderCustomer@Email.com", 1, "Placeholder Customer Name", "0000000000", "000000000", "00000" });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "Id", "Date", "Description", "SupplierId" },
                values: new object[] { 1, new DateTime(2023, 3, 26, 17, 15, 26, 758, DateTimeKind.Local).AddTicks(7678), "Placeholder Invoice Description", 1 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PurchasePrice", "SalePrice" },
                values: new object[] { 1, 1, "Placeholder Product Description", "Placeholder Product Name", 10m, 20m });

            migrationBuilder.InsertData(
                table: "ProductInvoice",
                columns: new[] { "InvoiceId", "ProductId", "Description", "Quantity" },
                values: new object[] { 1, 1, "Placeholder ProductInvoice Description", 100 });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "Id", "CustomerId", "Date", "Description" },
                values: new object[] { 1, 1, new DateTime(2023, 3, 26, 17, 15, 26, 758, DateTimeKind.Local).AddTicks(7741), "Placeholder Receipt Description" });

            migrationBuilder.InsertData(
                table: "ProductReceipt",
                columns: new[] { "ProductId", "ReceiptId", "Description", "Quantity" },
                values: new object[] { 1, 1, "Placeholder ProductReceipt Description", 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_InsuranceId",
                table: "Customer",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Name_Ssn",
                table: "Customer",
                columns: new[] { "Name", "Ssn" });

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_Name",
                table: "Insurance",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Date",
                table: "Invoice",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SupplierId",
                table: "Invoice",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoice_ProductId",
                table: "ProductInvoice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoice_Quantity",
                table: "ProductInvoice",
                column: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReceipt_ProductId",
                table: "ProductReceipt",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReceipt_Quantity",
                table: "ProductReceipt",
                column: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CustomerId",
                table: "Receipt",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_Date",
                table: "Receipt",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Name_Ein",
                table: "Supplier",
                columns: new[] { "Name", "Ein" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInvoice");

            migrationBuilder.DropTable(
                name: "ProductReceipt");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Insurance");
        }
    }
}