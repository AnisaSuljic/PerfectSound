using Microsoft.EntityFrameworkCore;
using PerfectSound.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound
{
    public class SetupService
    {
        public static void Init(PerfectSoundContext context)
        {
            context.Database.EnsureCreated();
            /*
            //DATA

            //user types
            if (!context.UserTypes.Any(x => x.Type == "Admin" || x.Type == "Guest"))
            {
                context.UserTypes.Add(new UserType()
                {
                    //UserTypeId=1,
                    Type="Admin"
                });
                context.SaveChanges();

                context.UserTypes.Add(new UserType()
                {
                    //UserTypeId = 2,
                    Type = "Guest"
                });
            context.SaveChanges();
            }

            //genders
            if (!context.Genders.Any(x => x.GenderName == "Male" || x.GenderName == "Female" || x.GenderName == "Other"))
            {

                context.Genders.Add(new Gender()
                {
                    //GenderId = 1,
                    GenderName = "Male"
                });
                context.SaveChanges();

                context.Genders.Add(new Gender()
                {
                    //GenderId = 2,
                    GenderName = "Female"
                });
                context.SaveChanges();

                context.Genders.Add(new Gender()
                {
                    //GenderId = 3,
                    GenderName = "Other"
                });
            context.SaveChanges();
            }

            //users
            if (!context.Users.Any(x => x.UserName == "desktop" || x.UserName == "mobile"))
            {
                //1.user

                User u1 = new User()
                {
                    //UserId = 1,
                    UserName="desktop",
                    FirstName = "Anisa",
                    LastName = "Suljic",
                    Email = "anisa@gmail.com",
                    Phone = "032165498",
                    UserTypeId = 1
                };
                u1.PasswordSalt = Helper.PasswordHash.GenerateSalt();
                u1.PasswordHash = Helper.PasswordHash.GenerateHash(u1.PasswordSalt, "test");

                //2.user
                User u2 = new User()
                {
                    //UserId = 2,
                    UserName = "mobile",
                    FirstName = "AnisaMob",
                    LastName = "SuljicMob",
                    Email = "anisaMob@gmail.com",
                    Phone = "032165498",
                    UserTypeId = 2
                };
                u2.PasswordSalt = Helper.PasswordHash.GenerateSalt();
                u2.PasswordHash = Helper.PasswordHash.GenerateHash(u1.PasswordSalt, "test");


                context.Users.Add(u1);
                context.SaveChanges();

                context.Users.Add(u2);
        context.SaveChanges();
            }

            //news
            if (!context.News.Any(x => x.Title == "Selena Gomez: 'I won't ever quit making music'" || x.Title == "Ed Sheeran’s Bad Habits claims eighth week on top with Drill remix"))
            {

                context.News.Add(new News()
                {
                    //NewsId = 1,
                    Title = "Selena Gomez: 'I won't ever quit making music'",
                    SubTitle = "Selena Gomez is putting to rest rumours that she's quitting the music industry.",
                    PublicationDate = DateTime.Today,
                    CoverPhoto = File.ReadAllBytes("img/selena.jpg"),
                    Content = "'I don't think I'll ever quit making music,' the Love You Like a Love Song singer reassured fans. " +
                "'I'm not saying I want a Grammy. I just feel like I'm doing the best I can, and it's all about me. Sometimes, that can really get to me.'The Only Murders in the Building star put out her first - ever Spanish - language EP," +
                "Revelación, earlier this year.When talking about the experience of making the album,she opened up about using a Spanish coach after struggling to sing in the language."
                });
                context.SaveChanges();

                context.News.Add(new News()
                {
                    //NewsId = 2,
                    Title = "Ed Sheeran’s Bad Habits claims eighth week on top with Drill remix",
                    SubTitle = "Ed Sheeran’s Bad Habits claims an eighth week at Number 1 on the Official Singles Chart, enjoying a boost this week thanks to the release of a drill remix of the track featuring rappers Tion Wayne and Central Cee, remixed by London-based producer Fumez The Engineer.",
                    PublicationDate = DateTime.Today,
                    CoverPhoto = File.ReadAllBytes("img/edsheeran.jpg"),
                    Content = "Meanwhile, Becky Hill & David Guetta’s Remember climbs two to Number 3, becoming Becky’s second-highest charting single to date, and David Guetta’s third Top 3 hit of 2021." +
                    "Digga D scores the week’s highest new entry at Number 6 with Wasted ft.ArrDee,both rappers’ second UK Top 10.Elsewhere in the Top 10," +
                    "Industry Baby by Lil Nas X & Jack Harlow climbs four to Number 7 – Lil Nas X’s third Top 10 single and Jack Harlow’s first – while Talk About by Rain Radio &DJ Craig Gorman jumps five" +
                    "to Number 9.KSI’s Holiday rebounds two to Number 10.Lots of singles reach brand new peaks this week: Tones & I’s Fly Away(11) which climbs eight, Doja Cat’s Need To Know(12) up nine," +
                    "Anne-Marie & Little Mix’s Kiss My(Uh Oh)(14), Wizkid’s Essence ft.Tems(17) – which zooms 18 places following a new remix with Justin Bieber – and Mabel’s Let Them Know(19)."
                });
            context.SaveChanges();
            }

            //production company
            if (!context.ProductionCompanies.Any(x => x.ProductionCompanyName == "Abbey Road Studios" || x.ProductionCompanyName == "Capitol Studios"
                || x.ProductionCompanyName== "Air Studios" || x.ProductionCompanyName == "Metropolis Studios" || x.ProductionCompanyName == "Platinum Studios"))
            {

                context.ProductionCompanies.Add(new ProductionCompany()
                {
                    //ProductionCompanyId = 1,
                    ProductionCompanyName = "Abbey Road Studios"
                });
                context.SaveChanges();

                context.ProductionCompanies.Add(new ProductionCompany()
                {
                    //ProductionCompanyId = 2,
                    ProductionCompanyName = "Capitol Studios"
                });
                context.SaveChanges();

                context.ProductionCompanies.Add(new ProductionCompany()
                {
                    //ProductionCompanyId = 3,
                    ProductionCompanyName = "Air Studios"
                });
                context.SaveChanges();

                context.ProductionCompanies.Add(new ProductionCompany()
                {
                    //ProductionCompanyId = 4,
                    ProductionCompanyName = "Metropolis Studios"
                });
                context.SaveChanges();

                context.ProductionCompanies.Add(new ProductionCompany()
                {
                    //ProductionCompanyId = 5,
                    ProductionCompanyName = "Platinum Studios"
                });
            context.SaveChanges();
            }

            //roles
            if (!context.Roles.Any(x => x.RoleName == "Singer" || x.RoleName == "Back vocal"
               || x.RoleName == "Guitarist" || x.RoleName == "Producer" || x.RoleName == "Program leader"))
            {
                context.Roles.Add(new Role()
                {
                    //RoleId = 1,
                    RoleName = "Singer"
                });
                context.SaveChanges();

                context.Roles.Add(new Role()
                {
                    //RoleId = 2,
                    RoleName = "Back vocal"
                });
                context.SaveChanges();

                context.Roles.Add(new Role()
                {
                    //RoleId = 3,
                    RoleName = "Guitarist"
                });
                context.SaveChanges();

                context.Roles.Add(new Role()
                {
                    //RoleId = 4,
                    RoleName = "Producer"
                });
                context.SaveChanges();

                context.Roles.Add(new Role()
                {
                    //RoleId = 5,
                    RoleName = "Program leader"
                });
            context.SaveChanges();
            }

            //persons/artists
            if (!context.People.Any(x => x.FirstName == "Selena" && x.LastName=="Gomez" ||
            x.FirstName == "Ed (Edward)" && x.LastName == "Christopher Sheeran" ))
            {
                context.People.Add(new Person()
                {
                    //PersonId = 1,
                    FirstName = "Selena",
                    LastName = "Gomez",
                    Photo = File.ReadAllBytes("img/selena.jpg"),
                    Biography = "Actress and singer Selena Gomez was born on July 22, 1992 in Grand Prairie, Texas. She is the daughter of Mandy Teefey and Ricardo Gomez. Her mother is of part Italian ancestry, and her father is of Mexican descent. She was named after Tejano singer Selena, who died in 1995.",
                    DateOfBirth = new DateTime(1992, 07, 22),
                    PlaceOfBirth = "Grand Prairie, Texas, SAD",
                    DateOfDeath = null,
                    GenderId = 2
                });
                context.SaveChanges();

                context.People.Add(new Person()
                {
                    //PersonId = 2,
                    FirstName = "Ed (Edward)",
                    LastName = "Christopher Sheeran",
                    Photo = File.ReadAllBytes("img/edsheeran.jpg"),
                    Biography = "Edward Christopher - Ed Sheeran is a famous English singer and songwriter, who has won the hearts of people all over the world with his melodic voice. He is an occasional rapper and actor as well. His popularity increased especially after the release of his first album ‘+’ and after a guest appearance was made by him on Taylor Swift's fourth studio album 'Red.’ He began recording music in 2004. His first work 'Spinning Man' was released independently. After moving to London from Suffolk in 2008, he used to play in small venues and also released the EP ‘You Need me’ in 2009. While in London, he also auditioned for a British musical drama television series ‘Britannia High.’ His debut album '+' was released in September 2011.",
                    DateOfBirth = new DateTime(1991, 02, 17),
                    PlaceOfBirth = "Halifax, Great Britain",
                    DateOfDeath = null,
                    GenderId = 1
                });
            context.SaveChanges();
            }

            //genre
            if (!context.Genres.Any(x => x.GenreName == "Pop" || x.GenreName == "Rock" ||
            x.GenreName == "Country" || x.GenreName == "Jazz" || x.GenreName == "Hip Hop"))
            {
                context.Genres.Add(new Genre()
                {
                    //GenreId=1,
                    GenreName = "Pop"
                });
                context.SaveChanges();

                context.Genres.Add(new Genre()
                {
                    //GenreId = 2,
                    GenreName = "Rock"
                });
                context.SaveChanges();

                context.Genres.Add(new Genre()
                {
                    //GenreId = 3,
                    GenreName = "Country"
                });
                context.SaveChanges();

                context.Genres.Add(new Genre()
                {
                    //GenreId = 4,
                    GenreName = "Jazz"
                });
                context.SaveChanges();

                context.Genres.Add(new Genre()
                {
                    //GenreId = 5,
                    GenreName = "Hip Hop"
                });
            context.SaveChanges();
            }

            //songAndPodcasts
            if (!context.SongAndPodcasts.Any(x => x.Title == "Perfect" || x.Title == "Song Exploder"))
            {
                context.SongAndPodcasts.Add(new SongAndPodcast()
                {
                    //SongAndPodcastId = 1,
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
                });
                context.SaveChanges();

                context.SongAndPodcasts.Add(new SongAndPodcast()
                {
                    //SongAndPodcastId = 2,
                    Title = "Song Exploder",
                    Text = "",
                    RunningTime = null,
                    ReleaseDate = new DateTime(2014, 01, 14),
                    Budget = 11500,
                    Poster = File.ReadAllBytes("img/Song_Exploder.png"),
                    ProductionCompanyId = 3,
                    IsPodcast = true
                });
                context.SaveChanges();
            }

            //seasons
            if (!context.PodcastSeasons.Any(x => (x.SeasonName == "Exploder S1"&& x.SongAndPodcastId==2) || 
            (x.SeasonName == "Exploder S2"&& x.SongAndPodcastId==2) || (x.SeasonName == "Exploder S3"&& x.SongAndPodcastId==2)))
            {
                context.PodcastSeasons.Add(new PodcastSeason()
                {
                    //PodcastSeasonId = 1,
                    SeasonName = "Exploder S1",
                    SongAndPodcastId = 2
                });
                context.SaveChanges();

                context.PodcastSeasons.Add(new PodcastSeason()
                {
                    //PodcastSeasonId = 2,
                    SeasonName = "Exploder S2",
                    SongAndPodcastId = 2
                });
                context.SaveChanges();

                context.PodcastSeasons.Add(new PodcastSeason()
                {
                    //PodcastSeasonId = 3,
                    SeasonName = "Exploder S3",
                    SongAndPodcastId = 2
                });
            context.SaveChanges();
            }

            //episodes
            if (!context.PodcastSeasonEpisodes.Any(x => (x.EpisodeName == "Pilot episode" && x.PodcastSeasonId==1) || 
            (x.EpisodeName == "Episode 1" && x.PodcastSeasonId==1 )||( x.EpisodeName == "Episode 3"&& x.PodcastSeasonId==1)
            ||( x.EpisodeName == "Episode 2" && x.PodcastSeasonId==2)))
            {
                context.PodcastSeasonEpisodes.Add(new PodcastSeasonEpisode()
                {
                    //PodcastSeasonEpisodeId = 1,
                    EpisodeName = "Pilot episode",
                    EpisodeNumber = 0,
                    PodcastSeasonId = 1
                });
                context.SaveChanges();

                context.PodcastSeasonEpisodes.Add(new PodcastSeasonEpisode()
                {
                    //PodcastSeasonEpisodeId = 2,
                    EpisodeName = "Episode 1",
                    EpisodeNumber = 1,
                    PodcastSeasonId = 1
                });
                context.SaveChanges();

                context.PodcastSeasonEpisodes.Add(new PodcastSeasonEpisode()
                {
                    //PodcastSeasonEpisodeId = 3,
                    EpisodeName = "Episode 3",
                    EpisodeNumber = 3,
                    PodcastSeasonId = 1
                });
                context.SaveChanges();

                context.PodcastSeasonEpisodes.Add(new PodcastSeasonEpisode()
                {
                    //PodcastSeasonEpisodeId = 4,
                    EpisodeName = "Episode 1",
                    EpisodeNumber = 1,
                    PodcastSeasonId = 2
                });
            context.SaveChanges();
            }

            //songandpodcast genre
            if (!context.SongAndPodcastGenres.Any(x => (x.SongAndPodcastId == 1 && x.GenreId == 1) ||
            (x.SongAndPodcastId == 2 && x.GenreId == 3)))
            {
                context.SongAndPodcastGenres.Add(new SongAndPodcastGenre()
                {
                    //SongAndPodcastGenreId=1,
                    SongAndPodcastId = 1,
                    GenreId = 1
                });
                context.SaveChanges();

                context.SongAndPodcastGenres.Add(new SongAndPodcastGenre()
                {
                    //SongAndPodcastGenreId = 2,
                    SongAndPodcastId = 2,
                    GenreId = 3
                });
            context.SaveChanges();
            }

            //songandpodcast person
            if (!context.SongAndPodcastPeople.Any(x => (x.SongAndPodcastId == 1 && x.PersonId == 2 && x.RoleId == 4)))
            {
                context.SongAndPodcastPeople.Add(new SongAndPodcastPerson()
                {
                    //SongAndPodcastPersonId=1,
                    SongAndPodcastId = 1,
                    PersonId = 2,
                    RoleId = 4
                });
            context.SaveChanges();
            }

            //rating
            //comments
            //quotes*/
        }
    }
}
