using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PerfectSound.Database
{
    public partial class PerfectSoundContext : DbContext
    {
        public PerfectSoundContext()
        {
        }

        public PerfectSoundContext(DbContextOptions<PerfectSoundContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PodcastSeason> PodcastSeasons { get; set; }
        public virtual DbSet<PodcastSeasonEpisode> PodcastSeasonEpisodes { get; set; }
        public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SongAndPodcast> SongAndPodcasts { get; set; }
        public virtual DbSet<SongAndPodcastGenre> SongAndPodcastGenres { get; set; }
        public virtual DbSet<SongAndPodcastPerson> SongAndPodcastPerson { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PerfectSound;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Bosnian_Latin_100_BIN");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.SongAndPodcastId).HasColumnName("SongAndPodcastID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.SongAndPodcast)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SongAndPodcastId)
                    .HasConstraintName("Comment_SongAndPodcast");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Comment_User");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("User_News");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("Person_Gender");
            });

            modelBuilder.Entity<PodcastSeason>(entity =>
            {
                entity.ToTable("PodcastSeason");

                entity.Property(e => e.PodcastSeasonId).HasColumnName("PodcastSeasonID");

                entity.Property(e => e.SongAndPodcastId).HasColumnName("SongAndPodcastID");

                entity.HasOne(d => d.SongAndPodcast)
                    .WithMany(p => p.PodcastSeasons)
                    .HasForeignKey(d => d.SongAndPodcastId)
                    .HasConstraintName("SongAndPodcastSeason_SongAndPodcast");
            });

            modelBuilder.Entity<PodcastSeasonEpisode>(entity =>
            {
                entity.ToTable("PodcastSeasonEpisode");

                entity.Property(e => e.PodcastSeasonEpisodeId).HasColumnName("PodcastSeasonEpisodeID");

                entity.Property(e => e.PodcastSeasonId).HasColumnName("PodcastSeasonID");

                entity.HasOne(d => d.PodcastSeason)
                    .WithMany(p => p.PodcastSeasonEpisodes)
                    .HasForeignKey(d => d.PodcastSeasonId)
                    .HasConstraintName("PodcastSeason_SongAndPodcast");
            });

            modelBuilder.Entity<ProductionCompany>(entity =>
            {
                entity.ToTable("ProductionCompany");

                entity.Property(e => e.ProductionCompanyId).HasColumnName("ProductionCompanyID");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("Quote");

                entity.Property(e => e.QuoteId).HasColumnName("QuoteID");

                entity.Property(e => e.SongAndPodcastId).HasColumnName("SongAndPodcastID");

                entity.HasOne(d => d.SongAndPodcast)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SongAndPodcastId)
                    .HasConstraintName("Quote_SongAndPodcast");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.SongAndPodcastId).HasColumnName("SongAndPodcastID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.SongAndPodcast)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.SongAndPodcastId)
                    .HasConstraintName("Rating_SongAndPodcast");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Rating_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<SongAndPodcast>(entity =>
            {
                entity.ToTable("SongAndPodcast");

                entity.Property(e => e.SongAndPodcastId).HasColumnName("SongAndPodcastID");

                entity.Property(e => e.Budget).HasColumnType("money");

                entity.Property(e => e.Poster).HasMaxLength(1);

                entity.Property(e => e.ProductionCompanyId).HasColumnName("ProductionCompanyID");

                entity.HasOne(d => d.ProductionCompany)
                    .WithMany(p => p.SongAndPodcasts)
                    .HasForeignKey(d => d.ProductionCompanyId)
                    .HasConstraintName("SongAndPodcast_ProductionCompany");
            });

            modelBuilder.Entity<SongAndPodcastGenre>(entity =>
            {
                entity.ToTable("SongAndPodcastGenre");

                entity.Property(e => e.SongAndPodcastGenreId).HasColumnName("SongAndPodcastGenreID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.SongAndPodcastId).HasColumnName("SongAndPodcastID");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SongAndPodcastGenres)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("SongAndPodcastGenre_Genre");

                entity.HasOne(d => d.SongAndPodcast)
                    .WithMany(p => p.SongAndPodcastGenres)
                    .HasForeignKey(d => d.SongAndPodcastId)
                    .HasConstraintName("SongAndPodcastGenre_SongAndPodcast");
            });

            modelBuilder.Entity<SongAndPodcastPerson>(entity =>
            {
                entity.ToTable("SongAndPodcastPerson");

                entity.Property(e => e.SongAndPodcastPersonId).HasColumnName("SongAndPodcastPersonID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SongAndPodcastId).HasColumnName("SongAndPodcastID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.SongAndPodcastPerson)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("SongAndPodcastPerson_Person");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SongAndPodcastPerson)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("SongAndPodcastPerson_Role");

                entity.HasOne(d => d.SongAndPodcast)
                    .WithMany(p => p.SongAndPodcastPerson)
                    .HasForeignKey(d => d.SongAndPodcastId)
                    .HasConstraintName("SongAndPodcastPerson_SongAndPodcast");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("User_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
