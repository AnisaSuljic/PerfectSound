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
                var result =await _UserService.GetAll<dynamic>();
                this.Hide();
                frmHome frm = new frmHome();
                frm.Show();
            }
            catch 
            {
                lblError.Text = "Incorrect username or password.";
                txtUsername.Clear();
                txtPassword.Clear();
                //MessageBox.Show("Incorrect username or password.");
            }
        }

        
    }
}
