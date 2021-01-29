using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingRitual.Data.Migrations
{
    public partial class UpdateFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExitStrategies_Forms_FormID",
                table: "ExitStrategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Forms_FormID",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_Forms_FormID",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_FormID",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_FormID",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_ExitStrategies_FormID",
                table: "ExitStrategies");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "026f1e7f-ec0b-47a3-8f8a-331cb831f104", "efb30fad-61dd-4573-b496-c4e063eb96bd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "026f1e7f-ec0b-47a3-8f8a-331cb831f104");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efb30fad-61dd-4573-b496-c4e063eb96bd");

            migrationBuilder.DropColumn(
                name: "FormID",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "FormID",
                table: "Pairs");

            migrationBuilder.DropColumn(
                name: "FormID",
                table: "ExitStrategies");

            migrationBuilder.AddColumn<string>(
                name: "ExitStrategy",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PairPicked",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrategyPicked",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ExitStrategy",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "PairPicked",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "StrategyPicked",
                table: "Forms");

            migrationBuilder.AddColumn<Guid>(
                name: "FormID",
                table: "Strategies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormID",
                table: "Pairs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormID",
                table: "ExitStrategies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "026f1e7f-ec0b-47a3-8f8a-331cb831f104", "4b8c2637-2763-4e2f-bbc5-59131ddd6bd1", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "efb30fad-61dd-4573-b496-c4e063eb96bd", 0, "fc768de7-6972-4339-a4ff-7e5491592ef5", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEETKod/3Ixf9bL6EwxsQ7iW0VoX7Bu4Z4DNUJk1iXKP09ISfN/wmjLXDQhOceunzQw==", null, false, "bc77195a-9508-467e-bc8c-5c8076b75151", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "026f1e7f-ec0b-47a3-8f8a-331cb831f104", "efb30fad-61dd-4573-b496-c4e063eb96bd" });

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_FormID",
                table: "Strategies",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_FormID",
                table: "Pairs",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_ExitStrategies_FormID",
                table: "ExitStrategies",
                column: "FormID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExitStrategies_Forms_FormID",
                table: "ExitStrategies",
                column: "FormID",
                principalTable: "Forms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Forms_FormID",
                table: "Pairs",
                column: "FormID",
                principalTable: "Forms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_Forms_FormID",
                table: "Strategies",
                column: "FormID",
                principalTable: "Forms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
