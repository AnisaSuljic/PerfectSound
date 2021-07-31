using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.News
{
    public class NewsSearchRequest
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }

    }
}
