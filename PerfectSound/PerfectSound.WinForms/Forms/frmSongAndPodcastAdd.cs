using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcast;
using PerfectSound.WinForms.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectSound.WinForms.Forms
{
    public partial class frmSongAndPodcastAdd : Form
    {
        APIService _GenreService = new APIService("Genre");
        APIService _ProductionCompanyService = new APIService("ProductionCompany");
        APIService _SongAndPodcastService = new APIService("SongAndPodcast");
        APIService _SongPodcastGenreService = new APIService("SongAndPodcastGenre");


        SongAndPodcastUpsertRequest _upsertRequest =new SongAndPodcastUpsertRequest();
        private SongAndPodcast _songpodcast;
        bool isChecked;
        bool isEdit;
        int GenreListOfID = 0;
        System.Byte[] file;
        public frmSongAndPodcastAdd(SongAndPodcast SAP=null)
        {
            InitializeComponent();
            if (SAP != null)
            {
                isEdit = true;
                _songpodcast = SAP;
                btnSaveSongPodcast.Text = "Update";
                clbGenre.Enabled = false;
                file = _songpodcast.Poster;
                podcastBtn.Enabled = false;

                btnBack.Visible = true;
                if (SAP.IsPodcast == true)
                    btnSeasonEpisodeSetting.Visible = true;
                else
                    btnSeasonEpisodeSetting.Visible = false;

            }
            else
            {
                isEdit = false;
                btnBack.Visible = false;
            }
        }
        private async void SongAndPodcastAdd_LoadAsync(object sender, EventArgs e)
        {
            if(isEdit==false)
            {
                isChecked = false;
                podcastBtn.Checked = false;
                await LoadGenersAsync();
                await LoadProdCompanyAsync();
            }
            else
            {
                await LoadGenersAsync();
                await LoadProdCompanyAsync();
                txtTitle.Text = _songpodcast.Title;
                txtBudget.Text = _songpodcast.Budget.ToString();
                dtpReleaseDate.Value = _songpodcast.ReleaseDate.Value;
                txtRunningTime.Text = _songpodcast.RunningTime;
                cbProdCompany.SelectedValue = (int)_songpodcast.ProductionCompanyId;

                if (_songpodcast.Poster != null && _songpodcast.Poster.Length > 15)
                {
                    pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbPoster.Image = Helper.ImageConverterFunction.FromByteToImage(_songpodcast.Poster);
                }
                podcastBtn.Checked = _songpodcast.IsPodcast.Value;
                if(podcastBtn.Checked)
                {
                    txtRunningTime.Enabled = false;
                    richtxtSong.Enabled = false;
                }
                richtxtSong.Text = _songpodcast.Text;

            }
        }

        private async Task LoadProdCompanyAsync()
        {
            var prodCompList = await _ProductionCompanyService.GetAll<List<ProductionCompany>>();
            cbProdCompany.DataSource = prodCompList;
            cbProdCompany.DisplayMember = "ProductionCompanyName";
            cbProdCompany.ValueMember = "ProductionCompanyId";
        }

        public async Task LoadGenersAsync()
        {
            var genreList = await _GenreService.GetAll<List<Genre>>();
            clbGenre.DataSource = genreList;
            clbGenre.DisplayMember = "GenreName";
            clbGenre.ValueMember = "GenreId";
            
        }
        private void podcastBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (podcastBtn.Checked && !isChecked)
            {
                podcastBtn.Checked = true;
                txtRunningTime.Enabled = false;
                txtRunningTime.Text = "";
                richtxtSong.Enabled = false;
                richtxtSong.Text = "";
                isChecked = true;
            }
            else
            {
                podcastBtn.Checked = false;
                isChecked = false;
                txtRunningTime.Enabled = true;
                richtxtSong.Enabled = true;
            }
        }
        private List<int> GenreListCount()
        {
            var genreList = clbGenre.CheckedItems.Cast<Genre>();
            var genreIdList = genreList.Select(x => x.GenreId).ToList();
            return genreIdList;
        }

        private async void btnSaveSongPodcast_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var genreIdList = GenreListCount();

                if (podcastBtn.Checked == false)//pjesma je
                {
                    if (isEdit == false)//dodavanje pjesme
                    {
                        if (ErrorCheck(isEdit))//provjera required fields
                        {
                            _upsertRequest.Title = txtTitle.Text;
                            _upsertRequest.Text = richtxtSong.Text;
                            _upsertRequest.RunningTime = txtRunningTime.Text;
                            _upsertRequest.ReleaseDate = dtpReleaseDate.Value;
                            if (txtBudget.Text == "")
                                txtBudget.Text = "0";
                            _upsertRequest.Budget = decimal.Parse(txtBudget.Text);
                            _upsertRequest.Poster = file;
                            _upsertRequest.GenreIDList = genreIdList;
                            _upsertRequest.ProductionCompanyId = Convert.ToInt32(cbProdCompany.SelectedValue);
                            _upsertRequest.IsPodcast = false;
                            try
                            {
                                await _SongAndPodcastService.Insert<SongAndPodcast>(_upsertRequest);
                                MessageBox.Show("Successfully added.");

                                SongAndPodcast obj = await _SongAndPodcastService.GetById<SongAndPodcast>(_songpodcast.SongAndPodcastId);

                                frmSeasonEpisodeAdd frmAddSeasonEpisode = new frmSeasonEpisodeAdd(obj);
                                frmAddSeasonEpisode.MdiParent = frmHome.ActiveForm;
                                frmAddSeasonEpisode.Show();
                            }
                            catch
                            {
                                MessageBox.Show("Adding was not successfully. Please try again.");
                                frmSongAndPodcastAdd frm = new frmSongAndPodcastAdd();
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                        }
                    }
                    else//uredjivanje pjesme
                    {
                        if (ErrorCheck(isEdit))//provjera required fields
                        {
                            _upsertRequest.Title = txtTitle.Text;
                            _upsertRequest.Text = richtxtSong.Text;
                            _upsertRequest.RunningTime = txtRunningTime.Text;
                            _upsertRequest.ReleaseDate = dtpReleaseDate.Value;
                            if (txtBudget.Text == "")
                                txtBudget.Text = "0";
                            _upsertRequest.Budget = decimal.Parse(txtBudget.Text);
                            _upsertRequest.Poster = file;
                            _upsertRequest.ProductionCompanyId = Convert.ToInt32(cbProdCompany.SelectedValue);
                            _upsertRequest.IsPodcast = false;

                            try
                            {
                                await _SongAndPodcastService.Update<SongAndPodcast>(_songpodcast.SongAndPodcastId,_upsertRequest);
                                MessageBox.Show("Successfully updated.");

                                SongAndPodcast obj = await _SongAndPodcastService.GetById<SongAndPodcast>(_songpodcast.SongAndPodcastId);

                                frmSongAndPodcastAdd frm = new frmSongAndPodcastAdd(obj);
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                            catch
                            {
                                MessageBox.Show("Update was not successfully. Please try again.");
                                frmSongAndPodcastAdd frm = new frmSongAndPodcastAdd(_songpodcast);
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                        }
                    }
                }
                else//podcast je
                {
                    if (isEdit == false)//dodavanje pocasta
                    {
                        if (ErrorCheck(isEdit))//provjera required fields
                        {
                            _upsertRequest.Title = txtTitle.Text;
                            _upsertRequest.ReleaseDate = dtpReleaseDate.Value;
                            if (txtBudget.Text == "")
                                txtBudget.Text = "0";
                            _upsertRequest.Budget = decimal.Parse(txtBudget.Text);
                            _upsertRequest.Poster = file;
                            _upsertRequest.GenreIDList = genreIdList;
                            _upsertRequest.ProductionCompanyId = Convert.ToInt32(cbProdCompany.SelectedValue);
                            _upsertRequest.IsPodcast = true;
                            try
                            {
                                await _SongAndPodcastService.Insert<SongAndPodcast>(_upsertRequest);
                                MessageBox.Show("Successfully added.");

                                List<SongAndPodcast> allpodcasts = await _SongAndPodcastService.GetAll<List<SongAndPodcast>>();
                                var id = allpodcasts[allpodcasts.Count-1].SongAndPodcastId;
                                var obj= await _SongAndPodcastService.GetById<SongAndPodcast>(id);

                                frmSeasonEpisodeAdd frmAddSeasonEpisode = new frmSeasonEpisodeAdd(obj);
                                frmAddSeasonEpisode.MdiParent = frmHome.ActiveForm;
                                frmAddSeasonEpisode.Show();
                            }
                            catch
                            {
                                MessageBox.Show("Adding was not successfully. Please try again.");
                                frmSongAndPodcastAdd frm = new frmSongAndPodcastAdd(_songpodcast);
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                        }
                    }
                    else//uredjivanje podcasta
                    {
                        if (ErrorCheck(isEdit))//provjera required fields
                        {
                            _upsertRequest.Title = txtTitle.Text;
                            _upsertRequest.ReleaseDate = dtpReleaseDate.Value;
                            if (txtBudget.Text == "")
                                txtBudget.Text = "0";
                            _upsertRequest.Budget = decimal.Parse(txtBudget.Text);
                            _upsertRequest.Poster = file;
                            _upsertRequest.ProductionCompanyId = Convert.ToInt32(cbProdCompany.SelectedValue);
                            _upsertRequest.IsPodcast = true;

                            try
                            {
                                await _SongAndPodcastService.Update<SongAndPodcast>(_songpodcast.SongAndPodcastId, _upsertRequest);
                                MessageBox.Show("Successfully updated.");

                                SongAndPodcast obj = await _SongAndPodcastService.GetById<SongAndPodcast>(_songpodcast.SongAndPodcastId);

                                frmSongAndPodcastAdd frm = new frmSongAndPodcastAdd(obj);
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                            catch
                            {
                                MessageBox.Show("Update was not successfully. Please try again.");
                                frmSongAndPodcastAdd frm = new frmSongAndPodcastAdd(_songpodcast);
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                        }
                    }
                }
               
                
            }

        }

        private void btnAddPoster_Click(object sender, EventArgs e)
        {
            var result = ofdOpenPoster.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = ofdOpenPoster.FileName;
                file = File.ReadAllBytes(fileName);

                Image img = Image.FromFile(fileName);
                pbPoster.Image = img;
                pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private bool ErrorCheck(bool edit)
        {
            if(edit!=true)
            {
                if (!ErrorHandler.RequiredFiled(pbPoster, ErrorSoundAndPodcastAdd) ||
                !ErrorHandler.RequiredFiled(txtTitle, ErrorSoundAndPodcastAdd))
                    return false;
                if (isChecked != true || podcastBtn.Checked==false)
                {
                    if (!ErrorHandler.RequiredFiled(txtRunningTime, ErrorSoundAndPodcastAdd) ||
                        !ErrorHandler.CheckFormatOfRunningTime(txtRunningTime, ErrorSoundAndPodcastAdd, ErrorHandler.FormatChecker) ||
                        !ErrorHandler.RequiredFiled(richtxtSong, ErrorSoundAndPodcastAdd))
                        return false;
                }
                GenreListOfID = GenreListCount().Count;
                if (GenreListOfID == 0)
                {
                    if (!ErrorHandler.RequiredFiled(clbGenre, ErrorSoundAndPodcastAdd, ErrorHandler.CheckedListBoxfield))
                        return false;
                }
            }
            else
            {
                if (!ErrorHandler.RequiredFiled(pbPoster, ErrorSoundAndPodcastAdd) ||
                !ErrorHandler.RequiredFiled(txtTitle, ErrorSoundAndPodcastAdd))
                    return false;
            }
            return true;
            
        }
        private void btnSeasonEpisodeSetting_Click(object sender, EventArgs e)
        {
            frmSeasonEpisodeAdd frmAddSeasonEpisode = new frmSeasonEpisodeAdd(_songpodcast);
            frmAddSeasonEpisode.MdiParent = frmHome.ActiveForm;
            frmAddSeasonEpisode.Show();
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            frmSongAndPodcastPersonAdd frmSongAndPodcastPerson = new frmSongAndPodcastPersonAdd(_songpodcast);
            frmSongAndPodcastPerson.MdiParent = frmHome.ActiveForm;
            frmSongAndPodcastPerson.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHome.isPodcastOrSong.isPodcast = (bool)_songpodcast.IsPodcast;
            frmSongAndPodcastSearch frm = new frmSongAndPodcastSearch();
            frm.MdiParent = frmHome.ActiveForm;
            frm.Show();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var SAP = await _SongAndPodcastService.Delete<SongAndPodcast>(_songpodcast.SongAndPodcastId);
                MessageBox.Show("Successfully deleted.");
                this.Hide();
                frmSongAndPodcastSearch frm = new frmSongAndPodcastSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Deleting was not successful.");
                this.Hide();
                frmSongAndPodcastSearch frm = new frmSongAndPodcastSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
        }
    }
}
