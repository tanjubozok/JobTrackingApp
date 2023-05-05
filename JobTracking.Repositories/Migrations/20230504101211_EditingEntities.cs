using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracking.Repositories.Migrations
{
    public partial class EditingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "CreatedDate" },
                values: new object[] { "danger", new DateTime(2023, 5, 4, 10, 12, 11, 492, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "CreatedDate" },
                values: new object[] { "success", new DateTime(2023, 5, 4, 10, 12, 11, 492, DateTimeKind.Utc).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "CreatedDate" },
                values: new object[] { "info", new DateTime(2023, 5, 4, 10, 12, 11, 492, DateTimeKind.Utc).AddTicks(7569) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "CreatedDate" },
                values: new object[] { null, new DateTime(2023, 5, 1, 16, 44, 51, 903, DateTimeKind.Utc).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "CreatedDate" },
                values: new object[] { null, new DateTime(2023, 5, 1, 16, 44, 51, 903, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "CreatedDate" },
                values: new object[] { null, new DateTime(2023, 5, 1, 16, 44, 51, 903, DateTimeKind.Utc).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 19, 44, 51, 903, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 19, 44, 51, 903, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 19, 44, 51, 903, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 19, 44, 51, 903, DateTimeKind.Local).AddTicks(7692));
        }
    }
}
