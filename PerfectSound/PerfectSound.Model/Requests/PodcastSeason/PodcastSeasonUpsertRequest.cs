using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.PodcastSeason
{
    public class PodcastSeasonUpsertRequest
    {
        public int? SongAndPodcastId { get; set; }
        public string SeasonName { get; set; }
    }
}
