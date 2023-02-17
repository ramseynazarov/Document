using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Document.Migrations
{
    /// <inheritdoc />
    public partial class addenddatetimedefaultvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b2f3eba-9da2-4b10-94ff-a5b1d5590522"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6cae10f5-487d-44e4-a37d-b32150a0a143"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 10, 17, 43, 743, DateTimeKind.Local).AddTicks(1500),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2023, 2, 17, 5, 17, 43, 743, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("13443143-aa30-48eb-9224-9726acc4d7f9"), new DateTime(2023, 2, 17, 5, 17, 43, 922, DateTimeKind.Utc).AddTicks(2160), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Гость", "$2b$10$YOMhNZfCRbZ.U.Zdsh8sWuzTj7SnXN0gmEUjjMdFvOALhoUIhWYMi", "+000000000001" },
                    { new Guid("3ce8aacd-511e-40cc-86a4-5aa914272cdb"), new DateTime(2023, 2, 17, 5, 17, 43, 832, DateTimeKind.Utc).AddTicks(7080), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Админ", "$2b$10$QhvTwjutc7nmcYhbmjF1U.5tYSe2p6SpkdKAh/CHYty1tUPTcX/t.", "+000000000000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13443143-aa30-48eb-9224-9726acc4d7f9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3ce8aacd-511e-40cc-86a4-5aa914272cdb"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 2, 18, 10, 17, 43, 743, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2023, 2, 17, 4, 26, 33, 812, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("3b2f3eba-9da2-4b10-94ff-a5b1d5590522"), new DateTime(2023, 2, 17, 4, 26, 33, 903, DateTimeKind.Utc).AddTicks(1240), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Админ", "$2b$10$me.xSUROj1zXHFUACsbgZOCZHpLOn06W1vcB26k8KEU72a/76llU6", "+000000000000" },
                    { new Guid("6cae10f5-487d-44e4-a37d-b32150a0a143"), new DateTime(2023, 2, 17, 4, 26, 33, 994, DateTimeKind.Utc).AddTicks(160), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Гость", "$2b$10$NvMlzXdWSt1K89aaaxW7UuCF7pUK2ZaqjR62ARrhncv0Ap8KmVGWi", "+000000000001" }
                });
        }
    }
}
