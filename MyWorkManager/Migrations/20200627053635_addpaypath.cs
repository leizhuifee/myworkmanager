using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkManager.Migrations
{
    public partial class addpaypath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Paypath",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paypath",
                table: "Tickets");
        }
    }
}
