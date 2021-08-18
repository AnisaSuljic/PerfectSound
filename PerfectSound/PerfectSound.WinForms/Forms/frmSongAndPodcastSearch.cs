using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcast;
using PerfectSound.Model.ViewModels;
using PerfectSound.WinForms.Helper;
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
    public partial class frmSongAndPodcastSearch : Form
    {
        private bool SongOrPodcast = frmHome.isPodcastOrSong.isPodcast;
        APIService _GenreService = new APIService("Genre");
        APIService _SongPodGenreService = new APIService("SongAndPodcastGenre");
        APIService _SongPodcastGenreService = new APIService("SongAndPodcastGenre");
        APIService _ProdCompService = new APIService("ProductionCompany");
        APIService _SongAndPodcastService = new APIService("SongAndPodcast");

        public frmSongAndPodcastSearch()
        {
            InitializeComponent();
            dgwData.AutoGenerateColumns = false;
        }
        private async void frmSongAndPodcastSearch_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
        private async Task LoadData()
        {
            await LoadGenre();
            await LoadDGVdata();
            dtpReleaseDateSearch.Checked = false;
            dtpReleaseDateSearch.Enabled = false;
        }

        private async Task LoadGenre()
        {
            var genreList = await _GenreService.GetAll<List<Genre>>();
            genreList.Insert(0, new Genre());
            cbGenreSearch.DataSource = genreList;
            cbGenreSearch.DisplayMember = "GenreName";
            cbGenreSearch.ValueMember = "GenreId";
        }

        private async Task LoadDGVdata(object search=null)
        {
            var list = await _SongAndPodcastService.GetAll<List<SongAndPodcast>>(search);

            List<SongAndPodcast> FinalList = list.Where(x=>x.IsPodcast==SongOrPodcast).ToList();

            List<frmSongOrPodcastVM> vm = new List<frmSongOrPodcastVM>();
            foreach (var item in FinalList)
            {
                string company="Nepoznato";
                if (item.ProductionCompanyId != null)
                {
                    var tr = await _ProdCompService.GetById<ProductionCompany>(item.ProductionCompanyId);
                    company = tr.ProductionCompanyName;
                }
                
                frmSongOrPodcastVM viewmodel = new frmSongOrPodcastVM
                {
                    Id=item.SongAndPodcastId,
                    Title = item.Title,
                    ReleaseDate =item.ReleaseDate.Value.ToString("dd.MM.yyyy."),
                    RunningTime = item.RunningTime,
                    Budget = item.Budget.ToString()+"  €",
                    ProductionCompanyName=item.ProductionCompany.ProductionCompanyName
                };

                var x = item.SongAndPodcastGenre;
                var y = item.Genre;
                string lista="| ";
                foreach (var i in item.Genre)
                {
                    lista +=i.GenreName+" | ";
                }
                viewmodel.Genre = lista;
                vm.Add(viewmodel);
            }
            dgwData.DataSource = vm;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            SongAndPodcastSearchRequest SearchRequest = new SongAndPodcastSearchRequest();

            if((int)cbGenreSearch.SelectedValue != 0 || cbGenreSearch!=null)
                SearchRequest.GenreId = (int)cbGenreSearch.SelectedValue;
            if(dtpReleaseDateSearch.Enabled==true)
                SearchRequest.ReleaseDate = dtpReleaseDateSearch.Value;
            SearchRequest.Title = txtTitleSearch.Text;

            await LoadDGVdata(SearchRequest);
        }

        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            dtpReleaseDateSearch.Value = DateTime.Today;
            radioBtnUkljuciDatum.Checked = false;
            await LoadData();
        }

        bool isChecked = false;

        private void radioBtnUkljuciDatum_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioBtnUkljuciDatum.Checked;
        }

        private void radioBtnUkljuciDatum_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (radioBtnUkljuciDatum.Checked && !isChecked)
            {
                radioBtnUkljuciDatum.Checked = false;
                dtpReleaseDateSearch.Enabled = false;
            }
            else
            {
                radioBtnUkljuciDatum.Checked = true;
                dtpReleaseDateSearch.Enabled = true;
                isChecked = false;
            }
        }

        private async void dgwData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgwData.SelectedRows[0].DataBoundItem;
            var SAP = await _SongAndPodcastService.GetById<SongAndPodcast>((item as frmSongOrPodcastVM).Id);
            frmSongAndPodcastAdd frm = new frmSongAndPodcastAdd(SAP);
            frm.WindowState = FormWindowState.Normal;
            frm.MdiParent = frmHome.ActiveForm;
            frm.Show();
        }
    }
}
