using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingRitual.Data.Migrations
{
    public partial class ProfileDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "589ad9af-469c-4113-9166-8c722b2ca884", "9fc82c50-efcc-4948-9b70-227b52e6d406" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "589ad9af-469c-4113-9166-8c722b2ca884");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fc82c50-efcc-4948-9b70-227b52e6d406");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "990e54d7-a9eb-441b-8707-0bfaa1eac9f1", "9ed95242-47ea-4bcc-8b71-4162ed391320", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da3b0305-07a5-431a-80a1-aae090774507", 0, "eff83b0e-14be-44a1-928e-fdd6af0831f9", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEP9Y4PWM2pY/49OeY4UQvhbT8V2KP01vJQlDq23HMSZQGuNDdZQFWyFqebQ59Y2jDg==", null, false, "1f9842d7-c730-45b3-ac5f-f32133abe689", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "990e54d7-a9eb-441b-8707-0bfaa1eac9f1", "da3b0305-07a5-431a-80a1-aae090774507" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "990e54d7-a9eb-441b-8707-0bfaa1eac9f1", "da3b0305-07a5-431a-80a1-aae090774507" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "990e54d7-a9eb-441b-8707-0bfaa1eac9f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da3b0305-07a5-431a-80a1-aae090774507");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "589ad9af-469c-4113-9166-8c722b2ca884", "88f40a4b-e4e8-4464-ac42-8eec8c6580be", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9fc82c50-efcc-4948-9b70-227b52e6d406", 0, "fb0a85b7-c973-45ea-8d8d-fd0d2eeed54b", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEIZ5kAJE/XzjnkGS308ipPvOkhtOEoDrnf3FMFd1/sfKVby3bUWKZGMjQXj8oQTpqQ==", null, false, "7ac5699f-7c4c-40e2-a1a2-b2f299906b2d", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "589ad9af-469c-4113-9166-8c722b2ca884", "9fc82c50-efcc-4948-9b70-227b52e6d406" });
        }
    }
}
