using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Person;
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
    public partial class frmPersonAdd : Form
    {
        APIService _GenderService = new APIService("Gender");
        APIService _PersonService = new APIService("Person");
        PersonUpsertRequest _upsertRequest = new PersonUpsertRequest();

        System.Byte[] file;
        bool isEdit;
        private Person _person;
        SongAndPodcast _frm;

        public frmPersonAdd(Person P=null, SongAndPodcast frm =null)
        {

            InitializeComponent();
            if (P != null)
            {
                isEdit = true;
                _person = P;
                btnAddPerson.Text = "Update";
                btnDelete.Visible = true;
            }
            else
            {
                isEdit = false;
                dtpDateOfDeath.Enabled = false;
                Radiodeath.Checked = false;
            }
            if(frm!=null)
            {
                _frm = frm;
            }
        }

        private async void frmPersonAdd_Load(object sender, EventArgs e)
        {
            await LoadGenderAsync();
            if (isEdit == true)
                LoadPersonData();
            
        }

        private void LoadPersonData()
        {
            txtFirstName.Text = _person.FirstName;
            txtLastName.Text = _person.LastName;
            txtPlaceOfBirth.Text = _person.PlaceOfBirth;
            richtxtBiography.Text = _person.Biography;
            dtpDateOfBirth.Value = _person.DateOfBirth.Value;
            richtxtBiography.Text = _person.Biography;
            if (_person.DateOfDeath == null)
            {
                dtpDateOfDeath.Enabled = false;
                Radiodeath.Checked = false;
            }
            else
            {
                dtpDateOfDeath.Enabled = true;
                Radiodeath.Checked = true;
            }
            cbGender.SelectedValue = _person.GenderId.Value;
            if (_person.Photo != null && _person.Photo.Length > 15)
            {
                pbProfilePic.SizeMode = PictureBoxSizeMode.StretchImage;
                pbProfilePic.Image = Helper.ImageConverterFunction.FromByteToImage(_person.Photo);
            }
        }

        private async Task LoadGenderAsync()
        {
            var genderList = await _GenderService.GetAll<List<Gender>>();

            cbGender.DataSource = genderList;
            cbGender.DisplayMember = "GenderName";
            cbGender.ValueMember = "GenderId";
        }
        private async void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (ErrorCheck() == true)
                {
                    _upsertRequest.FirstName = txtFirstName.Text;
                    _upsertRequest.LastName = txtLastName.Text;
                    _upsertRequest.DateOfBirth = dtpDateOfBirth.Value;
                    _upsertRequest.PlaceOfBirth = txtPlaceOfBirth.Text;
                    _upsertRequest.Photo = file;
                    if (Radiodeath.Checked)
                        _upsertRequest.DateOfDeath = dtpDateOfDeath.Value;
                    _upsertRequest.GenderId = Convert.ToInt32(cbGender.SelectedValue);
                    _upsertRequest.Biography = richtxtBiography.Text;
                    try
                    {
                        if (isEdit == false)
                        {
                            await _PersonService.Insert<Person>(_upsertRequest);
                            MessageBox.Show("Successfully added.");                        
                            if (_frm == null)
                            {
                                frmPersonSearch frm = new frmPersonSearch();
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                            else
                            {
                                frmSongAndPodcastPersonAdd frm = new frmSongAndPodcastPersonAdd(_frm);
                                frm.MdiParent = frmHome.ActiveForm;
                                frm.Show();
                            }
                        }
                        else
                        {
                            await _PersonService.Update<Person>(_person.PersonId, _upsertRequest);
                            MessageBox.Show("Successfully updated.");
                            DialogResult = DialogResult.OK;
                            Close();
                            frmPersonSearch frm = new frmPersonSearch();
                            frm.MdiParent = frmHome.ActiveForm;
                            frm.Show();
                            
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

        private void btnAddProfilePic_Click(object sender, EventArgs e)
        {
            var result = ofdProfilPhoto.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = ofdProfilPhoto.FileName;
                file = File.ReadAllBytes(fileName);

                Image img = Image.FromFile(fileName);
                pbProfilePic.Image = img;
                pbProfilePic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        
        private bool ErrorCheck()
        {
            if (!ErrorHandler.RequiredFiled(pbProfilePic, errorPerson) ||
                !ErrorHandler.RequiredFiled(txtFirstName, errorPerson) ||
                !ErrorHandler.RequiredFiled(txtLastName, errorPerson) ||
                !ErrorHandler.RequiredFiled(txtPlaceOfBirth, errorPerson) ||
                !ErrorHandler.RequiredFiled(richtxtBiography, errorPerson)||
                !ErrorHandler.RequiredFiled(cbGender, errorPerson))
                return false;
           
            return true;
        }

        bool isChecked = false;
        private void Radiodeath_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = Radiodeath.Checked;            
        }
        private void Radiodeath_MouseClick(object sender, MouseEventArgs e)
        {
            if (Radiodeath.Checked && !isChecked)
            {
                Radiodeath.Checked = false;
                dtpDateOfDeath.Enabled = false;
            }
            else
            {
                Radiodeath.Checked = true;
                dtpDateOfDeath.Enabled = true;
                isChecked = false;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var P = await _PersonService.Delete<Person>(_person.PersonId);
                MessageBox.Show("Successfully deleted.");
                this.Hide();
                frmPersonSearch frm = new frmPersonSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Deleting was not successful.");
                this.Hide();
                frmPersonSearch frm = new frmPersonSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
        }
    }
}
