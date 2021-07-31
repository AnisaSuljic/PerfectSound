using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Requests.SongAndPodcastPerson
{
    public class SongAndPodcastPersonUpsertRequest
    {
        public int? SongAndPodcastId { get; set; }
        public int? PersonId { get; set; }
        public int? RoleId { get; set; }
    }
}
