using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingRitual.Data.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ExitStrategies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExitStrategies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PairPicked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentalState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrategyPicked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeTrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradingTrend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradingCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitStrategy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptanceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RewardRatio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetDailyGoal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExplainTrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currencies = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Strategies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TradingHours",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingHours", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExitStrategies");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "Strategies");

            migrationBuilder.DropTable(
                name: "TradingHours");

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
    }
}
