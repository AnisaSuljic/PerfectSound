using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectSound.WinForms.Forms
{
    public partial class SongAndPodcastAdd : Form
    {
        APIService _GenreService = new APIService("Genre");

        private SongAndPodcast _songpodcast;
        bool isChecked;
        public SongAndPodcastAdd(SongAndPodcast songpodcast=null)
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            isChecked = false;
            podcastBtn.Checked = false;
            LoadGenersAsync();

        }

        public async Task LoadGenersAsync()
        {
            var genreList = await _GenreService.GetAll<List<Genre>>();
            cbGenre.DataSource = genreList;
            cbGenre.DisplayMember = "GenreName";
            Console.WriteLine(genreList);

        }

        
        private void podcastBtn_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = true;
        }

        private void podcastBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (podcastBtn.Checked && !isChecked)
            {
                podcastBtn.Checked = false;
                txtRunningTime.Enabled = true;
                richtxtSong.Enabled = true;
            }
            else
            {
                podcastBtn.Checked = true;
                isChecked = false;
                txtRunningTime.Enabled = false;
                txtRunningTime.Text = "";
                richtxtSong.Enabled = false;
                richtxtSong.Text = "";
            }
        }

        
    }
}
