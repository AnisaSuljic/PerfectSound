using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class PodcastSeason
    {
        public PodcastSeason()
        {
            PodcastSeasonEpisodes = new HashSet<PodcastSeasonEpisode>();
        }

        public int PodcastSeasonId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public string SeasonName { get; set; }

        public virtual SongAndPodcast SongAndPodcast { get; set; }
        public virtual ICollection<PodcastSeasonEpisode> PodcastSeasonEpisodes { get; set; }
    }
}
