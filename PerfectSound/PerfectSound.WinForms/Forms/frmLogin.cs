using PerfectSound.Model.Model;
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
    public partial class frmLogin : Form
    {
        private readonly APIService _UserService = new APIService("User");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            APIService.username = txtUsername.Text;
            APIService.password = txtPassword.Text;

            try
            {
                var result = await _UserService.Login<Model.Model.User>();
                APIService.UserID = result.UserId;

                if (result.UserTypeId == 1)
                {
                    this.Hide();
                    frmHome frm = new frmHome();
                    frm.Show();
                }
                else
                {
                    lblError.Text = "Incorrect username or password.";
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                
            }
            catch 
            {
                lblError.Text = "Incorrect username or password.";
                txtUsername.Clear();
                txtPassword.Clear();
            }
            
        }

        
    }
}
