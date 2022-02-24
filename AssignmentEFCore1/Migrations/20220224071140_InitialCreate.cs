﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentEFCore1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(type: "ntext", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "ntext", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "ntext", maxLength: 150, nullable: false),
                    State = table.Column<string>(type: "ntext", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
