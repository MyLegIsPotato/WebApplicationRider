using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationRider.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBlogPostProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "BlogPost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "BlogPost",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
