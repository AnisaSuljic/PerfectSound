using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public int? UserId { get; set; }
        public int? RatingValue { get; set; }

        public virtual SongAndPodcast SongAndPodcast { get; set; }
        public virtual User User { get; set; }
    }
}
