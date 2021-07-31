using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Genre
    {
        public Genre()
        {
            SongAndPodcastGenres = new HashSet<SongAndPodcastGenre>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<SongAndPodcastGenre> SongAndPodcastGenres { get; set; }
    }
}
