using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Entry_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entry_date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationList",
                columns: table => new
                {
                    Q_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Q_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationList", x => x.Q_Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Qualification",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Q_Id = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Qualification", x => new { x.Employee_Id, x.Q_Id });
                    table.ForeignKey(
                        name: "FK_Emp_Qualification_Employee_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_Qualification_QualificationList_Q_Id",
                        column: x => x.Q_Id,
                        principalTable: "QualificationList",
                        principalColumn: "Q_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Qualification_Q_Id",
                table: "Emp_Qualification",
                column: "Q_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp_Qualification");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "QualificationList");
        }
    }
}
