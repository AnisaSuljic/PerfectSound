using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.SongAndPodcastPerson
{
    public class SongAndPodcastPersonSearchRequest
    {
        public int? PersonId { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }
        public int SongAndPodcastId { get; set; }

    }
}
