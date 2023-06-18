using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationRider.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogPostProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "BlogPost");
        }
    }
}
