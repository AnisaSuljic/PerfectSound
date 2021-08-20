
namespace PerfectSound.WinForms.Forms
{
    partial class frmNewsSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewsSearch));
            this.dgwData = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filters = new System.Windows.Forms.GroupBox();
            this.radioBtnUkljuciDatum = new System.Windows.Forms.RadioButton();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPublicationDateSearch = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitleSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).BeginInit();
            this.Filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwData
            // 
            this.dgwData.AllowUserToAddRows = false;
            this.dgwData.BackgroundColor = System.Drawing.Color.White;
            this.dgwData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Subtitle,
            this.PublicationDate});
            this.dgwData.Location = new System.Drawing.Point(12, 278);
            this.dgwData.Name = "dgwData";
            this.dgwData.ReadOnly = true;
            this.dgwData.RowHeadersWidth = 51;
            this.dgwData.RowTemplate.Height = 24;
            this.dgwData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwData.Size = new System.Drawing.Size(921, 265);
            this.dgwData.TabIndex = 3;
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
            // Subtitle
            // 
            this.Subtitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Subtitle.DataPropertyName = "SubTitle";
            this.Subtitle.HeaderText = "Subtitle";
            this.Subtitle.MinimumWidth = 6;
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.ReadOnly = true;
            // 
            // PublicationDate
            // 
            this.PublicationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PublicationDate.DataPropertyName = "PublicationDate";
            this.PublicationDate.HeaderText = "Publication date";
            this.PublicationDate.MinimumWidth = 6;
            this.PublicationDate.Name = "PublicationDate";
            this.PublicationDate.ReadOnly = true;
            // 
            // Filters
            // 
            this.Filters.Controls.Add(this.radioBtnUkljuciDatum);
            this.Filters.Controls.Add(this.btnClearFilter);
            this.Filters.Controls.Add(this.btnSearch);
            this.Filters.Controls.Add(this.label3);
            this.Filters.Controls.Add(this.dtpPublicationDateSearch);
            this.Filters.Controls.Add(this.label1);
            this.Filters.Controls.Add(this.txtTitleSearch);
            this.Filters.Location = new System.Drawing.Point(12, 12);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(921, 260);
            this.Filters.TabIndex = 2;
            this.Filters.TabStop = false;
            this.Filters.Text = "Filters";
            // 
            // radioBtnUkljuciDatum
            // 
            this.radioBtnUkljuciDatum.AutoSize = true;
            this.radioBtnUkljuciDatum.Location = new System.Drawing.Point(606, 125);
            this.radioBtnUkljuciDatum.Name = "radioBtnUkljuciDatum";
            this.radioBtnUkljuciDatum.Size = new System.Drawing.Size(17, 16);
            this.radioBtnUkljuciDatum.TabIndex = 9;
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
            this.btnSearch.Location = new System.Drawing.Point(378, 184);
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
            this.label3.Location = new System.Drawing.Point(309, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Publication date";
            // 
            // dtpPublicationDateSearch
            // 
            this.dtpPublicationDateSearch.Location = new System.Drawing.Point(312, 120);
            this.dtpPublicationDateSearch.Name = "dtpPublicationDateSearch";
            this.dtpPublicationDateSearch.Size = new System.Drawing.Size(288, 22);
            this.dtpPublicationDateSearch.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // txtTitleSearch
            // 
            this.txtTitleSearch.Location = new System.Drawing.Point(312, 63);
            this.txtTitleSearch.Name = "txtTitleSearch";
            this.txtTitleSearch.Size = new System.Drawing.Size(288, 22);
            this.txtTitleSearch.TabIndex = 0;
            // 
            // frmNewsSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 554);
            this.Controls.Add(this.dgwData);
            this.Controls.Add(this.Filters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewsSearch";
            this.Load += new System.EventHandler(this.frmNewsSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).EndInit();
            this.Filters.ResumeLayout(false);
            this.Filters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwData;
        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPublicationDateSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitleSearch;
        private System.Windows.Forms.RadioButton radioBtnUkljuciDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicationDate;
    }
}