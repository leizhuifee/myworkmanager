using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWorkManager.Migrations
{
    public partial class Iniailtwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Coverall");

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "workerSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workerSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creatTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sleeve = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    workerNameId = table.Column<int>(type: "int", nullable: false),
                    departmentNameId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Covers_departments_departmentNameId",
                        column: x => x.departmentNameId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Covers_workers_workerNameId",
                        column: x => x.workerNameId,
                        principalTable: "workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Covers_departmentNameId",
                table: "Covers",
                column: "departmentNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_workerNameId",
                table: "Covers",
                column: "workerNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "workerSizes");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "workers");

            //migrationBuilder.CreateTable(
            //    name: "Coverall",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Number = table.Column<int>(type: "int", nullable: false),
            //        Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Sleeve = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Time = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        GiveNumber = table.Column<int>(type: "int", nullable: true),
            //        Nname = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Coverall", x => x.Id);
            //    });
        }
    }
}
