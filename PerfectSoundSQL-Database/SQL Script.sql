USE [master]
GO
/****** Object:  Database [PerfectSound]    Script Date: 7/31/2021 4:54:29 PM ******/
CREATE DATABASE [PerfectSound]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PerfectSound', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PerfectSound.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PerfectSound_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PerfectSound_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PerfectSound] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PerfectSound].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PerfectSound] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PerfectSound] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PerfectSound] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PerfectSound] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PerfectSound] SET ARITHABORT OFF 
GO
ALTER DATABASE [PerfectSound] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PerfectSound] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PerfectSound] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PerfectSound] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PerfectSound] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PerfectSound] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PerfectSound] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PerfectSound] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PerfectSound] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PerfectSound] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PerfectSound] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PerfectSound] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PerfectSound] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PerfectSound] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PerfectSound] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PerfectSound] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PerfectSound] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PerfectSound] SET RECOVERY FULL 
GO
ALTER DATABASE [PerfectSound] SET  MULTI_USER 
GO
ALTER DATABASE [PerfectSound] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PerfectSound] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PerfectSound] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PerfectSound] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PerfectSound] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PerfectSound] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PerfectSound', N'ON'
GO
ALTER DATABASE [PerfectSound] SET QUERY_STORE = OFF
GO
USE [PerfectSound]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 7/31/2021 4:54:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[SongAndPodcastID] [int] NULL,
	[UserID] [int] NULL,
	[DateTimeOfComment] [datetime2](7) NULL,
	[Content] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderID] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsID] [int] IDENTITY(1,1) NOT NULL,
	[CoverPhoto] [varbinary](max) NULL,
	[Title] [nvarchar](max) NULL,
	[SubTitle] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[PublicationDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[NewsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Photo] [varbinary](max) NULL,
	[Biography] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[PlaceOfBirth] [nvarchar](max) NULL,
	[DateOfDeath] [datetime2](7) NULL,
	[GenderID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PodcastSeason]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PodcastSeason](
	[PodcastSeasonID] [int] IDENTITY(1,1) NOT NULL,
	[SongAndPodcastID] [int] NULL,
	[SeasonName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PodcastSeasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PodcastSeasonEpisode]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PodcastSeasonEpisode](
	[PodcastSeasonEpisodeID] [int] IDENTITY(1,1) NOT NULL,
	[PodcastSeasonID] [int] NULL,
	[EpisodeName] [nvarchar](max) NULL,
	[EpisodeNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PodcastSeasonEpisodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionCompany]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionCompany](
	[ProductionCompanyID] [int] IDENTITY(1,1) NOT NULL,
	[ProductionCompanyName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductionCompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quote]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quote](
	[QuoteID] [int] IDENTITY(1,1) NOT NULL,
	[SongAndPodcastID] [int] NULL,
	[QuoteText] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[QuoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[RatingID] [int] IDENTITY(1,1) NOT NULL,
	[SongAndPodcastID] [int] NULL,
	[UserID] [int] NULL,
	[RatingValue] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongAndPodcast]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongAndPodcast](
	[SongAndPodcastID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[RunningTime] [nvarchar](max) NULL,
	[ReleaseDate] [datetime2](7) NULL,
	[Budget] [money] NULL,
	[Poster] [varbinary](1) NULL,
	[NumberOfRatings] [int] NULL,
	[ProductionCompanyID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SongAndPodcastID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongAndPodcastGenre]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongAndPodcastGenre](
	[SongAndPodcastGenreID] [int] IDENTITY(1,1) NOT NULL,
	[SongAndPodcastID] [int] NULL,
	[GenreID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SongAndPodcastGenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongAndPodcastPerson]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongAndPodcastPerson](
	[SongAndPodcastPersonID] [int] IDENTITY(1,1) NOT NULL,
	[SongAndPodcastID] [int] NULL,
	[PersonID] [int] NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SongAndPodcastPersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PasswordSalt] [nvarchar](max) NULL,
	[UserTypeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/31/2021 4:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [Comment_SongAndPodcast] FOREIGN KEY([SongAndPodcastID])
REFERENCES [dbo].[SongAndPodcast] ([SongAndPodcastID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [Comment_SongAndPodcast]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [Comment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [Comment_User]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [User_News] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [User_News]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [Person_Gender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Gender] ([GenderID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [Person_Gender]
GO
ALTER TABLE [dbo].[PodcastSeason]  WITH CHECK ADD  CONSTRAINT [SongAndPodcastSeason_SongAndPodcast] FOREIGN KEY([SongAndPodcastID])
REFERENCES [dbo].[SongAndPodcast] ([SongAndPodcastID])
GO
ALTER TABLE [dbo].[PodcastSeason] CHECK CONSTRAINT [SongAndPodcastSeason_SongAndPodcast]
GO
ALTER TABLE [dbo].[PodcastSeasonEpisode]  WITH CHECK ADD  CONSTRAINT [PodcastSeason_SongAndPodcast] FOREIGN KEY([PodcastSeasonID])
REFERENCES [dbo].[PodcastSeason] ([PodcastSeasonID])
GO
ALTER TABLE [dbo].[PodcastSeasonEpisode] CHECK CONSTRAINT [PodcastSeason_SongAndPodcast]
GO
ALTER TABLE [dbo].[Quote]  WITH CHECK ADD  CONSTRAINT [Quote_SongAndPodcast] FOREIGN KEY([SongAndPodcastID])
REFERENCES [dbo].[SongAndPodcast] ([SongAndPodcastID])
GO
ALTER TABLE [dbo].[Quote] CHECK CONSTRAINT [Quote_SongAndPodcast]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [Rating_SongAndPodcast] FOREIGN KEY([SongAndPodcastID])
REFERENCES [dbo].[SongAndPodcast] ([SongAndPodcastID])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [Rating_SongAndPodcast]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [Rating_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [Rating_User]
GO
ALTER TABLE [dbo].[SongAndPodcast]  WITH CHECK ADD  CONSTRAINT [SongAndPodcast_ProductionCompany] FOREIGN KEY([ProductionCompanyID])
REFERENCES [dbo].[ProductionCompany] ([ProductionCompanyID])
GO
ALTER TABLE [dbo].[SongAndPodcast] CHECK CONSTRAINT [SongAndPodcast_ProductionCompany]
GO
ALTER TABLE [dbo].[SongAndPodcastGenre]  WITH CHECK ADD  CONSTRAINT [SongAndPodcastGenre_Genre] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[SongAndPodcastGenre] CHECK CONSTRAINT [SongAndPodcastGenre_Genre]
GO
ALTER TABLE [dbo].[SongAndPodcastGenre]  WITH CHECK ADD  CONSTRAINT [SongAndPodcastGenre_SongAndPodcast] FOREIGN KEY([SongAndPodcastID])
REFERENCES [dbo].[SongAndPodcast] ([SongAndPodcastID])
GO
ALTER TABLE [dbo].[SongAndPodcastGenre] CHECK CONSTRAINT [SongAndPodcastGenre_SongAndPodcast]
GO
ALTER TABLE [dbo].[SongAndPodcastPerson]  WITH CHECK ADD  CONSTRAINT [SongAndPodcastPerson_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[SongAndPodcastPerson] CHECK CONSTRAINT [SongAndPodcastPerson_Person]
GO
ALTER TABLE [dbo].[SongAndPodcastPerson]  WITH CHECK ADD  CONSTRAINT [SongAndPodcastPerson_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[SongAndPodcastPerson] CHECK CONSTRAINT [SongAndPodcastPerson_Role]
GO
ALTER TABLE [dbo].[SongAndPodcastPerson]  WITH CHECK ADD  CONSTRAINT [SongAndPodcastPerson_SongAndPodcast] FOREIGN KEY([SongAndPodcastID])
REFERENCES [dbo].[SongAndPodcast] ([SongAndPodcastID])
GO
ALTER TABLE [dbo].[SongAndPodcastPerson] CHECK CONSTRAINT [SongAndPodcastPerson_SongAndPodcast]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [User_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [User_UserType]
GO
USE [master]
GO
ALTER DATABASE [PerfectSound] SET  READ_WRITE 
GO
