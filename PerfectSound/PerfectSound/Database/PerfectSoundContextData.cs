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
                FirstName = "Fit",
                LastName = "Mostar",
                Email = "fit@gmail.com",
                Phone = "032165498",
                UserTypeId = 1
            };
            u1.PasswordSalt = Helper.PasswordHash.GenerateSalt();
            u1.PasswordHash = Helper.PasswordHash.GenerateHash(u1.PasswordSalt, "test");
            
            User u2 = new User()
            {
                UserId = 2,
                UserName = "mobile",
                FirstName = "FitMob",
                LastName = "MostarMob",
                Email = "FitMob@gmail.com",
                Phone = "032165498",
                UserTypeId = 2
            };
            u2.PasswordSalt = Helper.PasswordHash.GenerateSalt();
            u2.PasswordHash = Helper.PasswordHash.GenerateHash(u2.PasswordSalt, "test");

            User u3 = new User()
            {
                UserId = 3,
                UserName = "user3",
                FirstName = "User",
                LastName = "User3",
                Email = "User3@gmail.com",
                Phone = "032165498",
                UserTypeId = 2
            };
            u3.PasswordSalt = Helper.PasswordHash.GenerateSalt();
            u3.PasswordHash = Helper.PasswordHash.GenerateHash(u3.PasswordSalt, "test");

            User u4 = new User()
            {
                UserId = 4,
                UserName = "user4",
                FirstName = "User",
                LastName = "User4",
                Email = "User4@gmail.com",
                Phone = "032165498",
                UserTypeId = 2
            };
            u4.PasswordSalt = Helper.PasswordHash.GenerateSalt();
            u4.PasswordHash = Helper.PasswordHash.GenerateHash(u4.PasswordSalt, "test");

            User u5 = new User()
            {
                UserId = 5,
                UserName = "user5",
                FirstName = "User",
                LastName = "User5",
                Email = "User5@gmail.com",
                Phone = "032165498",
                UserTypeId = 2
            };
            u5.PasswordSalt = Helper.PasswordHash.GenerateSalt();
            u5.PasswordHash = Helper.PasswordHash.GenerateHash(u5.PasswordSalt, "test");

            modelBuilder.Entity<User>().HasData(
                u1,u2,u3,u4,u5
            );

            //news

            modelBuilder.Entity<News>().HasData(
                new News()
                {
                    NewsId = 1,
                    Title = "Selena Gomez: 'I won't ever quit making music'",
                    SubTitle = "Selena Gomez is putting to rest rumours that she's quitting the music industry.",
                    PublicationDate = new DateTime(2021,10,12),
                    UserId=1,
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
                    PublicationDate = new DateTime(2021, 12, 18),
                    UserId =1,
                    CoverPhoto = File.ReadAllBytes("img/edsheeran.jpg"),
                    Content = "Meanwhile, Becky Hill & David Guetta’s Remember climbs two to Number 3, becoming Becky’s second-highest charting single to date, and David Guetta’s third Top 3 hit of 2021." +
                    "Digga D scores the week’s highest new entry at Number 6 with Wasted ft.ArrDee,both rappers’ second UK Top 10.Elsewhere in the Top 10," +
                    "Industry Baby by Lil Nas X & Jack Harlow climbs four to Number 7 – Lil Nas X’s third Top 10 single and Jack Harlow’s first – while Talk About by Rain Radio &DJ Craig Gorman jumps five" +
                    "to Number 9.KSI’s Holiday rebounds two to Number 10.Lots of singles reach brand new peaks this week: Tones & I’s Fly Away(11) which climbs eight, Doja Cat’s Need To Know(12) up nine," +
                    "Anne-Marie & Little Mix’s Kiss My(Uh Oh)(14), Wizkid’s Essence ft.Tems(17) – which zooms 18 places following a new remix with Justin Bieber – and Mabel’s Let Them Know(19)."
                },
                new News()
                {
                    NewsId = 3,
                    Title = "Olivia Rodrigo says her forthcoming film will feature unreleased music",
                    SubTitle = "Driving Home 2 U (A Sour Film)' is coming later this month ahead of Rodrigo's debut headline tour",
                    PublicationDate = new DateTime(2022, 01, 06),
                    UserId = 1,
                    CoverPhoto = File.ReadAllBytes("img/Olivia.jpg"),
                    Content = "The film is being released on Disney+ on March 25, and will feature a combination of live performances of tracks from her debut album ‘Sour’,"+
                    "interviews about the songs, and behind-the-scenes footage shot during recording sessions. In a new interview with Rolling Stone,"+
                    "she revealed that she’s added a previously - unreleased song to the end credits, a currently - untitled iPhone demo that is reportedly still in progress."+
                    "“I was listening to some of[the unreleased tracks] and heard it and thought, ‘Oh, it’s kind of good!”" +
                    "She added that she’s been back in the studio working on the follow up to her platinum-selling debut LP. “I’m so, so excited to put out new music and to create the next set of worlds.”"
                },
                new News()
                {
                    NewsId = 4,
                    Title = "Paul Weller announced as special guest for Madness’ Royal Albert Hall show",
                    SubTitle = "Weller will be joined by his band for an exclusive acoustic set",
                    PublicationDate = DateTime.Today,
                    UserId = 1,
                    CoverPhoto = File.ReadAllBytes("img/Paul.jpg"),
                    Content = "The longstanding ska group had previously been announced to perform at the famous venue, one of a series of high-profile shows in aid of the Teenage Cancer Trust this month."+
                    "Now, Weller has been announced for an exclusive guest appearance which takes place on March 24. He will be joined by his band for a unique acoustic set."+
                    "Madness’ gig is one of a number of shows taking place at the Albert Hall between March 21 and 27, with Don Broco, Yungblud, Liam Gallagher, The Who and Ed Sheeran also appearing. For the full list of dates, and remaining tickets, click here."+
                    "The venue will also host a night of comedy on March 22, featuring Joel Dommett, Rob Beckett, Rosie Jones, Romesh Ranganathan and more."+
                    "Elsewhere, Madness are set to throw an “all-day party” in London to coincide with the Queen’s Jubilee Bank Holiday weekend in June."+
                    "The group shared a tongue-in-cheek video on Instagram that showed frontman Suggs being knighted by a Queen lookalike and features references to Game Of Thrones"+
                    "In November, it was announced that Madness would be headlining Tramlines festival alongside Sam Fender and Kasabian."

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
                },
                new Role()
                {
                    RoleId = 6,
                    RoleName = "Manager"
                },
                new Role()
                {
                    RoleId = 7,
                    RoleName = "Trumpeter"
                },
                new Role()
                {
                    RoleId = 8,
                    RoleName = "Pianist"
                },
                new Role()
                {
                    RoleId = 9,
                    RoleName = "Podcast presenter"
                },
                new Role()
                {
                    RoleId = 10,
                    RoleName = "Podcast guest"
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
                },
                new Person()
                {
                    PersonId = 3,
                    FirstName = "Ariana",
                    LastName = "Grande",
                    Photo = File.ReadAllBytes("img/Ariana.png"),
                    Biography = "American singer, songwriter, and actress. Her four-octave vocal range has received public acclaim, and her personal life has been the subject of widespread media attention. She has received numerous accolades throughout her career, including two Grammy Awards, one Brit Award, one Bambi Award, two Billboard Music Awards, three American Music Awards, nine MTV Video Music Awards, and 26 Guinness World Records.",
                    DateOfBirth = new DateTime(1993, 06, 26),
                    PlaceOfBirth = "Boca Raton, Florida, U.S.",
                    DateOfDeath = null,
                    GenderId = 2
                },
                new Person()
                {
                    PersonId = 4,
                    FirstName = "Justin",
                    LastName = "Timberlake",
                    Photo = File.ReadAllBytes("img/Justin.jpg"),
                    Biography = "Edward Christopher - Ed Sheeran is a famous English singer and songwriter, who has won the hearts of people all over the world with his melodic voice. He is an occasional rapper and actor as well. His popularity increased especially after the release of his first album ‘+’ and after a guest appearance was made by him on Taylor Swift's fourth studio album 'Red.’ He began recording music in 2004. His first work 'Spinning Man' was released independently. After moving to London from Suffolk in 2008, he used to play in small venues and also released the EP ‘You Need me’ in 2009. While in London, he also auditioned for a British musical drama television series ‘Britannia High.’ His debut album '+' was released in September 2011.",
                    DateOfBirth = new DateTime(1981, 01, 31),
                    PlaceOfBirth = "Memphis, Tennessee, U.S.",
                    DateOfDeath = null,
                    GenderId = 1
                },
                new Person()
                {
                    PersonId = 5,
                    FirstName = "Michael",
                    LastName = "Jackson",
                    Photo = File.ReadAllBytes("img/Jackson.jpg"),
                    Biography = "He was an American singer, songwriter and dancer. Dubbed the 'King of Pop', he is regarded as one of the most significant cultural figures of the 20th century. Over a four-decade career, his contributions to music, dance and fashion, along with his publicized personal life, made him a global figure in popular culture. Jackson influenced artists across many music genres; through stage and video performances, he popularized complicated dance moves such as the moonwalk, to which he gave the name, as well as the robot. He is the most awarded individual music artist in history.",
                    DateOfBirth = new DateTime(1958, 08, 29),
                    PlaceOfBirth = "Gary, Indiana, U.S.",
                    DateOfDeath = new DateTime(2009, 06, 25),
                    GenderId = 1
                },
                new Person()
                {
                    PersonId = 6,
                    FirstName = "Madonna Louise",
                    LastName = "Ciccone",
                    Photo = File.ReadAllBytes("img/Madonna.jpg"),
                    Biography = "She is an American singer-songwriter and actress. She is considered one of the most influential figures in popular culture and has often been referred to as the 'Queen of Pop'. Madonna is noted for her continual reinvention and versatility in music production, songwriting, and visual presentation. She is also known for pushing the boundaries of artistic expression in mainstream music, while maintaining control over every aspect of her career.[4] Her works, which incorporate social, political, sexual, and religious themes, have generated both controversy and critical acclaim.",
                    DateOfBirth = new DateTime(1958, 08, 16),
                    PlaceOfBirth = "Bay City, Michigan, U.S.",
                    DateOfDeath = null,
                    GenderId = 2
                },
                new Person()
                {
                    PersonId = 7,
                    FirstName = "Nicki",
                    LastName = "Minaj",
                    Photo = File.ReadAllBytes("img/Nicki.png"),
                    Biography = "Nicki is a Trinidadian-born rapper, singer, songwriter and actress. She is noted for her versatility as an artist, her lyricism and animated flow in her rapping and her usage of alter egos and accents. Minaj first gained recognition after releasing three mixtapes between 2007 and 2009. She rose to fame with her debut album, Pink Friday (2010), which topped the U.S. Billboard 200. The fifth single, 'Super Bass', reached number three on the U.S. Billboard Hot 100 and became the highest charting solo song by a female rapper since 2002. It also became the second song by a female rapper to become diamond certified in the US.",
                    DateOfBirth = new DateTime(1982, 10, 8),
                    PlaceOfBirth = "Saint James, Port of Spain",
                    DateOfDeath = null,
                    GenderId = 2
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
                },
                new Genre()
                {
                    GenreId = 6,
                    GenreName = "Electronic"
                },
                new Genre()
                {
                    GenreId = 7,
                    GenreName = "Classical"
                },
                new Genre()
                {
                    GenreId = 8,
                    GenreName = "Dance"
                }
            );

            //rating

            modelBuilder.Entity<Rating>().HasData(
                new Rating()
                {
                    RatingId = 1,
                    SongAndPodcastId = 1,
                    UserId = 4,
                    RatingValue = 3
                },
                new Rating()
                {
                    RatingId = 2,
                    SongAndPodcastId = 2,
                    UserId = 3,
                    RatingValue = 4.5
                },
                new Rating()
                {
                    RatingId = 3,
                    SongAndPodcastId = 2,
                    UserId = 5,
                    RatingValue = 3.5
                },
                new Rating()
                {
                    RatingId = 4,
                    SongAndPodcastId = 1,
                    UserId = 2,
                    RatingValue = 5
                },
                new Rating()
                {
                    RatingId = 5,
                    SongAndPodcastId = 3,
                    UserId = 2,
                    RatingValue = 3.5
                },
                new Rating()
                {
                    RatingId = 6,
                    SongAndPodcastId = 3,
                    UserId = 3,
                    RatingValue = 2.5
                },
                new Rating()
                {
                    RatingId = 7,
                    SongAndPodcastId = 4,
                    UserId = 4,
                    RatingValue = 4.5
                },
                new Rating()
                {
                    RatingId = 8,
                    SongAndPodcastId = 4,
                    UserId = 5,
                    RatingValue = 3.5
                },
                new Rating()
                {
                    RatingId = 9,
                    SongAndPodcastId = 4,
                    UserId = 2,
                    RatingValue = 3.0
                },
                new Rating()
                {
                    RatingId = 10,
                    SongAndPodcastId = 5,
                    UserId = 5,
                    RatingValue = 5
                },
                new Rating()
                {
                    RatingId = 11,
                    SongAndPodcastId = 5,
                    UserId = 3,
                    RatingValue = 4.5
                },
                new Rating()
                {
                    RatingId = 12,
                    SongAndPodcastId = 6,
                    UserId = 2,
                    RatingValue = 2.0
                },
                new Rating()
                {
                    RatingId = 13,
                    SongAndPodcastId = 6,
                    UserId = 2,
                    RatingValue = 3.5
                },
                new Rating()
                {
                    RatingId = 14,
                    SongAndPodcastId = 7,
                    UserId = 3,
                    RatingValue = 2.0
                },
                new Rating()
                {
                    RatingId = 15,
                    SongAndPodcastId = 7,
                    UserId = 4,
                    RatingValue = 4.0
                },
                new Rating()
                {
                    RatingId = 16,
                    SongAndPodcastId = 7,
                    UserId = 5,
                    RatingValue = 2.0
                },
                new Rating()
                {
                    RatingId = 17,
                    SongAndPodcastId = 8,
                    UserId = 2,
                    RatingValue = 5
                },
                new Rating()
                {
                    RatingId = 18,
                    SongAndPodcastId = 8,
                    UserId = 4,
                    RatingValue = 4.5
                },
                new Rating()
                {
                    RatingId = 19,
                    SongAndPodcastId = 9,
                    UserId = 4,
                    RatingValue = 3.0
                },
                new Rating()
                {
                    RatingId = 20,
                    SongAndPodcastId = 9,
                    UserId = 5,
                    RatingValue = 1.5
                },
                new Rating()
                {
                    RatingId = 21,
                    SongAndPodcastId = 10,
                    UserId = 3,
                    RatingValue = 3.5
                },
                new Rating()
                {
                    RatingId = 22,
                    SongAndPodcastId = 10,
                    UserId = 4,
                    RatingValue = 3.0
                },
                new Rating()
                {
                    RatingId = 23,
                    SongAndPodcastId = 11,
                    UserId = 4,
                    RatingValue = 2.0
                },
                new Rating()
                {
                    RatingId = 24,
                    SongAndPodcastId = 11,
                    UserId = 5,
                    RatingValue = 3.0
                },
                new Rating()
                {
                    RatingId = 25,
                    SongAndPodcastId = 11,
                    UserId = 2,
                    RatingValue = 2.0
                },
                new Rating()
                {
                    RatingId = 26,
                    SongAndPodcastId = 10,
                    UserId = 2,
                    RatingValue = 5
                },
                new Rating()
                {
                    RatingId = 27,
                    SongAndPodcastId = 10,
                    UserId = 5,
                    RatingValue = 3.5
                },
                new Rating()
                {
                    RatingId = 28,
                    SongAndPodcastId = 9,
                    UserId = 2,
                    RatingValue = 1.5
                },
                new Rating()
                {
                    RatingId = 29,
                    SongAndPodcastId = 9,
                    UserId = 3,
                    RatingValue = 3.5
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
                    Poster = File.ReadAllBytes("img/Perfect.jpg"),
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
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 3,
                    Title = "Like A Prayer",
                    Text = "Life is a mystery"+
                            "Everyone must stand alone" +
                            "I hear you call my name" +
                            "And it feels like home" +
                            "When you call my name it's like a little prayer" +
                            "I'm down on my knees, I wanna take you there" +
                            "In the midnight hour I can feel your power" +
                            "Just like a prayer you know I'll take you there" +
                            "I hear your voice" +
                            "It's like an angel sighing" +
                            "I have no choice, I hear your voice"+
                            "Feels like flying" +
                            "I close my eyes" +
                            "Oh God I think I'm falling" +
                            "Out of the sky, I close my eyes",
                    RunningTime = "00:06:10",
                    ReleaseDate = new DateTime(1989, 03, 16),
                    Budget = 2890,
                    Poster = File.ReadAllBytes("img/prayer.jpg"),
                    ProductionCompanyId = 3,
                    IsPodcast = false
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 4,
                    Title = "Cry Me a River",
                    Text = "You were my sun" +
                            "You were my earth" +
                            "But you didn't know all the ways I loved you, no" +
                            "So you took a chance" +
                            "And made other plans" +
                            "But I bet you didn't think that they would come crashing down, no" +

                            "You don't have to say, what you did" +
                            "I already know, I found out from him" +
                            "Now there's just no chance" +
                            "For you and me"+
                            "There'll never be" +
                            "And don't it make you sad about it?",
                    RunningTime = "00:04:49",
                    ReleaseDate = new DateTime(2017, 01, 25),
                    Budget = 4250,
                    Poster = File.ReadAllBytes("img/cry.jpg"),
                    ProductionCompanyId = 2,
                    IsPodcast = false
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 5,
                    Title = "In the Closet",
                    Text = "There's something I have to say to you" +
                            "If you promise you'll understand," +
                            "I cannot contain myself" +
                            "When in your presence" +
                            "I'm so humble" +
                            "Touch me" +
                            "Don't hide our love" +
                            "Woman to man" +
                            "She's just a lover" +
                            "Who's doin' me by"+
                            "Is it worth the giving?" +
                            "Is it worth the try?" +
                            "You cannot cleave it" +
                            "Or put it in the furnace" +
                            "You cannot wet it" +
                            "You cannot burn it",
                    RunningTime = "00:04:49",
                    ReleaseDate = new DateTime(1992, 04, 09),
                    Budget = 4300,
                    Poster = File.ReadAllBytes("img/closet.jpg"),
                    ProductionCompanyId = 5,
                    IsPodcast = false
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 6,
                    Title = "Side To Side",
                    Text = "I've been here all night" +
                            "I've been here all day" +
                            "And boy, got me walkin' side to side" +
                            "(Let them hoes know)" +
                            "I'm talkin' to ya" +
                            "See you standing over there with your body" +
                            "Feeling like I wanna rock with your body" +
                            "And we don't gotta think 'bout nothin' ('Bout nothin')" +
                            "I'm comin' at ya" +
                            "Cause I know you got a bad reputation" +
                            "Doesn't matter, 'cause you give me temptation" +
                            "And we don't gotta think 'bout nothin' ('Bout nothin')" +
                            "These friends keep talkin' way too much" +
                            "Say I should give you up" +
                            "Can't hear them no, 'cause I...",
                    RunningTime = "00:0:47",
                    ReleaseDate = new DateTime(2016, 08, 28),
                    Budget = 5300,
                    Poster = File.ReadAllBytes("img/sidetoside.jpg"),
                    ProductionCompanyId = 2,
                    IsPodcast = false
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 7,
                    Title = "La Isla Bonita",
                    Text = "Last night I dreamt of San Pedro" +
                            "Just like I'd never gone, I knew the song" +
                            "A young girl with eyes like the desert" +
                            "It all seems like yesterday, not far away" +
                            "Tropical the island breeze" +
                            "All of nature wild and free" +
                            "This is where I long to be" +
                            "La isla bonita" +
                            "And when the samba played" +
                            "The sun would set so high" +
                            "Ring through my ears and sting my eyes" +
                            "Your Spanish lullaby" +
                            "I fell in love with San Pedro" +
                            "Warm wind carried on the sea, he called to me" +
                            "Te dijo te amo...",
                    RunningTime = "00:04:03",
                    ReleaseDate = new DateTime(1987, 02, 25),
                    Budget = 1750,
                    Poster = File.ReadAllBytes("img/Bonita.png"),
                    ProductionCompanyId = 3,
                    IsPodcast = false
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 8,
                    Title = "Rolling Stone Music Now",
                    Text = "",
                    RunningTime = null,
                    ReleaseDate = new DateTime(2020, 12, 30),
                    Budget = 8500,
                    Poster = File.ReadAllBytes("img/roling.jpg"),
                    ProductionCompanyId = 4,
                    IsPodcast = true
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 9,
                    Title = "All Songs Considered",
                    Text = "",
                    RunningTime = null,
                    ReleaseDate = new DateTime(2000, 12, 02),
                    Budget = 6800,
                    Poster = File.ReadAllBytes("img/allsong.jpg"),
                    ProductionCompanyId = 2,
                    IsPodcast = true
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 10,
                    Title = "Song Travels Express",
                    Text = "",
                    RunningTime = null,
                    ReleaseDate = new DateTime(2015, 10, 16),
                    Budget = 8100,
                    Poster = File.ReadAllBytes("img/travels.png"),
                    ProductionCompanyId = 1,
                    IsPodcast = true
                },
                new SongAndPodcast()
                {
                    SongAndPodcastId = 11,
                    Title = "Mountain Stage Podcast",
                    Text = "",
                    RunningTime = null,
                    ReleaseDate = new DateTime(2022, 03, 02),
                    Budget = 12700,
                    Poster = File.ReadAllBytes("img/mountain.png"),
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
                },
                new PodcastSeason()
                {
                    PodcastSeasonId = 4,
                    SeasonName = "Season pilot 0",
                    SongAndPodcastId = 11
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
                },
                new PodcastSeasonEpisode()
                {
                    PodcastSeasonEpisodeId = 5,
                    EpisodeName = "Episode 0",
                    EpisodeNumber = 1,
                    PodcastSeasonId = 4
                },
                new PodcastSeasonEpisode()
                {
                    PodcastSeasonEpisodeId = 6,
                    EpisodeName = "Episode 1",
                    EpisodeNumber = 2,
                    PodcastSeasonId = 4
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
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 3,
                    SongAndPodcastId = 2,
                    GenreId = 5
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 4,
                    SongAndPodcastId = 3,
                    GenreId = 5
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 5,
                    SongAndPodcastId = 3,
                    GenreId = 1
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 6,
                    SongAndPodcastId = 4,
                    GenreId = 5
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 7,
                    SongAndPodcastId = 5,
                    GenreId = 2
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 8,
                    SongAndPodcastId = 5,
                    GenreId = 3
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 9,
                    SongAndPodcastId = 6,
                    GenreId = 1
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 10,
                    SongAndPodcastId = 7,
                    GenreId = 4
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 11,
                    SongAndPodcastId = 8,
                    GenreId = 4
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 12,
                    SongAndPodcastId = 8,
                    GenreId = 3
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 13,
                    SongAndPodcastId = 9,
                    GenreId = 1
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 14,
                    SongAndPodcastId = 10,
                    GenreId = 5
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 15,
                    SongAndPodcastId = 10,
                    GenreId = 2
                },
                new SongAndPodcastGenre()
                {
                    SongAndPodcastGenreId = 16,
                    SongAndPodcastId = 11,
                    GenreId = 2
                }
            );

            //songandpodcast person
            modelBuilder.Entity<SongAndPodcastPerson>().HasData(
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId=1,
                    SongAndPodcastId = 1,
                    PersonId = 2,
                    RoleId = 1
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 2,
                    SongAndPodcastId = 2,
                    PersonId = 3,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 3,
                    SongAndPodcastId = 3,
                    PersonId = 6,
                    RoleId = 1
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 4,
                    SongAndPodcastId = 4,
                    PersonId = 4,
                    RoleId = 1
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 5,
                    SongAndPodcastId = 5,
                    PersonId = 5,
                    RoleId = 1
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 6,
                    SongAndPodcastId = 6,
                    PersonId = 3,
                    RoleId = 1
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 7,
                    SongAndPodcastId = 7,
                    PersonId = 6,
                    RoleId = 1
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 8,
                    SongAndPodcastId = 8,
                    PersonId = 6,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 9,
                    SongAndPodcastId = 9,
                    PersonId = 3,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 10,
                    SongAndPodcastId = 10,
                    PersonId = 4,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 11,
                    SongAndPodcastId = 11,
                    PersonId = 2,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 12,
                    SongAndPodcastId = 6,
                    PersonId = 7,
                    RoleId = 2
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 13,
                    SongAndPodcastId = 2,
                    PersonId = 5,
                    RoleId = 10
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 14,
                    SongAndPodcastId = 8,
                    PersonId = 2,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 15,
                    SongAndPodcastId = 8,
                    PersonId = 4,
                    RoleId = 10
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 16,
                    SongAndPodcastId = 10,
                    PersonId = 7,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 17,
                    SongAndPodcastId = 10,
                    PersonId = 3,
                    RoleId = 10
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 18,
                    SongAndPodcastId = 9,
                    PersonId = 2,
                    RoleId = 9
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 19,
                    SongAndPodcastId = 9,
                    PersonId = 7,
                    RoleId = 10
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 20,
                    SongAndPodcastId = 11,
                    PersonId = 1,
                    RoleId = 10
                },
                new SongAndPodcastPerson()
                {
                    SongAndPodcastPersonId = 21,
                    SongAndPodcastId = 11,
                    PersonId = 7,
                    RoleId = 9
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
                    UserId = 3,
                    DateTimeOfComment = new DateTime(2021, 07, 12),
                    Content = "Komentar 2"
                },
                new Comment()
                {
                    CommentId = 3,
                    SongAndPodcastId = 5,
                    UserId = 4,
                    DateTimeOfComment = new DateTime(2020, 07, 05),
                    Content = "Komentar korisnika 4"
                },
                new Comment()
                {
                    CommentId = 4,
                    SongAndPodcastId = 8,
                    UserId = 3,
                    DateTimeOfComment = new DateTime(2022, 01, 12),
                    Content = "Super!"
                },
                new Comment()
                {
                    CommentId = 5,
                    SongAndPodcastId = 10,
                    UserId = 5,
                    DateTimeOfComment = new DateTime(2021, 03, 22),
                    Content = "Odlično!"
                },
                new Comment()
                {
                    CommentId = 6,
                    SongAndPodcastId =1,
                    UserId = 3,
                    DateTimeOfComment = new DateTime(2022, 07, 03),
                    Content = "Nisam oduševljen"
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
                },
                new Quote()
                {
                    QuoteId = 3,
                    SongAndPodcastId = 5,
                    QuoteText = "There's something I have to say to you if you promise you'll understand..."
                },
                new Quote()
                {
                    QuoteId = 4,
                    SongAndPodcastId = 3,
                    QuoteText = "Just like a prayer you know I'll take you there..."
                },
                new Quote()
                {
                    QuoteId = 5,
                    SongAndPodcastId = 4,
                    QuoteText = "You know that they say that some things are better left unsaid..."
                }
            );
        }
    }
}
