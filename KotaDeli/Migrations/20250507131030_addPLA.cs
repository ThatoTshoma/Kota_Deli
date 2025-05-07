using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KotaDeli.Migrations
{
    /// <inheritdoc />
    public partial class addPLA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Province_ProvinceId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Suburb_SuburbId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suburb_City_CityId",
                table: "Suburb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suburb",
                table: "Suburb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Province",
                table: "Province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "Suburb",
                newName: "Suburbs");

            migrationBuilder.RenameTable(
                name: "Province",
                newName: "Provinces");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_Suburb_CityId",
                table: "Suburbs",
                newName: "IX_Suburbs_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_City_ProvinceId",
                table: "Cities",
                newName: "IX_Cities_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suburbs",
                table: "Suburbs",
                column: "SuburbId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Suburbs_SuburbId",
                table: "Customers",
                column: "SuburbId",
                principalTable: "Suburbs",
                principalColumn: "SuburbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suburbs_Cities_CityId",
                table: "Suburbs",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Suburbs_SuburbId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suburbs_Cities_CityId",
                table: "Suburbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suburbs",
                table: "Suburbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Suburbs",
                newName: "Suburb");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "Province");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_Suburbs_CityId",
                table: "Suburb",
                newName: "IX_Suburb_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_ProvinceId",
                table: "City",
                newName: "IX_City_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suburb",
                table: "Suburb",
                column: "SuburbId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Province",
                table: "Province",
                column: "ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Province_ProvinceId",
                table: "City",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Suburb_SuburbId",
                table: "Customers",
                column: "SuburbId",
                principalTable: "Suburb",
                principalColumn: "SuburbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suburb_City_CityId",
                table: "Suburb",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
