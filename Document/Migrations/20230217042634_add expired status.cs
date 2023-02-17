using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Document.Migrations
{
    /// <inheritdoc />
    public partial class addexpiredstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09ed7fac-e65a-4950-acb5-ec678275a90b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cfa0dd4a-7ff8-4aa1-8df8-f2749ef9065f"));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2023, 2, 17, 4, 26, 33, 812, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Время истекло" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("3b2f3eba-9da2-4b10-94ff-a5b1d5590522"), new DateTime(2023, 2, 17, 4, 26, 33, 903, DateTimeKind.Utc).AddTicks(1240), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Админ", "$2b$10$me.xSUROj1zXHFUACsbgZOCZHpLOn06W1vcB26k8KEU72a/76llU6", "+000000000000" },
                    { new Guid("6cae10f5-487d-44e4-a37d-b32150a0a143"), new DateTime(2023, 2, 17, 4, 26, 33, 994, DateTimeKind.Utc).AddTicks(160), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Гость", "$2b$10$NvMlzXdWSt1K89aaaxW7UuCF7pUK2ZaqjR62ARrhncv0Ap8KmVGWi", "+000000000001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b2f3eba-9da2-4b10-94ff-a5b1d5590522"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6cae10f5-487d-44e4-a37d-b32150a0a143"));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2023, 2, 17, 4, 11, 11, 472, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("09ed7fac-e65a-4950-acb5-ec678275a90b"), new DateTime(2023, 2, 17, 4, 11, 11, 653, DateTimeKind.Utc).AddTicks(1860), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Гость", "$2b$10$xa5Pd4OmWFoslzdC54CTduciowguiy1HjeqkBRql4jWt8Xmh9Wk2W", "+000000000001" },
                    { new Guid("cfa0dd4a-7ff8-4aa1-8df8-f2749ef9065f"), new DateTime(2023, 2, 17, 4, 11, 11, 562, DateTimeKind.Utc).AddTicks(8610), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Админ", "$2b$10$e3Ul5CCFOawMaoux9BtYYuH74V6YMzznYYTfm8DPP2vsYJiDH9oYO", "+000000000000" }
                });
        }
    }
}
