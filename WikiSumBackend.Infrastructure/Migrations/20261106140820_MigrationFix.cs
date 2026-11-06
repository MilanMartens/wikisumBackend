using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiSumBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Summary");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Chapter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Summary",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Chapter",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
