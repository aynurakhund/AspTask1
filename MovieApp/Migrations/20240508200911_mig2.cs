using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieImdbs");

            migrationBuilder.AddColumn<int>(
                name: "ImdbId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ImdbId",
                table: "Movies",
                column: "ImdbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Imdbs_ImdbId",
                table: "Movies",
                column: "ImdbId",
                principalTable: "Imdbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Imdbs_ImdbId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ImdbId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImdbId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieImdbs",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ImdbId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieImdbs", x => new { x.MovieId, x.ImdbId });
                    table.ForeignKey(
                        name: "FK_MovieImdbs_Imdbs_ImdbId",
                        column: x => x.ImdbId,
                        principalTable: "Imdbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieImdbs_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieImdbs_ImdbId",
                table: "MovieImdbs",
                column: "ImdbId");
        }
    }
}
