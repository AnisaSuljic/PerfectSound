using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.News
{
    public class NewsUpsertRequest
    {
        public byte[] CoverPhoto { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public DateTime? PublicationDate { get; set; }

    }
}
