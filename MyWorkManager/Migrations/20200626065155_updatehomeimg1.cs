using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkManager.Migrations
{
    public partial class updatehomeimg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ControllName",
                table: "Homeimgs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControllName",
                table: "Homeimgs");
        }
    }
}
