using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Person;
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
    public partial class frmPersonSearch : Form
    {
        APIService _GenderService = new APIService("Gender");
        APIService _PersonService = new APIService("Person");

        public frmPersonSearch()
        {
            InitializeComponent();
            dgwPersonData.AutoGenerateColumns = false;
        }

        private async void frmPersonSearch_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await LoadGenderAsync();
            await LoadDGVData();
        }
        private async Task LoadGenderAsync()
        {
            var genderList = await _GenderService.GetAll<List<Gender>>();
            cbGenderSearch.DataSource = genderList;
            cbGenderSearch.DisplayMember = "GenderName";
            cbGenderSearch.ValueMember = "GenderId";
        }
        private async Task LoadDGVData(object search = null)
        {
            var list = await _PersonService.GetAll<List<Person>>(search);

            List<frmPersonVM> vm = new List<frmPersonVM>();

            foreach (var item in list)
            {
                frmPersonVM viewmodel = new frmPersonVM
                {
                    Id = item.PersonId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    DateOfBirth = item.DateOfBirth.Value.ToString("dd.MM.yyyy."),
                    Gender = item.Gender.GenderName
                };

                if (item.DateOfDeath == null)
                    viewmodel.Status = "Alive";
                else
                    viewmodel.Status = "Dead";

                vm.Add(viewmodel);
            }
            dgwPersonData.DataSource = vm;
        }

        private async void dgwPersonData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgwPersonData.SelectedRows[0].DataBoundItem;
            var P = await _PersonService.GetById<Person>((item as frmPersonVM).Id);
            frmPersonAdd frm = new frmPersonAdd(P);
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            PersonSearchRequest SearchRequest = new PersonSearchRequest();

            if ((int)cbGenderSearch.SelectedValue != 0 || cbGenderSearch != null)
                SearchRequest.GenderId = (int)cbGenderSearch.SelectedValue;
            
            SearchRequest.FirstName = txtFirstnameSearch.Text;
            SearchRequest.LastName = txtLastnameSearch.Text;

            await LoadDGVData(SearchRequest);
        }

        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFirstnameSearch.Text = "";
            txtLastnameSearch.Text = "";
            await LoadDataAsync();
        }
    }
}
