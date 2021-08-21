
namespace PerfectSound.WinForms.Forms
{
    partial class frmSongAndPodcastSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSongAndPodcastSearch));
            this.Filters = new System.Windows.Forms.GroupBox();
            this.radioBtnUkljuciDatum = new System.Windows.Forms.RadioButton();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpReleaseDateSearch = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGenreSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            this.dgwData = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductionCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReport = new System.Windows.Forms.Button();
            this.Filters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).BeginInit();
            this.SuspendLayout();
            // 
            // Filters
            // 
            this.Filters.Controls.Add(this.radioBtnUkljuciDatum);
            this.Filters.Controls.Add(this.btnClearFilter);
            this.Filters.Controls.Add(this.btnSearch);
            this.Filters.Controls.Add(this.label3);
            this.Filters.Controls.Add(this.dtpReleaseDateSearch);
            this.Filters.Controls.Add(this.label2);
            this.Filters.Controls.Add(this.cbGenreSearch);
            this.Filters.Controls.Add(this.label1);
            this.Filters.Controls.Add(this.txtTitleSearch);
            this.Filters.Location = new System.Drawing.Point(12, 12);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(921, 260);
            this.Filters.TabIndex = 0;
            this.Filters.TabStop = false;
            this.Filters.Text = "Filters";
            // 
            // radioBtnUkljuciDatum
            // 
            this.radioBtnUkljuciDatum.AutoSize = true;
            this.radioBtnUkljuciDatum.Location = new System.Drawing.Point(606, 161);
            this.radioBtnUkljuciDatum.Name = "radioBtnUkljuciDatum";
            this.radioBtnUkljuciDatum.Size = new System.Drawing.Size(17, 16);
            this.radioBtnUkljuciDatum.TabIndex = 8;
            this.radioBtnUkljuciDatum.TabStop = true;
            this.radioBtnUkljuciDatum.UseVisualStyleBackColor = true;
            this.radioBtnUkljuciDatum.CheckedChanged += new System.EventHandler(this.radioBtnUkljuciDatum_CheckedChanged);
            this.radioBtnUkljuciDatum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioBtnUkljuciDatum_MouseClick);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.SlateBlue;
            this.btnClearFilter.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClearFilter.Location = new System.Drawing.Point(819, 212);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(96, 34);
            this.btnClearFilter.TabIndex = 7;
            this.btnClearFilter.Text = "Clear filter";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Location = new System.Drawing.Point(376, 202);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(149, 35);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Release date";
            // 
            // dtpReleaseDateSearch
            // 
            this.dtpReleaseDateSearch.Location = new System.Drawing.Point(312, 156);
            this.dtpReleaseDateSearch.Name = "dtpReleaseDateSearch";
            this.dtpReleaseDateSearch.Size = new System.Drawing.Size(288, 22);
            this.dtpReleaseDateSearch.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Genre";
            // 
            // cbGenreSearch
            // 
            this.cbGenreSearch.FormattingEnabled = true;
            this.cbGenreSearch.Location = new System.Drawing.Point(312, 97);
            this.cbGenreSearch.Name = "cbGenreSearch";
            this.cbGenreSearch.Size = new System.Drawing.Size(288, 24);
            this.cbGenreSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Location = new System.Drawing.Point(312, 40);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(288, 22);
            this.txtTitleSearch.TabIndex = 0;
            // 
            // dgwData
            // 
            this.dgwData.AllowUserToAddRows = false;
            this.dgwData.BackgroundColor = System.Drawing.Color.White;
            this.dgwData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Genre,
            this.ReleaseDate,
            this.Budget,
            this.ProductionCompany});
            this.dgwData.Location = new System.Drawing.Point(12, 278);
            this.dgwData.Name = "dgwData";
            this.dgwData.ReadOnly = true;
            this.dgwData.RowHeadersWidth = 51;
            this.dgwData.RowTemplate.Height = 24;
            this.dgwData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwData.Size = new System.Drawing.Size(921, 265);
            this.dgwData.TabIndex = 1;
            this.dgwData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwData_CellDoubleClick);
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Genre
            // 
            this.Genre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Genre.DataPropertyName = "Genre";
            this.Genre.HeaderText = "Genre";
            this.Genre.MinimumWidth = 6;
            this.Genre.Name = "Genre";
            this.Genre.ReadOnly = true;
            // 
            // ReleaseDate
            // 
            this.ReleaseDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReleaseDate.DataPropertyName = "ReleaseDate";
            this.ReleaseDate.HeaderText = "Release date";
            this.ReleaseDate.MinimumWidth = 6;
            this.ReleaseDate.Name = "ReleaseDate";
            this.ReleaseDate.ReadOnly = true;
            // 
            // Budget
            // 
            this.Budget.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Budget.DataPropertyName = "Budget";
            this.Budget.HeaderText = "Budget";
            this.Budget.MinimumWidth = 6;
            this.Budget.Name = "Budget";
            this.Budget.ReadOnly = true;
            // 
            // ProductionCompany
            // 
            this.ProductionCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductionCompany.DataPropertyName = "ProductionCompanyName";
            this.ProductionCompany.HeaderText = "Production company";
            this.ProductionCompany.MinimumWidth = 6;
            this.ProductionCompany.Name = "ProductionCompany";
            this.ProductionCompany.ReadOnly = true;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.SlateBlue;
            this.btnReport.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReport.Location = new System.Drawing.Point(768, 551);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(165, 34);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmSongAndPodcastSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 597);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dgwData);
            this.Controls.Add(this.Filters);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSongAndPodcastSearch";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSongAndPodcastSearch_Load);
            this.Filters.ResumeLayout(false);
            this.Filters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpReleaseDateSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGenreSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgwData;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.RadioButton radioBtnUkljuciDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductionCompany;
        private System.Windows.Forms.Button btnReport;
    }
}