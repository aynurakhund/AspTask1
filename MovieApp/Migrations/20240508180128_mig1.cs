using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directorss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imdbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImdbPoint = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imdbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subtitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directorss_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directorss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "MovieSubtitles",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    SubtitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSubtitles", x => new { x.MovieId, x.SubtitleId });
                    table.ForeignKey(
                        name: "FK_MovieSubtitles_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSubtitles_Subtitles_SubtitleId",
                        column: x => x.SubtitleId,
                        principalTable: "Subtitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieImdbs_ImdbId",
                table: "MovieImdbs",
                column: "ImdbId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSubtitles_SubtitleId",
                table: "MovieSubtitles",
                column: "SubtitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieImdbs");

            migrationBuilder.DropTable(
                name: "MovieSubtitles");

            migrationBuilder.DropTable(
                name: "Imdbs");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Subtitles");

            migrationBuilder.DropTable(
                name: "Directorss");
        }
    }
}
