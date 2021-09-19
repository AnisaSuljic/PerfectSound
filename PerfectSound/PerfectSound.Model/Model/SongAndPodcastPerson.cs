using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.Model
{
    public class SongAndPodcastPerson
    {
        public int SongAndPodcastPersonId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public int? PersonId { get; set; }
        public int? RoleId { get; set; }

        public Person Person { get; set; }
        public SongAndPodcast SongAndPodcast { get; set; }
        public Role Role { get; set; }

    }
}
