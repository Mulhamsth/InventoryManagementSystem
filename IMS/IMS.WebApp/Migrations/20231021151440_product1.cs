using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class product1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Inventories",
                type: "varchar(150)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductName",
                table: "Inventories",
                column: "ProductName");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductName",
                table: "Inventories",
                column: "ProductName",
                principalTable: "Products",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductName",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ProductName",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Inventories");
        }
    }
}
