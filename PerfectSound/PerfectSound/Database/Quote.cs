using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public string QuoteText { get; set; }

        public virtual SongAndPodcast SongAndPodcast { get; set; }
    }
}
