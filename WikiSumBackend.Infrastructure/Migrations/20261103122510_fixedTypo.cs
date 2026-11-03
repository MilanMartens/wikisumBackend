using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiSumBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Webpages_WebpageId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Summaries_Chapters_ChapterId",
                table: "Summaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Webpages",
                table: "Webpages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summaries",
                table: "Summaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters");

            migrationBuilder.RenameTable(
                name: "Webpages",
                newName: "Webpage");

            migrationBuilder.RenameTable(
                name: "Summaries",
                newName: "Summarie");

            migrationBuilder.RenameTable(
                name: "Chapters",
                newName: "Chapter");

            migrationBuilder.RenameIndex(
                name: "IX_Summaries_ChapterId",
                table: "Summarie",
                newName: "IX_Summarie_ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapters_WebpageId",
                table: "Chapter",
                newName: "IX_Chapter_WebpageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Webpage",
                table: "Webpage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summarie",
                table: "Summarie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Webpage_WebpageId",
                table: "Chapter",
                column: "WebpageId",
                principalTable: "Webpage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Summarie_Chapter_ChapterId",
                table: "Summarie",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Webpage_WebpageId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Summarie_Chapter_ChapterId",
                table: "Summarie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Webpage",
                table: "Webpage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Summarie",
                table: "Summarie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter");

            migrationBuilder.RenameTable(
                name: "Webpage",
                newName: "Webpages");

            migrationBuilder.RenameTable(
                name: "Summarie",
                newName: "Summaries");

            migrationBuilder.RenameTable(
                name: "Chapter",
                newName: "Chapters");

            migrationBuilder.RenameIndex(
                name: "IX_Summarie_ChapterId",
                table: "Summaries",
                newName: "IX_Summaries_ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapter_WebpageId",
                table: "Chapters",
                newName: "IX_Chapters_WebpageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Webpages",
                table: "Webpages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Summaries",
                table: "Summaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Webpages_WebpageId",
                table: "Chapters",
                column: "WebpageId",
                principalTable: "Webpages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Summaries_Chapters_ChapterId",
                table: "Summaries",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
