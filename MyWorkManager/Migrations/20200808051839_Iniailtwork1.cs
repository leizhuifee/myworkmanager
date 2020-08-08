using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkManager.Migrations
{
    public partial class Iniailtwork1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covers_departments_departmentNameId",
                table: "Covers");

            migrationBuilder.DropForeignKey(
                name: "FK_Covers_workers_workerNameId",
                table: "Covers");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropIndex(
                name: "IX_Covers_departmentNameId",
                table: "Covers");

            migrationBuilder.DropIndex(
                name: "IX_Covers_workerNameId",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "departmentNameId",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "workerNameId",
                table: "Covers");

            migrationBuilder.AddColumn<string>(
                name: "departmentName",
                table: "Covers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "workerName",
                table: "Covers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "departmentName",
                table: "Covers");

            migrationBuilder.DropColumn(
                name: "workerName",
                table: "Covers");

            migrationBuilder.AddColumn<int>(
                name: "departmentNameId",
                table: "Covers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "workerNameId",
                table: "Covers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Covers_departmentNameId",
                table: "Covers",
                column: "departmentNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_workerNameId",
                table: "Covers",
                column: "workerNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_departments_departmentNameId",
                table: "Covers",
                column: "departmentNameId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Covers_workers_workerNameId",
                table: "Covers",
                column: "workerNameId",
                principalTable: "workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
