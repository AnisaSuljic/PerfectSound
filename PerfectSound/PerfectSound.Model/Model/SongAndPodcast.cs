using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class SongAndPodcast
    {
        public int SongAndPodcastId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string RunningTime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Budget { get; set; }
        public byte[] Poster { get; set; }
        public int? NumberOfRatings { get; set; }
        public int? ProductionCompanyId { get; set; }
    }
}
