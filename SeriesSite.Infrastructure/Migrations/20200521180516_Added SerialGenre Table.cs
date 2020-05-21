using Microsoft.EntityFrameworkCore.Migrations;

namespace SeriesSite.Infrastructure.Migrations
{
    public partial class AddedSerialGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Serials_Countries_CountryId",
                table: "Serials");

            migrationBuilder.DropIndex(
                name: "IX_Genres_SerialId",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serials",
                table: "Serials");

            migrationBuilder.DropColumn(
                name: "SerialId",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Serials",
                newName: "Series");

            migrationBuilder.RenameIndex(
                name: "IX_Serials_CountryId",
                table: "Series",
                newName: "IX_Series_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SerialGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialId = table.Column<int>(nullable: true),
                    GenreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SerialGenres_Series_SerialId",
                        column: x => x.SerialId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SerialGenres_GenreId",
                table: "SerialGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialGenres_SerialId",
                table: "SerialGenres",
                column: "SerialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Countries_CountryId",
                table: "Series",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Countries_CountryId",
                table: "Series");

            migrationBuilder.DropTable(
                name: "SerialGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serials");

            migrationBuilder.RenameIndex(
                name: "IX_Series_CountryId",
                table: "Serials",
                newName: "IX_Serials_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "SerialId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serials",
                table: "Serials",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SerialId",
                table: "Genres",
                column: "SerialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Serials_SerialId",
                table: "Genres",
                column: "SerialId",
                principalTable: "Serials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Serials_Countries_CountryId",
                table: "Serials",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
