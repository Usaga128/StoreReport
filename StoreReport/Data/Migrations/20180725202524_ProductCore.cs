using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreReport.Data.Migrations
{
    public partial class ProductCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
