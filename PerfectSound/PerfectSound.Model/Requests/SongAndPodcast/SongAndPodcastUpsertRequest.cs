using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PerfectSound.Model.Requests.SongAndPodcast
{
    public class SongAndPodcastUpsertRequest
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string RunningTime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Budget { get; set; }
        public byte[] Poster { get; set; }
        public int? ProductionCompanyId { get; set; }
        public bool? IsPodcast { get; set; }
        public List<int> GenreIDList { get; set; } = new List<int>();

    }
}
