using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class SongAndPodcastGenre
    {
        public int SongAndPodcastGenreId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual SongAndPodcast SongAndPodcast { get; set; }
    }
}
