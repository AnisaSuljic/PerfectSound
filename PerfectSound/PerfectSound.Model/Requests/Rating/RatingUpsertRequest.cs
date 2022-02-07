using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.Rating
{
    public class RatingUpsertRequest
    {
        public int? SongAndPodcastId { get; set; }
        public int? UserId { get; set; }
        public double? RatingValue { get; set; }
    }
}
