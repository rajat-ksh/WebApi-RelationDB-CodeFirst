using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    public partial class addedInterface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkLocation_WorkLocationLocationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "WorkLocation",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "WorkLocation",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WorkLocationLocationId",
                table: "Employees",
                newName: "WorkLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_WorkLocationLocationId",
                table: "Employees",
                newName: "IX_Employees_WorkLocationId");

            migrationBuilder.RenameColumn(
                name: "DeptName",
                table: "Departments",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkLocation_WorkLocationId",
                table: "Employees",
                column: "WorkLocationId",
                principalTable: "WorkLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkLocation_WorkLocationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "WorkLocation",
                newName: "LocationName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkLocation",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "WorkLocationId",
                table: "Employees",
                newName: "WorkLocationLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_WorkLocationId",
                table: "Employees",
                newName: "IX_Employees_WorkLocationLocationId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "DeptName");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentDeptId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptId",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentDeptId",
                table: "Employees",
                column: "DepartmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentDeptId",
                table: "Employees",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkLocation_WorkLocationLocationId",
                table: "Employees",
                column: "WorkLocationLocationId",
                principalTable: "WorkLocation",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
