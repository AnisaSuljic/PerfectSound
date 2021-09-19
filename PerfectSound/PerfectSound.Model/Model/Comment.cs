using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateTimeOfComment { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
    }
}
