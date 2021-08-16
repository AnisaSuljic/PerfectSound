
namespace PerfectSound.WinForms.Forms
{
    partial class frmPersonSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonSearch));
            this.dgwPersonData = new System.Windows.Forms.DataGridView();
            this.Firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filters = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastnameSearch = new System.Windows.Forms.TextBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGenderSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstnameSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPersonData)).BeginInit();
            this.Filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwPersonData
            // 
            this.dgwPersonData.AllowUserToAddRows = false;
            this.dgwPersonData.BackgroundColor = System.Drawing.Color.White;
            this.dgwPersonData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPersonData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Firstname,
            this.Lastname,
            this.Gender,
            this.DateOfBirth,
            this.Status});
            this.dgwPersonData.Location = new System.Drawing.Point(22, 279);
            this.dgwPersonData.Name = "dgwPersonData";
            this.dgwPersonData.ReadOnly = true;
            this.dgwPersonData.RowHeadersWidth = 51;
            this.dgwPersonData.RowTemplate.Height = 24;
            this.dgwPersonData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwPersonData.Size = new System.Drawing.Size(921, 265);
            this.dgwPersonData.TabIndex = 3;
            this.dgwPersonData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPersonData_CellDoubleClick);
            // 
            // Firstname
            // 
            this.Firstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Firstname.DataPropertyName = "FirstName";
            this.Firstname.HeaderText = "Firstname";
            this.Firstname.MinimumWidth = 6;
            this.Firstname.Name = "Firstname";
            this.Firstname.ReadOnly = true;
            // 
            // Lastname
            // 
            this.Lastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lastname.DataPropertyName = "LastName";
            this.Lastname.HeaderText = "Lastname";
            this.Lastname.MinimumWidth = 6;
            this.Lastname.Name = "Lastname";
            this.Lastname.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.HeaderText = "Date of birth";
            this.DateOfBirth.MinimumWidth = 6;
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Filters
            // 
            this.Filters.Controls.Add(this.label3);
            this.Filters.Controls.Add(this.txtLastnameSearch);
            this.Filters.Controls.Add(this.btnClearFilter);
            this.Filters.Controls.Add(this.btnSearch);
            this.Filters.Controls.Add(this.label2);
            this.Filters.Controls.Add(this.cbGenderSearch);
            this.Filters.Controls.Add(this.label1);
            this.Filters.Controls.Add(this.txtFirstnameSearch);
            this.Filters.Location = new System.Drawing.Point(22, 13);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(921, 260);
            this.Filters.TabIndex = 2;
            this.Filters.TabStop = false;
            this.Filters.Text = "Filters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lastname";
            // 
            // txtLastnameSearch
            // 
            this.txtLastnameSearch.Location = new System.Drawing.Point(312, 97);
            this.txtLastnameSearch.Name = "txtLastnameSearch";
            this.txtLastnameSearch.Size = new System.Drawing.Size(288, 22);
            this.txtLastnameSearch.TabIndex = 8;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gender";
            // 
            // cbGenderSearch
            // 
            this.cbGenderSearch.FormattingEnabled = true;
            this.cbGenderSearch.Location = new System.Drawing.Point(312, 154);
            this.cbGenderSearch.Name = "cbGenderSearch";
            this.cbGenderSearch.Size = new System.Drawing.Size(288, 24);
            this.cbGenderSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Firstname";
            // 
            // txtFirstnameSearch
            // 
            this.txtFirstnameSearch.Location = new System.Drawing.Point(312, 40);
            this.txtFirstnameSearch.Name = "txtFirstnameSearch";
            this.txtFirstnameSearch.Size = new System.Drawing.Size(288, 22);
            this.txtFirstnameSearch.TabIndex = 0;
            // 
            // frmPersonSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 554);
            this.Controls.Add(this.dgwPersonData);
            this.Controls.Add(this.Filters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersonSearch";
            this.Load += new System.EventHandler(this.frmPersonSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPersonData)).EndInit();
            this.Filters.ResumeLayout(false);
            this.Filters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPersonData;
        private System.Windows.Forms.GroupBox Filters;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGenderSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstnameSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastnameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}