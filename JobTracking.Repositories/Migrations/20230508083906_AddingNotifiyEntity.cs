using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracking.Repositories.Migrations
{
    public partial class AddingNotifiyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 5, 8, 8, 39, 6, 395, DateTimeKind.Utc).AddTicks(4481), "La en de ja kaj ni eraris haveno kun la diris tiel estus mi havu kaj hejmon lasi kun kuragxis" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 5, 8, 8, 39, 6, 395, DateTimeKind.Utc).AddTicks(4484), "Terbordo la mi la de tiuj kiu al sxipon al lingvo havis aux ne mi de povinta hejmon tukoj la" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 5, 8, 8, 39, 6, 395, DateTimeKind.Utc).AddTicks(4486), "La trinki farigis maron sed estas mi tion turko kompreni direktilon kaj la sian tro ni se cxefo por kiu" });

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 11, 39, 6, 395, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 11, 39, 6, 395, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 11, 39, 6, 395, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 11, 39, 6, 395, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AppUserId",
                table: "Notifications",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 5, 4, 10, 12, 11, 492, DateTimeKind.Utc).AddTicks(7562), "Öncelik verilecek iş" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 5, 4, 10, 12, 11, 492, DateTimeKind.Utc).AddTicks(7566), "Öncelik verilecek iş" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2023, 5, 4, 10, 12, 11, 492, DateTimeKind.Utc).AddTicks(7569), "Öncelik verilecek iş" });

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 4, 13, 12, 11, 492, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 4, 13, 12, 11, 492, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 4, 13, 12, 11, 492, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 4, 13, 12, 11, 492, DateTimeKind.Local).AddTicks(7785));
        }
    }
}
