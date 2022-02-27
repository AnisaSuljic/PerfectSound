using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class Rating
    {
        public int RatingId { get; set; }

        public int UserId { get; set; }
        public int SongAndPodcastId { get; set; }
        public double RatingValue { get; set; }
    }
}
