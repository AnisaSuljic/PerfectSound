using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.User;
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
    public partial class frmUserSearch : Form
    {
        APIService _UserTypeService = new APIService("UserType");
        APIService _UserService = new APIService("User");

        public frmUserSearch()
        {
            InitializeComponent();
            dgwUser.AutoGenerateColumns = false;

        }

        private async void frmUserSearch_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            await LoadDGV();
        }


        private async Task LoadDataAsync()
        {
            await LoadUserTypesAsync();
            await LoadDGV();
        }

        private async Task LoadUserTypesAsync()
        {
            var UserTypeList = await _UserTypeService.GetAll<List<UserType>>();
            UserTypeList.Insert(0, new UserType());
            cbUserType.DataSource = UserTypeList;
            cbUserType.DisplayMember = "Type";
            cbUserType.ValueMember = "UserTypeId";
        }
        private async Task LoadDGV(object search = null)
        {
            var list = await _UserService.GetAll<List<User>>(search);

            List<frmUserVM> vm = new List<frmUserVM>();
            foreach (var item in list)
            {
                string type = "Nepoznato";
                if (item.UserTypeId != null)
                {
                    var tr = await _UserTypeService.GetById<UserType>(item.UserTypeId);
                    type = tr.Type;
                }
                frmUserVM viewmodel = new frmUserVM
                {
                    Id = item.UserId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserName = item.UserName,
                    Phone = item.Phone,
                    Email = item.Email,
                    UserType = type,
                };

                vm.Add(viewmodel);
            }
            dgwUser.DataSource = vm;
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            UserSearchRequest SearchRequest = new UserSearchRequest();

            if ((int)cbUserType.SelectedValue != 0 || cbUserType != null)
                SearchRequest.UserTypeId = (int)cbUserType.SelectedValue;
            
            SearchRequest.UserName = txtUsernameSearch.Text;

            await LoadDGV(SearchRequest);
        }

        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtUsernameSearch.Text = "";
            await LoadDataAsync();
        }

        private async void dgwUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgwUser.SelectedRows[0].DataBoundItem;
            var U = await _UserService.GetById<User>((item as frmUserVM).Id);
            frmUserAdd frm = new frmUserAdd(U);
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }
    }
}
