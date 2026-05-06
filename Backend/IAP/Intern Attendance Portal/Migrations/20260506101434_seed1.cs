using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intern_Attendance_Portal.Migrations
{
    /// <inheritdoc />
    public partial class seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "company_id", "created_at", "Email", "employee_id", "Name", "password_hash", "Role", "Status", "updated_at" },
                values: new object[] { 2, 1, new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), "abi@aecs.org", "INTERN0001", "Abi", "$2a$11$to/028k1IpfyGwiJw8WX0uZxFbSyT8HP0jeQ3H6M/I/bdDzvcjmxu", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
