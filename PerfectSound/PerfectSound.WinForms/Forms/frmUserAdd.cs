using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.User;
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
    public partial class frmUserAdd : Form
    {

        APIService _UserService = new APIService("User");
        APIService _UserTypeService = new APIService("UserType");

        private User _user;
        bool isEdit;

        public frmUserAdd(User user=null)
        {
            InitializeComponent();
            if (user != null)
            {
                _user = user;
                isEdit = true;
                btnAddUser.Text = "Update";
                btnDelete.Visible = true;

            }
            else
                isEdit = false;
        }
        private async void frmUserAdd_Load(object sender, EventArgs e)
        {
            await LoadUserTypesAsync();
            if (isEdit == true)
                LoadUserData();
        }

        private void LoadUserData()
        {
            txtFirstName.Text = _user.FirstName;
            txtLastname.Text = _user.LastName;
            txtUsername.Text = _user.UserName;
            txtEmail.Text = _user.Email;
            txtPhone.Text = _user.Phone;
            txtPassword.Enabled = false;
            checkPassword.Enabled = false;
            txtPasswordConfirm.Enabled = false;
            checkPasswordConfirm.Enabled = false;
            lblGeneratePass.Visible = false;
            cbUserType.SelectedValue = _user.UserTypeId;
        }

        private async Task LoadUserTypesAsync()
        {
            var UserTypeList = await _UserTypeService.GetAll<List<UserType>>();
            cbUserType.DataSource = UserTypeList;
            cbUserType.DisplayMember = "Type";
            cbUserType.ValueMember = "UserTypeId";
        }
        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (ErrorCheck())
                {
                    UserUpsertRequest request = new UserUpsertRequest
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastname.Text,
                        UserName = txtUsername.Text,
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                        PasswordConfirm = txtPasswordConfirm.Text,
                        Phone = txtPhone.Text
                    };

                    var idType = cbUserType.SelectedValue;

                    if (int.TryParse(idType.ToString(), out int typeId))
                    {
                        request.UserTypeId = typeId;
                    }

                    try
                    {
                        if (isEdit == false)
                        {
                            await _UserService.Insert<User>(request);
                            MessageBox.Show("Successfully added.");
                            DialogResult = DialogResult.OK;
                            Close();
                            frmUserSearch frm = new frmUserSearch();
                            frm.MdiParent = frmHome.ActiveForm;
                            frm.Show();
                        }
                        else
                        {
                            await _UserService.Update<User>(_user.UserId, request);
                            MessageBox.Show("Successfully updated.");
                            DialogResult = DialogResult.OK;
                            Close();
                            frmUserSearch frm = new frmUserSearch();
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
        private bool ErrorCheck()
        {
            if (!ErrorHandler.RequiredFiled(txtFirstName, errorUser) ||
                !ErrorHandler.RequiredFiled(txtLastname, errorUser)||
                !ErrorHandler.RequiredFiled(txtUsername, errorUser) || 
                !ErrorHandler.RequiredFiled(txtEmail, errorUser) ||
                !ErrorHandler.CheckFormatOfEmail(txtEmail,errorUser, ErrorHandler.FormatChecker) ||
                !ErrorHandler.RequiredFiled(txtPhone, errorUser))
                return false;
            if (isEdit != true)
            {
                if (!ErrorHandler.RequiredFiled(txtEmail, errorUser) ||
                    !ErrorHandler.CheckFormatOfEmail(txtEmail, errorUser,ErrorHandler.FormatChecker) ||
                    !ErrorHandler.RequiredFiled(txtPassword, errorUser) ||                    
                    !ErrorHandler.RequiredFiled(txtPasswordConfirm, errorUser)||
                !ErrorHandler.CheckIfPassEqual(txtPassword,txtPasswordConfirm,errorUser,ErrorHandler.FormatChecker))
                    return false;
            }
            return true;
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPassword.Checked)          
                txtPassword.PasswordChar = '\0';            
            else
                txtPassword.PasswordChar = '*';
            
        }

        private void checkPasswordConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPasswordConfirm.Checked)            
                txtPasswordConfirm.PasswordChar = '\0';            
            else            
                txtPasswordConfirm.PasswordChar = '*';            
        }

        private void lblGeneratePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var guid = Guid.NewGuid().ToString().Substring(0, 8);
            txtPassword.Text = guid;
            txtPasswordConfirm.Text = guid;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var U = await _UserService.Delete<User>(_user.UserId);
                MessageBox.Show("Successfully deleted.");
                this.Hide();
                frmUserSearch frm = new frmUserSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("Deleting was not successful.");
                this.Hide();
                frmUserSearch frm = new frmUserSearch();
                frm.MdiParent = frmHome.ActiveForm;
                frm.Show();
            }
        }
    }
}
