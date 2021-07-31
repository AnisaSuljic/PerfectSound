using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.Quote
{
    public class QuoteUpsertRequest
    {
        public int? SongAndPodcastId { get; set; }
        public string QuoteText { get; set; }
    }
}
