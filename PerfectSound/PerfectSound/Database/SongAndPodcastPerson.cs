using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class SongAndPodcastPerson
    {
        public int SongAndPodcastPersonId { get; set; }
        public int? SongAndPodcastId { get; set; }
        public int? PersonId { get; set; }
        public int? RoleId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Role Role { get; set; }
        public virtual SongAndPodcast SongAndPodcast { get; set; }
    }
}
