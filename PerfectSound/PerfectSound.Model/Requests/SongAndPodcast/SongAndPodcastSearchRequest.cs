using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.SongAndPodcast
{
    public class SongAndPodcastSearchRequest
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public bool? IsPodcast { get; set; }

        public DateTime? ReleaseDate { get; set; }

    }
}
