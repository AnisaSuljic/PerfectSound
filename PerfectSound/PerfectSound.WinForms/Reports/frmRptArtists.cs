using Microsoft.Reporting.WinForms;
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

namespace PerfectSound.WinForms.Reports
{
    public partial class frmRptArtists : Form
    {
        APIService _GenderService = new APIService("Gender");
        private List<frmPersonVM> _source;
        private PersonSearchRequest _filters;
        public frmRptArtists(List<frmPersonVM> source, PersonSearchRequest filters)
        {
            InitializeComponent();
            _source = source;
            _filters = filters;
        }

        private async void frmRptArtists_Load(object sender, EventArgs e)
        {
            Gender gender;
            string firstname = "//";
            string lastname = "//";
            string gendervalue = "//";
            if (_filters != null)
            {
                if (_filters.GenderId != 0)
                {
                    gender = await _GenderService.GetById<Gender>(_filters.GenderId);
                    gendervalue = gender.GenderName;
                }
                if (_filters.FirstName != null && _filters.FirstName!="")
                    firstname = _filters.FirstName;
                if (_filters.LastName != null && _filters.LastName != "")
                    lastname = _filters.LastName;
            }
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("DateOfReport", DateTime.Now.ToString()));
            rpc.Add(new ReportParameter("firstname", firstname));
            rpc.Add(new ReportParameter("lastname", lastname));
            rpc.Add(new ReportParameter("gender", gendervalue));
            rpc.Add(new ReportParameter("ReportCount", _source.Count.ToString()));

            reportView.LocalReport.ReportPath = "../../Reports/rptArtist.rdlc";

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DBSetArtists";

            rds.Value = _source;

            reportView.LocalReport.SetParameters(rpc);
            reportView.LocalReport.DataSources.Add(rds);

            this.reportView.RefreshReport();
        }

        private void reportView_Load(object sender, EventArgs e)
        {

        }
    }
}
