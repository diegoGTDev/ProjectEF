using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "description", "name", "weight" },
                values: new object[,]
                {
                    { new Guid("48370ccf-8013-41a3-9495-95ba8ea41602"), "Work tasks", "Work", 50 },
                    { new Guid("48370ccf-8013-41a3-9495-95ba8ea416fb"), "Personal tasks", "Personal", 15 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "CategoryID", "CreationDate", "Description", "IsCompleted", "TaskPriority", "Title" },
                values: new object[] { new Guid("48370ccf-8013-41a3-9495-95ba8ea41601"), new Guid("48370ccf-8013-41a3-9495-95ba8ea416fb"), new DateTime(2023, 8, 8, 19, 32, 3, 164, DateTimeKind.Local).AddTicks(442), "Study Math for the sunday", false, 0, "Study for exam" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: new Guid("48370ccf-8013-41a3-9495-95ba8ea41602"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: new Guid("48370ccf-8013-41a3-9495-95ba8ea41601"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: new Guid("48370ccf-8013-41a3-9495-95ba8ea416fb"));
        }
    }
}
