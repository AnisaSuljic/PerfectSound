using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class SongAndPodcast
    {
        public SongAndPodcast()
        {
            Comments = new HashSet<Comment>();
            PodcastSeasons = new HashSet<PodcastSeason>();
            Quotes = new HashSet<Quote>();
            Ratings = new HashSet<Rating>();
            SongAndPodcastGenres = new HashSet<SongAndPodcastGenre>();
            SongAndPodcastPeople = new HashSet<SongAndPodcastPerson>();
        }

        public int SongAndPodcastId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string RunningTime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Budget { get; set; }
        public byte[] Poster { get; set; }
        public int? NumberOfRatings { get; set; }
        public int? ProductionCompanyId { get; set; }
        public bool? IsPodcast { get; set; }

        public virtual ProductionCompany ProductionCompany { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PodcastSeason> PodcastSeasons { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<SongAndPodcastGenre> SongAndPodcastGenres { get; set; }
        public virtual ICollection<SongAndPodcastPerson> SongAndPodcastPeople { get; set; }
    }
}
