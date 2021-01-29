using System;
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
                keyValues: new object[] { "30297bb7-b14d-4056-9345-b214a611fba0", "dc68532a-fef5-4964-81eb-218d13eacdc8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30297bb7-b14d-4056-9345-b214a611fba0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc68532a-fef5-4964-81eb-218d13eacdc8");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "30297bb7-b14d-4056-9345-b214a611fba0", "1b556f1c-374e-492a-ac28-7bb132ad6c50", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc68532a-fef5-4964-81eb-218d13eacdc8", 0, "a6d970d0-24f4-4628-874f-949403343f45", "admin@tradingritual.com", true, "ADMIN", false, null, "admin@tradingritual.com", "admin@tradingritual.com", "AQAAAAEAACcQAAAAEJwRz4Wei3fF9vPol0LyYp6Sl9GUp/EOyHmi1WMcPUe4i6xPoDJYLFFz33cm71+4uw==", null, false, "6cd67a46-a543-499b-8092-82fd0dafa956", false, "admin@tradingritual.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "30297bb7-b14d-4056-9345-b214a611fba0", "dc68532a-fef5-4964-81eb-218d13eacdc8" });
        }
    }
}
