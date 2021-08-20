using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.News;
using PerfectSound.Model.ViewModels;
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
    public partial class frmNewsSearch : Form
    {
        APIService _NewsService = new APIService("News");
        NewsSearchRequest _upsertRequest = new NewsSearchRequest();

        private News _news;
        public frmNewsSearch()
        {
            InitializeComponent();
            dgwData.AutoGenerateColumns = false;
        }

        private async void frmNewsSearch_Load(object sender, EventArgs e)
        {
            await LoadDGVdata();
            dtpPublicationDateSearch.Checked = false;
            dtpPublicationDateSearch.Enabled = false;
        }

        private async Task LoadDGVdata(object search = null)
        {
            var list = await _NewsService.GetAll<List<News>>(search);

            List<frmNewsVM> vm = new List<frmNewsVM>();
            foreach (var item in list)
            {
                frmNewsVM viewmodel = new frmNewsVM
                {
                    Id=item.NewsId,
                    Title = item.Title,
                    SubTitle=item.SubTitle,
                    PublicationDate = item.PublicationDate.Value.ToString("dd.MM.yyyy."),
                };
                vm.Add(viewmodel);
            }
            dgwData.DataSource = vm;
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
                dtpPublicationDateSearch.Enabled = false;
            }
            else
            {
                radioBtnUkljuciDatum.Checked = true;
                dtpPublicationDateSearch.Enabled = true;
                isChecked = false;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            NewsSearchRequest SearchRequest = new NewsSearchRequest();
          
            if (dtpPublicationDateSearch.Enabled == true)
                SearchRequest.PublicationDate = dtpPublicationDateSearch.Value;
            SearchRequest.Title = txtTitleSearch.Text;

            await LoadDGVdata(SearchRequest);
        }

        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            dtpPublicationDateSearch.Value = DateTime.Today;
            radioBtnUkljuciDatum.Checked = false;
            dtpPublicationDateSearch.Enabled = false;
            await LoadDGVdata();
        }


        private async void dgwData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgwData.SelectedRows[0].DataBoundItem;
            var N = await _NewsService.GetById<News>((item as frmNewsVM).Id);
            frmNewsAdd frm = new frmNewsAdd(N);
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }
    }
}
