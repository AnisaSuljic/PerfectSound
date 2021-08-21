﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerfectSound.Database;

namespace PerfectSound.Migrations
{
    [DbContext(typeof(PerfectSoundContext))]
    [Migration("20210821150443_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Bosnian_Latin_100_BIN")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PerfectSound.Database.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CommentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateTimeOfComment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SongAndPodcastId")
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("CommentId");

                    b.HasIndex("SongAndPodcastId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("PerfectSound.Database.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GenderID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("PerfectSound.Database.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GenreID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("PerfectSound.Database.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NewsID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("CoverPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("NewsId");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("PerfectSound.Database.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PersonID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int")
                        .HasColumnName("GenderID");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("GenderId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("PerfectSound.Database.PodcastSeason", b =>
                {
                    b.Property<int>("PodcastSeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PodcastSeasonID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SeasonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SongAndPodcastId")
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastID");

                    b.HasKey("PodcastSeasonId");

                    b.HasIndex("SongAndPodcastId");

                    b.ToTable("PodcastSeason");
                });

            modelBuilder.Entity("PerfectSound.Database.PodcastSeasonEpisode", b =>
                {
                    b.Property<int>("PodcastSeasonEpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PodcastSeasonEpisodeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EpisodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<int?>("PodcastSeasonId")
                        .HasColumnType("int")
                        .HasColumnName("PodcastSeasonID");

                    b.HasKey("PodcastSeasonEpisodeId");

                    b.HasIndex("PodcastSeasonId");

                    b.ToTable("PodcastSeasonEpisode");
                });

            modelBuilder.Entity("PerfectSound.Database.ProductionCompany", b =>
                {
                    b.Property<int>("ProductionCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductionCompanyID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductionCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductionCompanyId");

                    b.ToTable("ProductionCompany");
                });

            modelBuilder.Entity("PerfectSound.Database.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("QuoteID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuoteText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SongAndPodcastId")
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastID");

                    b.HasKey("QuoteId");

                    b.HasIndex("SongAndPodcastId");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("PerfectSound.Database.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RatingID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RatingValue")
                        .HasColumnType("int");

                    b.Property<int?>("SongAndPodcastId")
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("RatingId");

                    b.HasIndex("SongAndPodcastId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("PerfectSound.Database.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PerfectSound.Database.SongAndPodcast", b =>
                {
                    b.Property<int>("SongAndPodcastId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Budget")
                        .HasColumnType("money");

                    b.Property<bool?>("IsPodcast")
                        .HasColumnType("bit");

                    b.Property<int?>("NumberOfRatings")
                        .HasColumnType("int");

                    b.Property<byte[]>("Poster")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("ProductionCompanyId")
                        .HasColumnType("int")
                        .HasColumnName("ProductionCompanyID");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RunningTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongAndPodcastId");

                    b.HasIndex("ProductionCompanyId");

                    b.ToTable("SongAndPodcast");
                });

            modelBuilder.Entity("PerfectSound.Database.SongAndPodcastGenre", b =>
                {
                    b.Property<int>("SongAndPodcastGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastGenreID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("GenreID");

                    b.Property<int?>("SongAndPodcastId")
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastID");

                    b.HasKey("SongAndPodcastGenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("SongAndPodcastId");

                    b.ToTable("SongAndPodcastGenre");
                });

            modelBuilder.Entity("PerfectSound.Database.SongAndPodcastPerson", b =>
                {
                    b.Property<int>("SongAndPodcastPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastPersonID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PersonID");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<int?>("SongAndPodcastId")
                        .HasColumnType("int")
                        .HasColumnName("SongAndPodcastID");

                    b.HasKey("SongAndPodcastPersonId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SongAndPodcastId");

                    b.ToTable("SongAndPodcastPerson");
                });

            modelBuilder.Entity("PerfectSound.Database.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeID");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PerfectSound.Database.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("PerfectSound.Database.Comment", b =>
                {
                    b.HasOne("PerfectSound.Database.SongAndPodcast", "SongAndPodcast")
                        .WithMany("Comments")
                        .HasForeignKey("SongAndPodcastId")
                        .HasConstraintName("Comment_SongAndPodcast")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PerfectSound.Database.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Comment_User")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("SongAndPodcast");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PerfectSound.Database.News", b =>
                {
                    b.HasOne("PerfectSound.Database.User", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId")
                        .HasConstraintName("User_News")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("PerfectSound.Database.Person", b =>
                {
                    b.HasOne("PerfectSound.Database.Gender", "Gender")
                        .WithMany("People")
                        .HasForeignKey("GenderId")
                        .HasConstraintName("Person_Gender")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("PerfectSound.Database.PodcastSeason", b =>
                {
                    b.HasOne("PerfectSound.Database.SongAndPodcast", "SongAndPodcast")
                        .WithMany("PodcastSeasons")
                        .HasForeignKey("SongAndPodcastId")
                        .HasConstraintName("SongAndPodcastSeason_SongAndPodcast")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("SongAndPodcast");
                });

            modelBuilder.Entity("PerfectSound.Database.PodcastSeasonEpisode", b =>
                {
                    b.HasOne("PerfectSound.Database.PodcastSeason", "PodcastSeason")
                        .WithMany("PodcastSeasonEpisodes")
                        .HasForeignKey("PodcastSeasonId")
                        .HasConstraintName("PodcastSeason_SongAndPodcast")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("PodcastSeason");
                });

            modelBuilder.Entity("PerfectSound.Database.Quote", b =>
                {
                    b.HasOne("PerfectSound.Database.SongAndPodcast", "SongAndPodcast")
                        .WithMany("Quotes")
                        .HasForeignKey("SongAndPodcastId")
                        .HasConstraintName("Quote_SongAndPodcast")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("SongAndPodcast");
                });

            modelBuilder.Entity("PerfectSound.Database.Rating", b =>
                {
                    b.HasOne("PerfectSound.Database.SongAndPodcast", "SongAndPodcast")
                        .WithMany("Ratings")
                        .HasForeignKey("SongAndPodcastId")
                        .HasConstraintName("Rating_SongAndPodcast")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PerfectSound.Database.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("Rating_User")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("SongAndPodcast");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PerfectSound.Database.SongAndPodcast", b =>
                {
                    b.HasOne("PerfectSound.Database.ProductionCompany", "ProductionCompany")
                        .WithMany("SongAndPodcasts")
                        .HasForeignKey("ProductionCompanyId")
                        .HasConstraintName("SongAndPodcast_ProductionCompany")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProductionCompany");
                });

            modelBuilder.Entity("PerfectSound.Database.SongAndPodcastGenre", b =>
                {
                    b.HasOne("PerfectSound.Database.Genre", "Genre")
                        .WithMany("SongAndPodcastGenres")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("SongAndPodcastGenre_Genre")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PerfectSound.Database.SongAndPodcast", "SongAndPodcast")
                        .WithMany("SongAndPodcastGenres")
                        .HasForeignKey("SongAndPodcastId")
                        .HasConstraintName("SongAndPodcastGenre_SongAndPodcast")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Genre");

                    b.Navigation("SongAndPodcast");
                });

            modelBuilder.Entity("PerfectSound.Database.SongAndPodcastPerson", b =>
                {
                    b.HasOne("PerfectSound.Database.Person", "Person")
                        .WithMany("SongAndPodcastPeople")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("SongAndPodcastPerson_Person")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PerfectSound.Database.Role", "Role")
                        .WithMany("SongAndPodcastPeople")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("SongAndPodcastPerson_Role")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PerfectSound.Database.SongAndPodcast", "SongAndPodcast")
                        .WithMany("SongAndPodcastPeople")
                        .HasForeignKey("SongAndPodcastId")
                        .HasConstraintName("SongAndPodcastPerson_SongAndPodcast")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Person");

                    b.Navigation("Role");

                    b.Navigation("SongAndPodcast");
                });

            modelBuilder.Entity("PerfectSound.Database.User", b =>
                {
                    b.HasOne("PerfectSound.Database.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .HasConstraintName("User_UserType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("PerfectSound.Database.Gender", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("PerfectSound.Database.Genre", b =>
                {
                    b.Navigation("SongAndPodcastGenres");
                });

            modelBuilder.Entity("PerfectSound.Database.Person", b =>
                {
                    b.Navigation("SongAndPodcastPeople");
                });

            modelBuilder.Entity("PerfectSound.Database.PodcastSeason", b =>
                {
                    b.Navigation("PodcastSeasonEpisodes");
                });

            modelBuilder.Entity("PerfectSound.Database.ProductionCompany", b =>
                {
                    b.Navigation("SongAndPodcasts");
                });

            modelBuilder.Entity("PerfectSound.Database.Role", b =>
                {
                    b.Navigation("SongAndPodcastPeople");
                });

            modelBuilder.Entity("PerfectSound.Database.SongAndPodcast", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PodcastSeasons");

                    b.Navigation("Quotes");

                    b.Navigation("Ratings");

                    b.Navigation("SongAndPodcastGenres");

                    b.Navigation("SongAndPodcastPeople");
                });

            modelBuilder.Entity("PerfectSound.Database.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("News");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("PerfectSound.Database.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
