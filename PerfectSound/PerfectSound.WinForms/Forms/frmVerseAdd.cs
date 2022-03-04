using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.Quote;
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
    public partial class frmVerseAdd : Form
    {
        APIService _SAPService = new APIService("SongAndPodcast");
        APIService _QuoteService = new APIService("Quote");

        public frmVerseAdd()
        {
            InitializeComponent();
        }

        private async void frmVerseAdd_Load(object sender, EventArgs e)
        {
            await LoadSAPAsync();
        }

        private async Task LoadSAPAsync()
        {
            var saplist = await _SAPService.GetAll<List<SongAndPodcast>>();
            comboBoxSAPforVerse.DataSource = saplist;
            comboBoxSAPforVerse.ValueMember = "SongAndPodcastId";
        }
        private void comboBoxSAPforVerse_Format(object sender, ListControlConvertEventArgs e)
        {
            string title = ((SongAndPodcast)e.ListItem).Title;
            string firstname = ((SongAndPodcast)e.ListItem).FirstName;
            string lastname = ((SongAndPodcast)e.ListItem).LastName;

            e.Value = title +" - "+firstname + " " + lastname;
        }
        private async void btnSaveVerse_Click(object sender, EventArgs e)
        {
            if (ErrorHandler.RequiredFiled(txtVerse, errorProvider1))
            {
                QuoteUpsertRequest newQuote = new QuoteUpsertRequest()
                {
                    SongAndPodcastId = Convert.ToInt32(comboBoxSAPforVerse.SelectedValue),
                    QuoteText = txtVerse.Text
                };
                try
                {
                    await _QuoteService.Insert<Quote>(newQuote);
                    MessageBox.Show("Successfully added.");
                    ActiveForm.Close();
                }
                catch
                {
                    MessageBox.Show("Adding was not successfully. Please try again.");
                    ActiveForm.Close();
                    frmVerseAdd frmverse = new frmVerseAdd();
                    frmverse.Show();
                }
            }
        }

    }
}
