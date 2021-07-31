using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class Role
    {
        public Role()
        {
            SongAndPodcastPerson = new HashSet<SongAndPodcastPerson>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<SongAndPodcastPerson> SongAndPodcastPerson { get; set; }
    }
}
