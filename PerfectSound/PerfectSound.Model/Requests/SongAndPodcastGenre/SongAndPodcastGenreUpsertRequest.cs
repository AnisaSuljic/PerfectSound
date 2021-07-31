using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.SongAndPodcastGenre
{
    public class SongAndPodcastGenreUpsertRequest
    {
        public int? SongAndPodcastId { get; set; }
        public int? GenreId { get; set; }
    }
}
