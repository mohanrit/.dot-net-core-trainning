using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_WFM.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    wfm_manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    lockstatus = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    experience = table.Column<decimal>(type: "decimal(5,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skillid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skillid);
                });

            migrationBuilder.CreateTable(
                name: "Skillmaps",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    skillid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skillmaps", x => new { x.employee_id, x.skillid });
                    table.ForeignKey(
                        name: "FK_Skillmaps_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skillmaps_Skills_skillid",
                        column: x => x.skillid,
                        principalTable: "Skills",
                        principalColumn: "skillid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skillmaps_skillid",
                table: "Skillmaps",
                column: "skillid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skillmaps");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
