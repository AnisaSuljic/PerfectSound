using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class PodcastSeasonEpisode
    {
        public int PodcastSeasonEpisodeId { get; set; }
        public int? PodcastSeasonId { get; set; }
        public string EpisodeName { get; set; }
        public int? EpisodeNumber { get; set; }

        public virtual PodcastSeason PodcastSeason { get; set; }
    }
}
