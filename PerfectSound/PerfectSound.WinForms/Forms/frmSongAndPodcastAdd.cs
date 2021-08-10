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
            }
            else
                isEdit = false;
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

                if (ErrorCheck()==true)
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

                    if (podcastBtn.Checked == true)
                        _upsertRequest.IsPodcast = true;
                    else
                        _upsertRequest.IsPodcast = false;
                    try
                    {
                        if (isEdit == false)
                        {
                            await _SongAndPodcastService.Insert<SongAndPodcast>(_upsertRequest);
                            MessageBox.Show("Successfully added.");
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            await _SongAndPodcastService.Update<SongAndPodcast>(_songpodcast.SongAndPodcastId, _upsertRequest);
                            MessageBox.Show("Successfully updated.");
                            DialogResult = DialogResult.OK;
                            Close();
                        }

                    }
                    catch
                    {
                        if (isEdit == false)
                        {
                            MessageBox.Show("Adding was not successfully. Please try again.");
                        }
                        else
                        {
                            MessageBox.Show("Editing was not successfully. Please try again.");
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
        private bool ErrorCheck()
        {
            if (!ErrorHandler.RequiredFiled(pbPoster, ErrorSoundAndPodcastAdd) ||
                !ErrorHandler.RequiredFiled(txtTitle, ErrorSoundAndPodcastAdd))
                return false;
            if (isChecked != true)
            {
                if (!ErrorHandler.RequiredFiled(txtRunningTime, ErrorSoundAndPodcastAdd)||
                    !ErrorHandler.CheckFormatOfRunningTime(txtRunningTime,ErrorSoundAndPodcastAdd,ErrorHandler.FormatChecker)||
                    !ErrorHandler.RequiredFiled(richtxtSong, ErrorSoundAndPodcastAdd))
                    return false;
            }
            GenreListOfID = GenreListCount().Count;
            if (GenreListOfID == 0)
            {
                if (!ErrorHandler.RequiredFiled(clbGenre, ErrorSoundAndPodcastAdd, ErrorHandler.CheckedListBoxfield))
                    return false;
            }
            return true;
            
        }

    }
}
