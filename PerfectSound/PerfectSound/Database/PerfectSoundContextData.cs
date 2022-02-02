using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Database
{
    public partial class PerfectSoundContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //user type
            modelBuilder.Entity<UserType>().HasData(
                new UserType()
                {
                    UserTypeId = 1,
                    Type = "Admin"
                },
                new UserType()
                {
                    UserTypeId = 2,
                    Type = "Guest"
                }
            );

            //genders
            modelBuilder.Entity<Gender>().HasData(
                new Gender()
                {
                    GenderId = 1,
                    GenderName = "Male"
                },
                new Gender()
                {
                    GenderId = 2,
                    GenderName = "Female"
                },
                new Gender()
                {
                    GenderId = 3,
                    GenderName = "Other"
                }
            );

            //users
            User u1 = new User()
            {
                UserId = 1,
                UserName = "desktop",
                FirstName = "Anisa",
                LastName = "Suljic",
                Email = "anisa@gmail.com",
                Phone = "032165498",
                UserTypeId = 1
            };
            u1.PasswordSalt = Helper.PasswordHash.GenerateSalt();
            u1.PasswordHash = Helper.PasswordHash.GenerateHash(u1.PasswordSalt, "test");
            
            User u2 = new User()
            {
                UserId = 2,
                UserName = "mobile",
                FirstName = "AnisaMob",
                LastName = "SuljicMob",
                Email = "anisaMob@gmail.com",
                Phone = "032165498",
                UserTypeId = 2
            };
            u2.PasswordSalt = Helper.PasswordHash.GenerateSalt();
            u2.PasswordHash = Helper.PasswordHash.GenerateHash(u2.PasswordSalt, "test");

            modelBuilder.Entity<User>().HasData(
                u1,u2
            );

            //news

            modelBuilder.Entity<News>().HasData(
                new News()
                {
                    NewsId = 1,
                    Title = "Selena Gomez: 'I won't ever quit making music'",
                    SubTitle = "Selena Gomez is putting to rest rumours that she's quitting the music industry.",
                    PublicationDate = DateTime.Today,
                    CoverPhoto = File.ReadAllBytes("img/selena.jpg"),
                    Content = "'I don't think I'll ever quit making music,' the Love You Like a Love Song singer reassured fans. " +
                "'I'm not saying I want a Grammy. I just feel like I'm doing the best I can, and it's all about me. Sometimes, that can really get to me.'The Only Murders in the Building star put out her first - ever Spanish - language EP," +
                "Revelación, earlier this year.When talking about the experience of making the album,she opened up about using a Spanish coach after struggling to sing in the language."
                },
                new News()
                {
                    NewsId = 2,
                    Title = "Ed Sheeran’s Bad Habits claims eighth week on top with Drill remix",
                    SubTitle = "Ed Sheeran’s Bad Habits claims an eighth week at Number 1 on the Official Singles Chart, enjoying a boost this week thanks to the release of a drill remix of the track featuring rappers Tion Wayne and Central Cee, remixed by London-based producer Fumez The Engineer.",
                    PublicationDate = DateTime.Today,
                    CoverPhoto = File.ReadAllBytes("img/edsheeran.jpg"),
                    Content = "Meanwhile, Becky Hill & David Guetta’s Remember climbs two to Number 3, becoming Becky’s second-highest charting single to date, and David Guetta’s third Top 3 hit of 2021." +
                    "Digga D scores the week’s highest new entry at Number 6 with Wasted ft.ArrDee,both rappers’ second UK Top 10.Elsewhere in the Top 10," +
                    "Industry Baby by Lil Nas X & Jack Harlow climbs four to Number 7 – Lil Nas X’s third Top 10 single and Jack Harlow’s first – while Talk About by Rain Radio &DJ Craig Gorman jumps five" +
                    "to Number 9.KSI’s Holiday rebounds two to Number 10.Lots of singles reach brand new peaks this week: Tones & I’s Fly Away(11) which climbs eight, Doja Cat’s Need To Know(12) up nine," +
                    "Anne-Marie & Little Mix’s Kiss My(Uh Oh)(14), Wizkid’s Essence ft.Tems(17) – which zooms 18 places following a new remix with Justin Bieber – and Mabel’s Let Them Know(19)."
                }
            );

            //production company

            modelBuilder.Entity<ProductionCompany>().HasData(
                new ProductionCompany()
                {
                    ProductionCompanyId = 1,
                    ProductionCompanyName = "Abbey Road Studios"
                },
                new ProductionCompany()
                {
                    ProductionCompanyId = 2,
                    ProductionCompanyName = "Capitol Studios"
                },
                new ProductionCompany()
                {
                    ProductionCompanyId = 3,
                    ProductionCompanyName = "Air Studios"
                },
                new ProductionCompany()
                {
                    ProductionCompanyId = 4,
                    ProductionCompanyName = "Metropolis Studios"
                },
                new ProductionCompany()
                {
                    ProductionCompanyId = 5,
                    ProductionCompanyName = "Platinum Studios"
                }
            );

            //roles
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    RoleId = 1,
                    RoleName = "Singer"
                },
                new Role()
                {
                    RoleId = 2,
                    RoleName = "Back vocal"
                },
                new Role()
                {
                    RoleId = 3,
                    RoleName = "Guitarist"
                },
                new Role()
                {
                    RoleId = 4,
                    RoleName = "Producer"
                },
                new Role()
                {
                    RoleId = 5,
                    RoleName = "Program leader"
                }
            );

            //persons/artists
            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    PersonId = 1,
                    FirstName = "Selena",
                    LastName = "Gomez",
                    Photo = File.ReadAllBytes("img/selena.jpg"),
                    Biography = "Actress and singer Selena Gomez was born on July 22, 1992 in Grand Prairie, Texas. She is the daughter of Mandy Teefey and Ricardo Gomez. Her mother is of part Italian ancestry, and her father is of Mexican descent. She was named after Tejano singer Selena, who died in 1995.",
                    DateOfBirth = new DateTime(1992, 07, 22),
                    PlaceOfBirth = "Grand Prairie, Texas, SAD",
                    DateOfDeath = null,
                    GenderId = 2
                },
                new Person()
                {
                    PersonId = 2,
                    FirstName = "Ed (Edward)",
                    LastName = "Christopher Sheeran",
                    Photo = File.ReadAllBytes("img/edsheeran.jpg"),
                    Biography = "Edward Christopher - Ed Sheeran is a famous English singer and songwriter, who has won the hearts of people all over the world with his melodic voice. He is an occasional rapper and actor as well. His popularity increased especially after the release of his first album ‘+’ and after a guest appearance was made by him on Taylor Swift's fourth studio album 'Red.’ He began recording music in 2004. His first work 'Spinning Man' was released independently. After moving to London from Suffolk in 2008, he used to play in small venues and also released the EP ‘You Need me’ in 2009. While in London, he also auditioned for a British musical drama television series ‘Britannia High.’ His debut album '+' was released in September 2011.",
                    DateOfBirth = new DateTime(1991, 02, 17),
                    PlaceOfBirth = "Halifax, Great Britain",
                    DateOfDeath = null,
                    GenderId = 1
                }
            );

            //genre
            modelBuilder.Entity<Genre>().HasData(

                new Genre()
                {
                    GenreId=1,
                    GenreName = "Pop"
                },
                new Genre()
                {
                    GenreId = 2,
                    GenreName = "Rock"
                },
                new Genre()
                {
                    GenreId = 3,
                    GenreName = "Country"
                },
                new Genre()
                {
                    GenreId = 4,
                    GenreName = "Jazz"
                },
                new Genre()
                {
                    GenreId = 5,
                    GenreName = "Hip Hop"
                }
            );

            //songAndPodcasts
            modelBuilder.Entity<SongAndPodcast>().HasData(
                new SongAndPodcast()
                {
                    SongAndPodcastId = 1,
                    Title = "Perfect",
                    Text = "I found a love for me" +
                            "Oh darling," +
                            "just dive right in and follow my lead" +
                            "Well," +
                            "I found a girl," +
                            "beautiful and sweet" +
                            "Oh," +
                            "I never knew you were the someone waiting for me" +
                            "'Cause we were just kids when we fell in love" +
                            "Not knowing what it was...",
                    RunningTime = "00:04:22",
                    ReleaseDate = new DateTime(2017, 09, 26),
                    Budget = 3500,
                    Poster = File.ReadAllBytes("img/edsheeran.jpg"),
                    ProductionCompanyId = 1,
                    IsPodcast = false
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 2,
                    Title = "Song Exploder",
                    Text = "",
                    RunningTime = null,
                    ReleaseDate = new DateTime(2014, 01, 14),
                    Budget = 11500,
                    Poster = File.ReadAllBytes("img/Song_Exploder.png"),
                    ProductionCompanyId = 3,
                    IsPodcast = true
                }
            );

            //seasons
            modelBuilder.Entity<PodcastSeason>().HasData(
                new PodcastSeason()
                {
                    PodcastSeasonId = 1,
                    SeasonName = "Exploder S1",
                    SongAndPodcastId = 2
                },
                new PodcastSeason()
                {
                    PodcastSeasonId = 2,
                    SeasonName = "Exploder S2",
                    SongAndPodcastId = 2
                },
                new PodcastSeason()
                {
                    PodcastSeasonId = 3,
                    SeasonName = "Exploder S3",
                    SongAndPodcastId = 2
                }
             );

            //episodes
            modelBuilder.Entity<PodcastSeasonEpisode>().HasData(
                new PodcastSeasonEpisode()
                {
                    PodcastSeasonEpisodeId = 1,
                    EpisodeName = "Pilot episode",
                    EpisodeNumber = 0,
                    PodcastSeasonId = 1
                },
                new PodcastSeasonEpisode()
                {
                    PodcastSeasonEpisodeId = 2,
                    EpisodeName = "Episode 1",
                    EpisodeNumber = 1,
                    PodcastSeasonId = 1
                },
                new PodcastSeasonEpisode()
                {
                    PodcastSeasonEpisodeId = 3,
                    EpisodeName = "Episode 3",
                    EpisodeNumber = 3,
                    PodcastSeasonId = 1
                },
                new PodcastSeasonEpisode()
                {
                    PodcastSeasonEpisodeId = 4,
                    EpisodeName = "Episode 1",
                    EpisodeNumber = 1,
                    PodcastSeasonId = 2
                }
            );

            //songandpodcast genre
            modelBuilder.Entity<SongAndPodcastGenre>().HasData(
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId=1,
                    SongAndPodcastId = 1,
                    GenreId = 1
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 2,
                    SongAndPodcastId = 2,
                    GenreId = 3
                }
            );

            //songandpodcast person
            modelBuilder.Entity<SongAndPodcastPerson>().HasData(
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId=1,
                    SongAndPodcastId = 1,
                    PersonId = 2,
                    RoleId = 4
                }
            );

            //rating

            modelBuilder.Entity<Rating>().HasData(
                new Rating()
                {
                    RatingId=1,
                    SongAndPodcastId=1,
                    UserId=2,
                    RatingValue=3
                },
                new Rating()
                {
                    RatingId = 2,
                    SongAndPodcastId = 2,
                    UserId = 2,
                    RatingValue = 4
                }
            );
            //comments

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    CommentId=1,
                    SongAndPodcastId=1,
                    UserId=2,
                    DateTimeOfComment=new DateTime(2021,07,26),
                    Content="Komentar 1"
                },
                new Comment()
                {
                    CommentId = 2,
                    SongAndPodcastId = 2,
                    UserId = 2,
                    DateTimeOfComment = new DateTime(2021, 07, 12),
                    Content = "Komentar 2"
                }
            );
            //quotes

            modelBuilder.Entity<Quote>().HasData(
                new Quote()
                {
                    QuoteId=1,
                    SongAndPodcastId=1,
                    QuoteText= "Just dive right in and follow my lead..."
                },
                new Quote()
                {
                    QuoteId = 2,
                    SongAndPodcastId = 1,
                    QuoteText = "I never knew you were the someone waiting for me..."
                }
            );
        }
    }
}
