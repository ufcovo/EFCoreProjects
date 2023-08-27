using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    public partial class updateOwnedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person_LastName",
                table: "Manager",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Person_FirstName",
                table: "Manager",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Person_Age",
                table: "Manager",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "Person_LastName",
                table: "Employee",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Person_FirstName",
                table: "Employee",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Person_Age",
                table: "Employee",
                newName: "Age");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Manager",
                newName: "Person_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Manager",
                newName: "Person_FirstName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Manager",
                newName: "Person_Age");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employee",
                newName: "Person_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Employee",
                newName: "Person_FirstName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Employee",
                newName: "Person_Age");
        }
    }
}
