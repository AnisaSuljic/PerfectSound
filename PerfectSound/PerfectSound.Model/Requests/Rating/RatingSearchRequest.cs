using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.Rating
{
    public class RatingSearchRequest
    {
        public int UserId { get; set; }
        public int SongAndPodcastId { get; set; }
    }
}
