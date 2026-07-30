using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KittenRs.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddModifiedToPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Modified",
                table: "Posts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Posts");
        }
    }
}
