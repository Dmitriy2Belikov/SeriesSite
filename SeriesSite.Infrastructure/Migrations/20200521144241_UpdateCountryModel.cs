using Microsoft.EntityFrameworkCore.Migrations;

namespace SeriesSite.Infrastructure.Migrations
{
    public partial class UpdateCountryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Serials_SerialId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_SerialId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "SerialId",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Serials",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serials_CountryId",
                table: "Serials",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Serials_Countries_CountryId",
                table: "Serials",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serials_Countries_CountryId",
                table: "Serials");

            migrationBuilder.DropIndex(
                name: "IX_Serials_CountryId",
                table: "Serials");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Serials");

            migrationBuilder.AddColumn<int>(
                name: "SerialId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SerialId",
                table: "Countries",
                column: "SerialId",
                unique: true,
                filter: "[SerialId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Serials_SerialId",
                table: "Countries",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
