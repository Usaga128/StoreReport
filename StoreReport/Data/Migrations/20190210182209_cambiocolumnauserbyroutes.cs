using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreReport.Data.Migrations
{
    public partial class cambiocolumnauserbyroutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "UserByRoute",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserByRoute",
                newName: "UserEmail");
        }
    }
}
