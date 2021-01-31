using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingRitual.Data.Migrations
{
    public partial class AddCheckTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ae806b8b-2517-4bcd-900e-826298af9e19", "84ae40c0-cc05-4577-8123-c03b89c3d0e6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae806b8b-2517-4bcd-900e-826298af9e19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84ae40c0-cc05-4577-8123-c03b89c3d0e6");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Strategies",
                newName: "StrategyID");

            migrationBuilder.CreateTable(
                name: "CheckList",
                columns: table => new
                {
                    CheckID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrategyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Checks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckList", x => x.CheckID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59763751-b087-4d7c-ab66-67051e69e999", "875ea17d-6f27-4175-919d-4009d176bb11", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "05232d9f-6430-4b3b-aaa7-9163fbdeaf3c", 0, "f54fbfd9-97ab-4891-9a9c-44f150faf4a0", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEIYpfrBbS5zUsPeuVjzQsJM2mzf9ymiVatRqEYlmupeH3d6s4Xuu5ReVdRD2poRixQ==", null, false, "e4774f2f-d477-4b37-b025-ac43d5b04532", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59763751-b087-4d7c-ab66-67051e69e999", "05232d9f-6430-4b3b-aaa7-9163fbdeaf3c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckList");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59763751-b087-4d7c-ab66-67051e69e999", "05232d9f-6430-4b3b-aaa7-9163fbdeaf3c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59763751-b087-4d7c-ab66-67051e69e999");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "05232d9f-6430-4b3b-aaa7-9163fbdeaf3c");

            migrationBuilder.RenameColumn(
                name: "StrategyID",
                table: "Strategies",
                newName: "ID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae806b8b-2517-4bcd-900e-826298af9e19", "b935458b-2c40-43f0-a4db-9da1186360ab", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84ae40c0-cc05-4577-8123-c03b89c3d0e6", 0, "d53498ea-0b78-4320-b064-a4d6ccfcbbb1", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEDyN4CP0FHFeu7vf4Mo3nLcDZOOeLIRJImDN+vYXhL5UmTEmjm5uDuMmaeZiKnP3pg==", null, false, "e3959103-b616-4af0-9e75-55ddbeec66f5", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ae806b8b-2517-4bcd-900e-826298af9e19", "84ae40c0-cc05-4577-8123-c03b89c3d0e6" });
        }
    }
}
