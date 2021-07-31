using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.Comment
{
    public class CommentUpsertRequest
    {
        public int? SongAndPodcastId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateTimeOfComment { get; set; }
        public string Content { get; set; }
    }
}
