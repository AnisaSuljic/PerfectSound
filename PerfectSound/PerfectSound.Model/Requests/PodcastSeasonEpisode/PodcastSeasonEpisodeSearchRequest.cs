using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.PodcastSeasonEpisode
{
    public class PodcastSeasonEpisodeSearchRequest
    {
        public int? PodcastSeasonId { get; set; }
        public string EpisodeName { get; set; }
        public int? EpisodeNumber { get; set; }
    }
}
