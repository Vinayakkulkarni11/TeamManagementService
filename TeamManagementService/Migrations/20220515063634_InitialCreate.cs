using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamManagementService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    BU_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BU_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BU_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BU_Type = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.BU_Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitCategories",
                columns: table => new
                {
                    BUC_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BU_Id = table.Column<int>(type: "int", nullable: false),
                    ZurichLineOfBusiness = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitCategories", x => x.BUC_Id);
                    table.ForeignKey(
                        name: "FK_BusinessUnitCategories_BusinessUnits_BU_Id",
                        column: x => x.BU_Id,
                        principalTable: "BusinessUnits",
                        principalColumn: "BU_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitMembers",
                columns: table => new
                {
                    BUM_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BU_Id = table.Column<int>(type: "int", nullable: false),
                    EmployeeLoginId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitMembers", x => x.BUM_Id);
                    table.ForeignKey(
                        name: "FK_BusinessUnitMembers_BusinessUnits_BU_Id",
                        column: x => x.BU_Id,
                        principalTable: "BusinessUnits",
                        principalColumn: "BU_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_LoginID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BU_Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_LoginID);
                    table.ForeignKey(
                        name: "FK_Employees_BusinessUnits_BU_Id",
                        column: x => x.BU_Id,
                        principalTable: "BusinessUnits",
                        principalColumn: "BU_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitCategories_BU_Id",
                table: "BusinessUnitCategories",
                column: "BU_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitMembers_BU_Id",
                table: "BusinessUnitMembers",
                column: "BU_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BU_Id",
                table: "Employees",
                column: "BU_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessUnitCategories");

            migrationBuilder.DropTable(
                name: "BusinessUnitMembers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "BusinessUnits");
        }
    }
}
