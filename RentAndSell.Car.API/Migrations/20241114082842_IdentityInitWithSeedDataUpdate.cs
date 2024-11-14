using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentAndSell.Car.API.Migrations
{
    /// <inheritdoc />
    public partial class IdentityInitWithSeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e9a6c22-590a-44ef-8c52-875286507a94", "74d7a5cc-a52a-4369-b04f-67a11ec9a456" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e9a6c22-590a-44ef-8c52-875286507a94");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74d7a5cc-a52a-4369-b04f-67a11ec9a456");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "256617c6-457e-4850-bcc9-756566d33c59", "a409dee2-1bc0-4ce6-b246-d28e649a5845", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b73d874-b09b-498e-b45b-6de4bbc31fa3", 0, "27e5d802-35f9-4d34-bcc4-bbfd0a449f41", "admin@gmail.com", true, "Admin", "User", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENrVjjcN/q3ofqBYGlicQo6rfeGNpGyD+9k2+1noIHptgCT61oP6LHNMKmA7BOK5EA==", null, false, "e45c1ee3-98b2-4c3a-87b7-85fc02ade05b", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "256617c6-457e-4850-bcc9-756566d33c59", "7b73d874-b09b-498e-b45b-6de4bbc31fa3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "256617c6-457e-4850-bcc9-756566d33c59", "7b73d874-b09b-498e-b45b-6de4bbc31fa3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "256617c6-457e-4850-bcc9-756566d33c59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b73d874-b09b-498e-b45b-6de4bbc31fa3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e9a6c22-590a-44ef-8c52-875286507a94", "41dd1596-3088-4ac5-bfbf-5039195a47be", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "74d7a5cc-a52a-4369-b04f-67a11ec9a456", 0, "3f488881-3cba-47b2-999b-f49ce8120d2b", "admin@gmail.com", true, "Admin", "User", false, null, "ADMIN@GMAIL.COM", "ADMIN", null, null, false, "902a3ef5-aa15-4882-a17a-f2100b9b5398", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6e9a6c22-590a-44ef-8c52-875286507a94", "74d7a5cc-a52a-4369-b04f-67a11ec9a456" });
        }
    }
}
