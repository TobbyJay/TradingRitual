using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingRitual.Data.Migrations
{
    public partial class UpdateFormsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8b4d0459-c808-46df-a07d-ec29a90353c8", "11f91b1d-6724-4099-ad64-679e059458d1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b4d0459-c808-46df-a07d-ec29a90353c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11f91b1d-6724-4099-ad64-679e059458d1");

            migrationBuilder.AddColumn<string>(
                name: "TimeOfTrade",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a29d4cd0-54f4-4866-9ab5-b3189f595681", "2400e2dd-397d-4fe8-a3ed-8d51145a9424", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d286946a-c070-4ed4-8a0f-b0bb3994e2e3", 0, "2ceda32f-ec38-4e75-9012-688dbbfffd4c", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEIx6m30Y6ahHeMOdUantk1zDJ8EeiPq5cdUrb0yPMd03hHC+O9B9oj0U+hVGzWM/3Q==", null, false, "981cd179-7891-4026-8296-0f64bab8b943", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a29d4cd0-54f4-4866-9ab5-b3189f595681", "d286946a-c070-4ed4-8a0f-b0bb3994e2e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a29d4cd0-54f4-4866-9ab5-b3189f595681", "d286946a-c070-4ed4-8a0f-b0bb3994e2e3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a29d4cd0-54f4-4866-9ab5-b3189f595681");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d286946a-c070-4ed4-8a0f-b0bb3994e2e3");

            migrationBuilder.DropColumn(
                name: "TimeOfTrade",
                table: "Forms");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b4d0459-c808-46df-a07d-ec29a90353c8", "99459823-4dcf-4fc5-9adb-2a8a0707196c", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11f91b1d-6724-4099-ad64-679e059458d1", 0, "5a1cd28e-1b3d-426c-bde6-1e741b73710f", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEK59uLsnmiWT975VTijDkmYqjq3k6VqS8jWYkpktx9SKGGIAKuxlXSwf/bBvKWOYTQ==", null, false, "cc13cf8c-cd1a-4c50-8b1d-09e33d6e45da", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8b4d0459-c808-46df-a07d-ec29a90353c8", "11f91b1d-6724-4099-ad64-679e059458d1" });
        }
    }
}
