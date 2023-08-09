using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnWeightCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "weight",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "weight",
                table: "Category");
        }
    }
}
