using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
     public class Quote
    {
        public int QuoteId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public string QuoteText { get; set; }
    }
}
