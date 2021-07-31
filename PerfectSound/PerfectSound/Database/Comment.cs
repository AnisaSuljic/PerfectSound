using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateTimeOfComment { get; set; }
        public string Content { get; set; }

        public virtual SongAndPodcast SongAndPodcast { get; set; }
        public virtual User User { get; set; }
    }
}
