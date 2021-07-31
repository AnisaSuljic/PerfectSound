using System;
using System.Collections.Generic;

#nullable disable

namespace PerfectSound.Database
{
    public partial class ProductionCompany
    {
        public ProductionCompany()
        {
            SongAndPodcasts = new HashSet<SongAndPodcast>();
        }

        public int ProductionCompanyId { get; set; }
        public string ProductionCompanyName { get; set; }

        public virtual ICollection<SongAndPodcast> SongAndPodcasts { get; set; }
    }
}
