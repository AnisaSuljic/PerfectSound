using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectSound.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompany",
                columns: table => new
                {
                    ProductionCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompany", x => x.ProductionCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "Person_Gender",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongAndPodcast",
                columns: table => new
                {
                    SongAndPodcastID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunningTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: true),
                    Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    NumberOfRatings = table.Column<int>(type: "int", nullable: true),
                    ProductionCompanyID = table.Column<int>(type: "int", nullable: true),
                    IsPodcast = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongAndPodcast", x => x.SongAndPodcastID);
                    table.ForeignKey(
                        name: "SongAndPodcast_ProductionCompany",
                        column: x => x.ProductionCompanyID,
                        principalTable: "ProductionCompany",
                        principalColumn: "ProductionCompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "User_UserType",
                        column: x => x.UserTypeID,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastSeason",
                columns: table => new
                {
                    PodcastSeasonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongAndPodcastID = table.Column<int>(type: "int", nullable: true),
                    SeasonName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastSeason", x => x.PodcastSeasonID);
                    table.ForeignKey(
                        name: "SongAndPodcastSeason_SongAndPodcast",
                        column: x => x.SongAndPodcastID,
                        principalTable: "SongAndPodcast",
                        principalColumn: "SongAndPodcastID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    QuoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongAndPodcastID = table.Column<int>(type: "int", nullable: true),
                    QuoteText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.QuoteID);
                    table.ForeignKey(
                        name: "Quote_SongAndPodcast",
                        column: x => x.SongAndPodcastID,
                        principalTable: "SongAndPodcast",
                        principalColumn: "SongAndPodcastID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongAndPodcastGenre",
                columns: table => new
                {
                    SongAndPodcastGenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongAndPodcastID = table.Column<int>(type: "int", nullable: true),
                    GenreID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongAndPodcastGenre", x => x.SongAndPodcastGenreID);
                    table.ForeignKey(
                        name: "SongAndPodcastGenre_Genre",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SongAndPodcastGenre_SongAndPodcast",
                        column: x => x.SongAndPodcastID,
                        principalTable: "SongAndPodcast",
                        principalColumn: "SongAndPodcastID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongAndPodcastPerson",
                columns: table => new
                {
                    SongAndPodcastPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongAndPodcastID = table.Column<int>(type: "int", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongAndPodcastPerson", x => x.SongAndPodcastPersonID);
                    table.ForeignKey(
                        name: "SongAndPodcastPerson_Person",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SongAndPodcastPerson_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SongAndPodcastPerson_SongAndPodcast",
                        column: x => x.SongAndPodcastID,
                        principalTable: "SongAndPodcast",
                        principalColumn: "SongAndPodcastID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongAndPodcastID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    DateTimeOfComment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "Comment_SongAndPodcast",
                        column: x => x.SongAndPodcastID,
                        principalTable: "SongAndPodcast",
                        principalColumn: "SongAndPodcastID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Comment_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsID);
                    table.ForeignKey(
                        name: "User_News",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongAndPodcastID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    RatingValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                    table.ForeignKey(
                        name: "Rating_SongAndPodcast",
                        column: x => x.SongAndPodcastID,
                        principalTable: "SongAndPodcast",
                        principalColumn: "SongAndPodcastID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Rating_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastSeasonEpisode",
                columns: table => new
                {
                    PodcastSeasonEpisodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastSeasonID = table.Column<int>(type: "int", nullable: true),
                    EpisodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastSeasonEpisode", x => x.PodcastSeasonEpisodeID);
                    table.ForeignKey(
                        name: "PodcastSeason_SongAndPodcast",
                        column: x => x.PodcastSeasonID,
                        principalTable: "PodcastSeason",
                        principalColumn: "PodcastSeasonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SongAndPodcastID",
                table: "Comment",
                column: "SongAndPodcastID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserID",
                table: "News",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_GenderID",
                table: "Person",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastSeason_SongAndPodcastID",
                table: "PodcastSeason",
                column: "SongAndPodcastID");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastSeasonEpisode_PodcastSeasonID",
                table: "PodcastSeasonEpisode",
                column: "PodcastSeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_SongAndPodcastID",
                table: "Quote",
                column: "SongAndPodcastID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_SongAndPodcastID",
                table: "Rating",
                column: "SongAndPodcastID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserID",
                table: "Rating",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAndPodcast_ProductionCompanyID",
                table: "SongAndPodcast",
                column: "ProductionCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAndPodcastGenre_GenreID",
                table: "SongAndPodcastGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAndPodcastGenre_SongAndPodcastID",
                table: "SongAndPodcastGenre",
                column: "SongAndPodcastID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAndPodcastPerson_PersonID",
                table: "SongAndPodcastPerson",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAndPodcastPerson_RoleID",
                table: "SongAndPodcastPerson",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAndPodcastPerson_SongAndPodcastID",
                table: "SongAndPodcastPerson",
                column: "SongAndPodcastID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PodcastSeasonEpisode");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "SongAndPodcastGenre");

            migrationBuilder.DropTable(
                name: "SongAndPodcastPerson");

            migrationBuilder.DropTable(
                name: "PodcastSeason");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SongAndPodcast");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "ProductionCompany");
        }
    }
}
