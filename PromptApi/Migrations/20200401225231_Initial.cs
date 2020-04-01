using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromptApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prompts",
                columns: table => new
                {
                    PromptId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Journal = table.Column<string>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.PromptId);
                });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "PromptId", "AuthorName", "Content", "Journal", "Title" },
                values: new object[] { 2, "Dave", "Dave had a story, but then again, so does everyone", "Daves Journal", "Dave's Story" });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "PromptId", "AuthorName", "Content", "Journal", "Title" },
                values: new object[] { 1, "Jimmyboy", "Jimmy is a dude, pretty cool dude, but is not a template writing-prompt, funny how that works", "Jimmy Journal", "Matilda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prompts");
        }
    }
}
