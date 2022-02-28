using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentEFCore2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    cId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.cId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    pId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.pId);
                    table.ForeignKey(
                        name: "FK_Product_Categories_cId",
                        column: x => x.cId,
                        principalTable: "Categories",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_cId",
                table: "Product",
                column: "cId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
