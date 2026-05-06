using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intern_Attendance_Portal.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "contact_person", "created_at", "Email", "Name", "Phone", "updated_at" },
                values: new object[] { 1, "Madurai", "Ram", new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), "hr@aecs.org", "AECS", "9876543210", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "company_id", "created_at", "Email", "employee_id", "Name", "password_hash", "Role", "Status", "updated_at" },
                values: new object[] { 1, 1, new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), "aravind@aecs.org", "ADMIN01", "Aravind", "$2a$11$to/028k1IpfyGwiJw8WX0uZxFbSyT8HP0jeQ3H6M/I/bdDzvcjmxu", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "system_setting",
                columns: new[] { "Id", "check_in_end_time", "check_in_start_time", "check_out_start_time", "company_id", "created_at", "latitude", "longitude", "radius_in_meters", "updated_at" },
                values: new object[] { 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0), 1, new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), 9.9222395m, 78.1389458m, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "system_setting",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
