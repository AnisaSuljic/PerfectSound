using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class PodcastSeason
    {
        public int PodcastSeasonId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public string SeasonName { get; set; }
    }
}
