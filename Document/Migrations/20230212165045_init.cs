using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Document.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DocumentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Topic = table.Column<string>(type: "TEXT", nullable: true),
                    Correspondent = table.Column<string>(type: "TEXT", nullable: true),
                    CorrespondentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAtCorrespondent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DocumentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDocuments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), new DateTime(2023, 2, 12, 16, 50, 45, 478, DateTimeKind.Utc).AddTicks(9890), "РТСУ" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Новый" },
                    { 2, "В процессе" },
                    { 3, "Отказано" },
                    { 4, "Одобрено" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { new Guid("3d1778f6-800e-413e-9f1e-496d8cdb612c"), new DateTime(2023, 2, 12, 16, 50, 45, 572, DateTimeKind.Utc).AddTicks(9490), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Админ", "$2b$10$Mf0hbs7LruLOcVir37XizOjmsyu8AEx0i82Siqne4mlLK5oXr80Ke", "+000000000000" },
                    { new Guid("822f7ffc-f18c-4fb6-ac33-19dc2761b84c"), new DateTime(2023, 2, 12, 16, 50, 45, 732, DateTimeKind.Utc).AddTicks(5180), new Guid("c446e52f-223d-4ddc-810c-d4f6b345f440"), "Гость", "$2b$10$BXbbDRqd5aBQW.J359mfvOsE2JVNqh2G9bHu/htvyP3H8fI8kzco2", "+000000000001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DepartmentId",
                table: "Documents",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StatusId",
                table: "Documents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserId",
                table: "Documents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_DocumentId",
                table: "UserDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocuments_UserId",
                table: "UserDocuments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDocuments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
