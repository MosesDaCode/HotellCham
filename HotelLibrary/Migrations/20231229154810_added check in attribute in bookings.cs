using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addedcheckinattributeinbookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedIn",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckedIn",
                table: "Bookings");
        }
    }
}
