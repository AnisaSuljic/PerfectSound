using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Role
    {
        public Role()
        {
            SongAndPodcastPeople = new HashSet<SongAndPodcastPerson>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<SongAndPodcastPerson> SongAndPodcastPeople { get; set; }
    }
}
