﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnIsCompletedTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Task");
        }
    }
}
