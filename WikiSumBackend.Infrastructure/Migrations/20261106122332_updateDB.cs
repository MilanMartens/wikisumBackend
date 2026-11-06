using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WikiSumBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Summary_Chapter_ChapterId",
                table: "Summary");

            migrationBuilder.RenameColumn(
                name: "ChapterId",
                table: "Summary",
                newName: "ChapterTranslationId");

            migrationBuilder.RenameIndex(
                name: "IX_Summary_ChapterId",
                table: "Summary",
                newName: "IX_Summary_ChapterTranslationId");

            migrationBuilder.CreateTable(
                name: "ChapterTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    ChapterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterTranslation_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterTranslation_ChapterId_Language",
                table: "ChapterTranslation",
                columns: new[] { "ChapterId", "Language" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Summary_ChapterTranslation_ChapterTranslationId",
                table: "Summary",
                column: "ChapterTranslationId",
                principalTable: "ChapterTranslation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Summary_ChapterTranslation_ChapterTranslationId",
                table: "Summary");

            migrationBuilder.DropTable(
                name: "ChapterTranslation");

            migrationBuilder.RenameColumn(
                name: "ChapterTranslationId",
                table: "Summary",
                newName: "ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_Summary_ChapterTranslationId",
                table: "Summary",
                newName: "IX_Summary_ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Summary_Chapter_ChapterId",
                table: "Summary",
                column: "ChapterId",
                principalTable: "Chapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
