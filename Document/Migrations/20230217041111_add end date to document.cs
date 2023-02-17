using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Document.Migrations
{
    /// <inheritdoc />
    public partial class addenddatetodocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d1778f6-800e-413e-9f1e-496d8cdb612c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822f7ffc-f18c-4fb6-ac33-19dc2761b84c"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09ed7fac-e65a-4950-acb5-ec678275a90b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cfa0dd4a-7ff8-4aa1-8df8-f2749ef9065f"));

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"),
                column: "CreatedAt",
                value: new DateTime(2023, 2, 12, 16, 50, 45, 478, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("3d1778f6-800e-413e-9f1e-496d8cdb612c"), new DateTime(2023, 2, 12, 16, 50, 45, 572, DateTimeKind.Utc).AddTicks(9490), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Админ", "$2b$10$Mf0hbs7LruLOcVir37XizOjmsyu8AEx0i82Siqne4mlLK5oXr80Ke", "+000000000000" },
                    { new Guid("822f7ffc-f18c-4fb6-ac33-19dc2761b84c"), new DateTime(2023, 2, 12, 16, 50, 45, 732, DateTimeKind.Utc).AddTicks(5180), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Гость", "$2b$10$BXbbDRqd5aBQW.J359mfvOsE2JVNqh2G9bHu/htvyP3H8fI8kzco2", "+000000000001" }
                });
        }
    }
}
