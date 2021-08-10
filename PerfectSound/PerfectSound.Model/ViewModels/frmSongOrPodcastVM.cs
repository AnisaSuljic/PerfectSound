using System;
using System.Collections.Generic;
using System.Text;

namespace PerfectSound.Model.ViewModels
{
    public class frmSongOrPodcastVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RunningTime { get; set; }
        public string ReleaseDate { get; set; }
        public string Budget { get; set; }
        public string ProductionCompanyName { get; set; }
        public string Genre { get; set; }
    }
}
