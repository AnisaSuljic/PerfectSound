using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.News;
using PerfectSound.Model.Requests.User;
using PerfectSound.Model.ViewModels;
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
    public partial class frmNewsAdd : Form
    {
        APIService _NewsService = new APIService("News");
        APIService _UserService = new APIService("User");
        NewsUpsertRequest _upsertRequest = new NewsUpsertRequest();

        System.Byte[] file;
        bool isEdit;
        private News _news;
        public frmNewsAdd(News N=null)
        {
            InitializeComponent();
            if (N != null)
            {
                isEdit = true;
                _news = N;
                btnSaveNews.Text = "Update";
                btnDelete.Visible = true;
            }
            else
            {
                isEdit = false;
            }
        }
        private void frmNewsAdd_Load(object sender, EventArgs e)
        {
            if (isEdit == true)
                LoadUserData();
        }

        private void LoadUserData()
        {
            txtTitleNews.Text = _news.Title;
            txtSubTitleNews.Text = _news.SubTitle;
            txtContent.Text = _news.Content;
            dtpPublication.Value = _news.PublicationDate.Value;
            if (_news.CoverPhoto != null && _news.CoverPhoto.Length > 15)
            {
                pbNewsPoster.SizeMode = PictureBoxSizeMode.StretchImage;
                pbNewsPoster.Image = Helper.ImageConverterFunction.FromByteToImage(_news.CoverPhoto);
            }
        }

        private async void btnSaveNews_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (ErrorCheck() == true)
                {
                    var x = await _UserService.GetAll<List<User>>(new UserSearchRequest
                    {
                        UserName=APIService.username
                    });
                    _upsertRequest.UserId = x.FirstOrDefault().UserId;

                    _upsertRequest.Title = txtTitleNews.Text;
                    _upsertRequest.SubTitle = txtSubTitleNews.Text;
                    _upsertRequest.PublicationDate = dtpPublication.Value;
                    _upsertRequest.Content = txtContent.Text;
                    _upsertRequest.CoverPhoto = file;
                    try
                    {
                        if (isEdit == false)
                        {
                            if (await _NewsService.Insert<News>(_upsertRequest) == default(News))
                                return;
                            else
                            {
                                MessageBox.Show("Successfully added.");
                                DialogResult = DialogResult.OK;
                                Close();
                                frmNewsSearch frm = new frmNewsSearch();
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                        }
                        else
                        {
                            if (await _NewsService.Update<News>(_news.NewsId, _upsertRequest)== default(News))
                                return;
                            else
                            {
                                MessageBox.Show("Successfully updated.");
                                DialogResult = DialogResult.OK;
                                Close();
                                frmNewsSearch frm = new frmNewsSearch();
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                        }


                    }
                    catch
                    {
                        if (isEdit == false)
                        {
                            MessageBox.Show("Adding was not successfully. Please try again.");
                            DialogResult = DialogResult.OK;
                            Close();
                            frmNewsSearch frm = new frmNewsSearch();
                            frm.MdiParent = frmHome.ActiveForm;
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Editing was not successfully. Please try again.");
                            DialogResult = DialogResult.OK;
                            Close();
                            frmNewsSearch frm = new frmNewsSearch();
                            frm.MdiParent = frmHome.ActiveForm;
                            frm.Show();
                        }
                    }
                }
            }
        }
        private bool ErrorCheck()
        {
            if (!ErrorHandler.RequiredFiled(pbNewsPoster, errorNews) ||
                !ErrorHandler.RequiredFiled(txtTitleNews, errorNews) ||
                !ErrorHandler.RequiredFiled(txtSubTitleNews, errorNews) ||
                !ErrorHandler.RequiredFiled(txtContent, errorNews))
                return false;

            return true;
        }

        private void btnAddNewsPoster_Click(object sender, EventArgs e)
        {
            var result = coverPhoto.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = coverPhoto.FileName;
                file = File.ReadAllBytes(fileName);

                Image img = Image.FromFile(fileName);
                pbNewsPoster.Image = img;
                pbNewsPoster.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var N = await _NewsService.Delete<News>(_news.NewsId);
                MessageBox.Show("Successfully deleted.");
                this.Hide();
                frmNewsSearch frm = new frmNewsSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Deleting was not successful.");
                this.Hide();
                frmNewsSearch frm = new frmNewsSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
            
        }
    }
}
