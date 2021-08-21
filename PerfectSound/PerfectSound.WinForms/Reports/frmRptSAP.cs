using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PerfectSound.Model.Model;
using PerfectSound.Model.Requests.SongAndPodcast;
using PerfectSound.Model.ViewModels;

namespace PerfectSound.WinForms.Reports
{
    public partial class frmRptSAP : Form
    {
        APIService _GenreService = new APIService("Genre");
        private List<frmSongOrPodcastVM> _source;
        private SongAndPodcastSearchRequest _filters;
        private bool _isPodcast;
        public frmRptSAP(List<frmSongOrPodcastVM> source, SongAndPodcastSearchRequest filters,bool isPodcast)
        {
            InitializeComponent();
            _source = source;
            _filters = filters;
            _isPodcast = isPodcast;
        }

        private async void frmRptSAP_Load(object sender, EventArgs e)
        {
            Genre genre;
            string genreName = "//";
            string releaseDate = "//";
            string titleFil = "//";
            string sop = " ";
            if (_filters != null)
            {
                if (_filters.GenreId!=0)
                {
                     genre= await _GenreService.GetById<Genre>(_filters.GenreId);
                    genreName = genre.GenreName;
                }
                if (_filters.ReleaseDate != null)
                    releaseDate = _filters.ReleaseDate.Value.ToString();
                if (_filters.Title != "")
                    titleFil = _filters.Title;
            }
            if (_isPodcast == true)
                sop = "podcasts";
            else
                sop = "songs";



            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ReportDate", DateTime.Today.ToString()));
            rpc.Add(new ReportParameter("ReportCount", _source.Count.ToString()));
            rpc.Add(new ReportParameter("TitleFilter", titleFil));
            rpc.Add(new ReportParameter("GenreFilter",genreName));
            rpc.Add(new ReportParameter("ReleaseDateFilter", releaseDate));
            rpc.Add(new ReportParameter("SongOrPodcast",sop));


            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DBSetSAP";

            if (_isPodcast == true)
            {
                foreach (var item in _source)
                {
                    item.RunningTime = "//";
                }
            }
            
            rds.Value = _source;

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
