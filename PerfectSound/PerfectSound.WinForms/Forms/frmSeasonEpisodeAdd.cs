using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.PodcastSeason;
using PerfectSound.Model.Requests.PodcastSeasonEpisode;
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
    public partial class frmSeasonEpisodeAdd : Form
    {
        APIService _SeasonService = new APIService("PodcastSeason");
        APIService _EpisodeService = new APIService("PodcastSeasonEpisode");
        PodcastSeasonUpsertRequest _upsertRequest = new PodcastSeasonUpsertRequest();
        PodcastSeasonEpisodeUpsertRequest _upsertRequestEpisode = new PodcastSeasonEpisodeUpsertRequest();

        bool isEdit;
        SongAndPodcast _sap;
        public frmSeasonEpisodeAdd(SongAndPodcast SAP=null)
        {
            InitializeComponent();
            _sap = SAP;
            dgwEpisodes.AutoGenerateColumns = false;
            dgvSeasons.AutoGenerateColumns = false;
            if (SAP != null)
                isEdit = true;
            else
                isEdit = false;
        }

        private async void frmSeasonEpisodeAdd_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await LoadSeasonsAsync();
            await LoadDGWEpisodes();
            await LoadDGWSeason();
        }

        private async Task LoadDGWSeason()
        {
            var SeasonList = await _SeasonService.GetAll<List<PodcastSeason>>();
            List<PodcastSeason> finalList = new List<PodcastSeason>();
            if (isEdit == true)
                finalList = SeasonList.Where(s => s.SongAndPodcastId == _sap.SongAndPodcastId).ToList();

            dgvSeasons.DataSource = finalList;
        }

        private async Task LoadDGWEpisodes(PodcastSeason season=null)
        {
            //lista svih epizoda iz baze
            var list = await _EpisodeService.GetAll<List<PodcastSeasonEpisode>>();
            //nova lista epizoda sa ranije povucenim vrijednostima iz baze
            List<PodcastSeasonEpisode> finalList = list.ToList();

            //lista svih sezona iz baze
            var SeasonList = await _SeasonService.GetAll<List<PodcastSeason>>();
            //nova lista sezona sa ranije povucenim vrijednostima iz baze
            List<PodcastSeason> ps = SeasonList.ToList();

            //ako se radi o filtriranju po sezonama
            if (season != null)
            {
                finalList=finalList.Where(s => s.PodcastSeasonId == season.PodcastSeasonId).ToList();                
            }

            //nova lista epizoda koja ce se prikazivati u dgw
            List<PodcastSeasonEpisode> EpisodeList = new List<PodcastSeasonEpisode>();

            //ako podcast vec postoji onda on ima svoje sezone i epizoda
            if (isEdit == true)
            {
                //lista sezona po ID podcast-a
                ps= ps.Where(s => s.SongAndPodcastId == _sap.SongAndPodcastId).ToList();
                
                //prolazi se kroz listu epizoda
                for (int i = 0; i < finalList.Count; i++)
                {
                    //prolazi se kroz listu sezona
                    for (int j = 0; j < ps.Count; j++)
                    {
                        //ako se ID sezone poklapaju dodaju se epizode u EpisodeList
                        if (finalList[i].PodcastSeasonId == ps[j].PodcastSeasonId)
                        {
                            EpisodeList.Add(finalList[i]);
                        }
                    }
                }
            }
            finalList = EpisodeList.OrderBy(e=>e.EpisodeNumber).ToList();

            List<frmEpisodesVM> vm = new List<frmEpisodesVM>();

            foreach (var item in finalList)
            {
                frmEpisodesVM viewmodel = new frmEpisodesVM
                {
                    Id = item.PodcastSeasonEpisodeId,
                    EpisodeName = item.EpisodeName,
                    EpisodeNumber = (int)item.EpisodeNumber,
                };

                vm.Add(viewmodel);
            }
            dgwEpisodes.DataSource = vm;
        }

        private async Task LoadSeasonsAsync()
        {
            var SeasonList = await _SeasonService.GetAll<List<PodcastSeason>>();
            List<PodcastSeason> finalList = new List<PodcastSeason>();
            List<PodcastSeason> finalList1 = new List<PodcastSeason>();
            if (isEdit == true)
            {
                finalList = SeasonList.Where(s => s.SongAndPodcastId == _sap.SongAndPodcastId).ToList();
                finalList1 = SeasonList.Where(s => s.SongAndPodcastId == _sap.SongAndPodcastId).ToList();
            }

            cbSeason.DataSource = finalList;
            cbSeason.DisplayMember = "SeasonName";
            cbSeason.ValueMember = "PodcastSeasonId";

            cbSeasonSearch.DataSource = finalList1;
            cbSeasonSearch.DisplayMember = "SeasonName";
            cbSeasonSearch.ValueMember = "PodcastSeasonId";


        }

        private async void cbSeasonSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var seasonID = cbSeasonSearch.SelectedValue;
            var season = await _SeasonService.GetById<PodcastSeason>(seasonID);
            await LoadDGWEpisodes(season);
        }

        private async void btnAddSeason_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (ErrorCheckSeason() == true)
                {
                    _upsertRequest.SongAndPodcastId = _sap.SongAndPodcastId;
                    _upsertRequest.SeasonName = txtSeasonName.Text;
                    try
                    {
                            await _SeasonService.Insert<PodcastSeason>(_upsertRequest);
                            MessageBox.Show("Successfully added.");
                            frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                            frm.MdiParent = frmHome.ActiveForm;
                            frm.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Adding was not successfully. Please try again.");
                        frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                        frm.MdiParent = frmHome.ActiveForm;
                        frm.Show();
                    }
                }
            }
        }

        private bool ErrorCheckSeason()
        {
            if (!ErrorHandler.RequiredFiled(txtSeasonName, errorSeasonAdd) )
                return false;

            return true;

        }
        private bool ErrorCheckEpisode()
        {
            if (!ErrorHandler.RequiredFiled(txtEpisodeName, errorSeasonAdd)
                || !ErrorHandler.RequiredFiled(txtEpisodeNumber, errorSeasonAdd))
                return false;
            return true;
        }

        private async void btnAddEpisode_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (ErrorCheckEpisode() == true)
                {
                    _upsertRequestEpisode.PodcastSeasonId = (int?)cbSeason.SelectedValue;
                    _upsertRequestEpisode.EpisodeName = txtEpisodeName.Text;
                    _upsertRequestEpisode.EpisodeNumber = (int?)txtEpisodeNumber.Value;
                    try
                    {
                        await _EpisodeService.Insert<PodcastSeasonEpisode>(_upsertRequestEpisode);
                        MessageBox.Show("Successfully added.");
                        frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                        frm.MdiParent = frmHome.ActiveForm;
                        frm.Show();

                    }
                    catch
                    {
                        MessageBox.Show("Adding was not successfully. Please try again.");
                        frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                        frm.MdiParent = frmHome.ActiveForm;
                        frm.Show();
                    }
                }
            }
        }

        private void btnCountinue_Click(object sender, EventArgs e)
        {
            frmSongAndPodcastPersonAdd frmSongAndPodcastPersonAdd = new frmSongAndPodcastPersonAdd(_sap);
            frmSongAndPodcastPersonAdd.MdiParent = frmHome.ActiveForm;
            frmSongAndPodcastPersonAdd.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSongAndPodcastAdd frmSongAndPodcastAdd = new frmSongAndPodcastAdd(_sap);
            frmSongAndPodcastAdd.MdiParent = frmHome.ActiveForm;
            frmSongAndPodcastAdd.Show();
        }


        private async void dgvSeasons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var item = dgvSeasons.SelectedRows[0].DataBoundItem;
                var S = await _SeasonService.Delete<PodcastSeason>((item as PodcastSeason).PodcastSeasonId);
                MessageBox.Show("Successfully deleted.");
                this.Hide();
                frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Deleting was not successful.");
                this.Hide();
                frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
        }


        private async void dgwEpisodes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var item = dgwEpisodes.SelectedRows[0].DataBoundItem as frmEpisodesVM;
                DialogResult result = MessageBox.Show("Do you want do delete this record?", "Warining", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var E = await _EpisodeService.Delete<PodcastSeasonEpisode>(item.Id);
                    MessageBox.Show("Successfully deleted.");
                    this.Hide();
                    frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                    frm.MdiParent = frmHome.ActiveForm;
                    frm.Show();
                }
                
            }
            catch
            {
                MessageBox.Show("Deleting was not successful.");
                this.Hide();
                frmSeasonEpisodeAdd frm = new frmSeasonEpisodeAdd(_sap);
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
        }

        private void dgwEpisodes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
