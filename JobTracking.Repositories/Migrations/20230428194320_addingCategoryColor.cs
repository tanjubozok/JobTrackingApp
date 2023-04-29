using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracking.Repositories.Migrations
{
    public partial class addingCategoryColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 28, 19, 43, 20, 619, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 28, 19, 43, 20, 619, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 28, 19, 43, 20, 619, DateTimeKind.Utc).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 28, 22, 43, 20, 620, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 28, 22, 43, 20, 620, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 28, 22, 43, 20, 620, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 28, 22, 43, 20, 620, DateTimeKind.Local).AddTicks(178));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 27, 17, 16, 37, 708, DateTimeKind.Utc).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 27, 17, 16, 37, 708, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 27, 17, 16, 37, 708, DateTimeKind.Utc).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 27, 20, 16, 37, 708, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 27, 20, 16, 37, 708, DateTimeKind.Local).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 27, 20, 16, 37, 708, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "Workings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 27, 20, 16, 37, 708, DateTimeKind.Local).AddTicks(6824));
        }
    }
}
