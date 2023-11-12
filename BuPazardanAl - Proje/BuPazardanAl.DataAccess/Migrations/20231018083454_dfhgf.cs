using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuPazardanAl.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dfhgf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerName",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerName",
                table: "Sellers");
        }
    }
}
