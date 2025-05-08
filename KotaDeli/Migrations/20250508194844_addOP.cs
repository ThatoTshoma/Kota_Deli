using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KotaDeli.Migrations
{
    /// <inheritdoc />
    public partial class addOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryFee",
                table: "Orders",
                newName: "DeliveryOption");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryOption",
                table: "Orders",
                newName: "DeliveryFee");
        }
    }
}
