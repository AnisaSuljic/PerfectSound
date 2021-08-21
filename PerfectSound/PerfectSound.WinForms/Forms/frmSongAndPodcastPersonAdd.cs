using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Person;
using PerfectSound.Model.Requests.SongAndPodcastPerson;
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
    public partial class frmSongAndPodcastPersonAdd : Form
    {
        APIService _RoleService = new APIService("Role");
        APIService _GenderService = new APIService("Gender");
        APIService _PersonService = new APIService("Person");
        APIService _SongPodcastService = new APIService("SongAndPodcast");
        APIService _SongAndPodcastPersonService = new APIService("SongAndPodcastPerson");
        private SongAndPodcast _sap;
        int ArtistID;
        int SongPodcastID;
        int RoleID;

        public frmSongAndPodcastPersonAdd(SongAndPodcast sap=null)
        {
            InitializeComponent();
            dgwAllArtists.AutoGenerateColumns = false;
            dgwArtists.AutoGenerateColumns = false;
            _sap = sap;
            SongPodcastID = _sap.SongAndPodcastId;
        }

        private async void frmSongAndPodcastPersonAdd_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            txtSongPodcast.Text = _sap.Title;
            txtSongPodcast.ReadOnly = true;
            txtSongPodcast.Enabled = false;
            txtSearchSongPodcast.Text = _sap.Title;
            txtSearchSongPodcast.ReadOnly = true;
            txtSearchSongPodcast.Enabled = false;
        }

        private async Task LoadDataAsync()
        {
            await LoadRolesAsync();
            await LoadDGVSearchAsync();
            await LoadDGVAsync();
        }

        private async Task LoadDGVAsync(PersonSearchRequest searchArtist =null)
        {
            List <Person> listOfPersons= await _PersonService.GetAll<List<Person>>();
            if (searchArtist != null)
            {
                listOfPersons = listOfPersons.Where(p => p.FirstName.ToLower().StartsWith(searchArtist.FirstName.ToLower()) ||
                 p.LastName.ToLower().StartsWith(searchArtist.LastName.ToLower())).ToList();
            }

            List<frmPersonVM> vm = new List<frmPersonVM>();
            foreach (var item in listOfPersons)
            {
                frmPersonVM viewmodel = new frmPersonVM
                {
                    Id=item.PersonId,
                    FirstName=item.FirstName+" "+item.LastName,
                    LastName=item.LastName,
                    DateOfBirth=item.DateOfBirth.Value.ToString(),
                    Gender=_GenderService.GetById<Gender>(item.GenderId).ToString()                    
                };
                if (item.DateOfDeath == null)
                    viewmodel.Status = "Alive";
                else
                    viewmodel.Status = "Dead";

                vm.Add(viewmodel);
            }
            dgwArtists.DataSource = vm;
        }

        private async Task LoadDGVSearchAsync(SongAndPodcastPersonSearchRequest search=null)
        {
            List<SongAndPodcastPerson> list1 = new List<SongAndPodcastPerson>();
            List<SongAndPodcastPerson> list = new List<SongAndPodcastPerson>();
            if (search == null)
                list1= await _SongAndPodcastPersonService.GetAll<List<SongAndPodcastPerson>>();

            if (search != null)
                list1 = await _SongAndPodcastPersonService.GetAll<List<SongAndPodcastPerson>>(search);

            list = list1.Where(x => x.SongAndPodcastId == _sap.SongAndPodcastId).ToList();

            List<frmSongAndPodcastPersonVM> vm = new List<frmSongAndPodcastPersonVM>();
            foreach (var item in list)
            {
                Person _person = await _PersonService.GetById<Person>(item.PersonId);
                Role _role = await _RoleService.GetById<Role>(item.RoleId);
                SongAndPodcast _songpocast = await _SongPodcastService.GetById<SongAndPodcast>(item.SongAndPodcastId);
                frmSongAndPodcastPersonVM viewmodel = new frmSongAndPodcastPersonVM
                {
                    Id = item.SongAndPodcastPersonId,
                    Name =_person.FirstName+_person.LastName,
                    Role=_role.RoleName,
                    SongPodcast= _songpocast.Title
                };
                vm.Add(viewmodel);
            }
            dgwAllArtists.DataSource = vm;

        }

        private async Task LoadRolesAsync()
        {
            var RoleList = await _RoleService.GetAll<List<Role>>();
            var RoleList1 = await _RoleService.GetAll<List<Role>>();
           
            cbRoles.DataSource = RoleList;
            cbRoles.DisplayMember = "RoleName";
            cbRoles.ValueMember = "RoleId";

            RoleList1.Insert(0, new Role());
            cbSearchRoles.DataSource = RoleList1;
            cbSearchRoles.DisplayMember = "RoleName";
            cbSearchRoles.ValueMember = "RoleId";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            RoleID = (int)cbRoles.SelectedValue;

            if (this.ValidateChildren())
            {
                if (ErrorCheck())
                {
                    SongAndPodcastPersonUpsertRequest request = new SongAndPodcastPersonUpsertRequest
                    {
                        SongAndPodcastId=SongPodcastID,
                        PersonId=ArtistID,
                        RoleId=RoleID
                    };

                    try
                    {
                        await _SongAndPodcastPersonService.Insert<SongAndPodcastPerson>(request);
                        MessageBox.Show("Successfully added.");
                        frmSongAndPodcastPersonAdd frm = new frmSongAndPodcastPersonAdd(_sap);
                        frm.MdiParent = frmHome.ActiveForm;
                        frm.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Adding was not successfully. Please try again.");
                        frmSongAndPodcastPersonAdd frm = new frmSongAndPodcastPersonAdd(_sap);
                        frm.MdiParent = frmHome.ActiveForm;
                        frm.Show();
                    }
                }
            }
        }

        private bool ErrorCheck()
        {
            if (!ErrorHandler.RequiredFiled(txtArtist,ErrorSongAndPodcastPersonAdd)||
                !ErrorHandler.RequiredFiled(txtSongPodcast, ErrorSongAndPodcastPersonAdd) ||
                !ErrorHandler.RequiredFiled(cbRoles, ErrorSongAndPodcastPersonAdd))
                return false;
            return true;
        }

        private async void txtArtistName_KeyUp(object sender, KeyEventArgs e)
        {
            PersonSearchRequest search = new PersonSearchRequest();
            search.FirstName = txtArtistName.Text;
            search.LastName = txtArtistName.Text;
            await LoadDGVAsync(search);
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            frmPersonAdd frmPerAdd = new frmPersonAdd(null,_sap);
            frmPerAdd.MdiParent = frmHome.ActiveForm;
            frmPerAdd.Show();
        }
        private async void dgwArtists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var x = dgwArtists.SelectedRows[0].DataBoundItem;
            ArtistID = (x as frmPersonVM).Id;
            Person temp = await _PersonService.GetById<Person>(ArtistID);
            txtArtist.Text = temp.FirstName + " " + temp.LastName;
            txtArtist.ReadOnly = true;
            txtArtist.Enabled = false;
        }

        private async void cbSearchRoles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var _roleid = cbSearchRoles.SelectedValue;
            SongAndPodcastPersonSearchRequest search = new SongAndPodcastPersonSearchRequest();
            search.RoleId = (int)_roleid;
            await LoadDGVSearchAsync(search);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSeasonEpisodeAdd frmAddSeasonEpisode = new frmSeasonEpisodeAdd(_sap);
            frmAddSeasonEpisode.MdiParent = frmHome.ActiveForm;
            frmAddSeasonEpisode.Show();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            frmIndexHome frm = new frmIndexHome();
            frm.MdiParent = frmHome.ActiveForm;
            frm.Show();
        }

        
    }
}
