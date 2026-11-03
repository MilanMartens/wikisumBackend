using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiSumBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedTypo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Summarie_Chapter_ChapterId",
                table: "Summarie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summarie",
                table: "Summarie");

            migrationBuilder.RenameTable(
                name: "Summarie",
                newName: "Summary");

            migrationBuilder.RenameIndex(
                name: "IX_Summarie_ChapterId",
                table: "Summary",
                newName: "IX_Summary_ChapterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summary",
                table: "Summary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Summary_Chapter_ChapterId",
                table: "Summary",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Summary_Chapter_ChapterId",
                table: "Summary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summary",
                table: "Summary");

            migrationBuilder.RenameTable(
                name: "Summary",
                newName: "Summarie");

            migrationBuilder.RenameIndex(
                name: "IX_Summary_ChapterId",
                table: "Summarie",
                newName: "IX_Summarie_ChapterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summarie",
                table: "Summarie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Summarie_Chapter_ChapterId",
                table: "Summarie",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
