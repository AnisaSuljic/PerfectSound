using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class PodcastSeasonEpisode
    {
        public int PodcastSeasonEpisodeId { get; set; }
        public int? PodcastSeasonId { get; set; }
        public string EpisodeName { get; set; }
        public int? EpisodeNumber { get; set; }

    }
}
