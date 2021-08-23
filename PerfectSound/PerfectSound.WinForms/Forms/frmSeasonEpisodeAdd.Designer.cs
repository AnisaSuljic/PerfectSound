
namespace PerfectSound.WinForms.Forms
{
    partial class frmSeasonEpisodeAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeasonEpisodeAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSeason = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeasonName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddEpisode = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSeason = new System.Windows.Forms.ComboBox();
            this.txtEpisodeNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEpisodeName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgwEpisodes = new System.Windows.Forms.DataGridView();
            this.EpisodeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Episodename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSeasonSearch = new System.Windows.Forms.ComboBox();
            this.btnCountinue = new System.Windows.Forms.Button();
            this.errorSeasonAdd = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvSeasons = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEpisodeNumber)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEpisodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSeasonAdd)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeasons)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSeason);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSeasonName);
            this.groupBox1.Location = new System.Drawing.Point(64, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add season";
            // 
            // btnAddSeason
            // 
            this.btnAddSeason.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddSeason.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddSeason.Location = new System.Drawing.Point(312, 143);
            this.btnAddSeason.Name = "btnAddSeason";
            this.btnAddSeason.Size = new System.Drawing.Size(111, 35);
            this.btnAddSeason.TabIndex = 39;
            this.btnAddSeason.Text = "Add season";
            this.btnAddSeason.UseVisualStyleBackColor = false;
            this.btnAddSeason.Click += new System.EventHandler(this.btnAddSeason_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Season name";
            // 
            // txtSeasonName
            // 
            this.txtSeasonName.Location = new System.Drawing.Point(39, 78);
            this.txtSeasonName.Name = "txtSeasonName";
            this.txtSeasonName.Size = new System.Drawing.Size(250, 22);
            this.txtSeasonName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddEpisode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbSeason);
            this.groupBox2.Controls.Add(this.txtEpisodeNumber);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtEpisodeName);
            this.groupBox2.Location = new System.Drawing.Point(64, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 337);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add episode";
            // 
            // btnAddEpisode
            // 
            this.btnAddEpisode.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddEpisode.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddEpisode.Location = new System.Drawing.Point(312, 296);
            this.btnAddEpisode.Name = "btnAddEpisode";
            this.btnAddEpisode.Size = new System.Drawing.Size(111, 35);
            this.btnAddEpisode.TabIndex = 40;
            this.btnAddEpisode.Text = "Add episode";
            this.btnAddEpisode.UseVisualStyleBackColor = false;
            this.btnAddEpisode.Click += new System.EventHandler(this.btnAddEpisode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "Season";
            // 
            // cbSeason
            // 
            this.cbSeason.FormattingEnabled = true;
            this.cbSeason.Location = new System.Drawing.Point(39, 94);
            this.cbSeason.Name = "cbSeason";
            this.cbSeason.Size = new System.Drawing.Size(250, 24);
            this.cbSeason.TabIndex = 46;
            // 
            // txtEpisodeNumber
            // 
            this.txtEpisodeNumber.Location = new System.Drawing.Point(312, 176);
            this.txtEpisodeNumber.Name = "txtEpisodeNumber";
            this.txtEpisodeNumber.Size = new System.Drawing.Size(75, 22);
            this.txtEpisodeNumber.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Episode\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "Episode name";
            // 
            // txtEpisodeName
            // 
            this.txtEpisodeName.Location = new System.Drawing.Point(39, 176);
            this.txtEpisodeName.Name = "txtEpisodeName";
            this.txtEpisodeName.Size = new System.Drawing.Size(250, 22);
            this.txtEpisodeName.TabIndex = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dgwEpisodes);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbSeasonSearch);
            this.groupBox3.Location = new System.Drawing.Point(947, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 527);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(189, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 17);
            this.label9.TabIndex = 52;
            this.label9.Text = "*double click to delete episode";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "List of episodes";
            // 
            // dgwEpisodes
            // 
            this.dgwEpisodes.BackgroundColor = System.Drawing.Color.White;
            this.dgwEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwEpisodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EpisodeNum,
            this.Episodename});
            this.dgwEpisodes.Location = new System.Drawing.Point(37, 131);
            this.dgwEpisodes.Name = "dgwEpisodes";
            this.dgwEpisodes.RowHeadersWidth = 51;
            this.dgwEpisodes.RowTemplate.Height = 24;
            this.dgwEpisodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwEpisodes.Size = new System.Drawing.Size(352, 362);
            this.dgwEpisodes.TabIndex = 50;
            this.dgwEpisodes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwEpisodes_CellContentClick);
            this.dgwEpisodes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwEpisodes_CellDoubleClick);
            // 
            // EpisodeNum
            // 
            this.EpisodeNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EpisodeNum.DataPropertyName = "EpisodeNumber";
            this.EpisodeNum.HeaderText = "Episode number";
            this.EpisodeNum.MinimumWidth = 6;
            this.EpisodeNum.Name = "EpisodeNum";
            // 
            // Episodename
            // 
            this.Episodename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Episodename.DataPropertyName = "EpisodeName";
            this.Episodename.HeaderText = "Episode name";
            this.Episodename.MinimumWidth = 6;
            this.Episodename.Name = "Episodename";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Season";
            // 
            // cbSeasonSearch
            // 
            this.cbSeasonSearch.FormattingEnabled = true;
            this.cbSeasonSearch.Location = new System.Drawing.Point(37, 78);
            this.cbSeasonSearch.Name = "cbSeasonSearch";
            this.cbSeasonSearch.Size = new System.Drawing.Size(250, 24);
            this.cbSeasonSearch.TabIndex = 48;
            this.cbSeasonSearch.SelectionChangeCommitted += new System.EventHandler(this.cbSeasonSearch_SelectionChangeCommitted);
            // 
            // btnCountinue
            // 
            this.btnCountinue.BackColor = System.Drawing.Color.SlateBlue;
            this.btnCountinue.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCountinue.Location = new System.Drawing.Point(1195, 562);
            this.btnCountinue.Name = "btnCountinue";
            this.btnCountinue.Size = new System.Drawing.Size(141, 35);
            this.btnCountinue.TabIndex = 48;
            this.btnCountinue.Text = "Countinue";
            this.btnCountinue.UseVisualStyleBackColor = false;
            this.btnCountinue.Click += new System.EventHandler(this.btnCountinue_Click);
            // 
            // errorSeasonAdd
            // 
            this.errorSeasonAdd.ContainerControl = this.txtEpisodeNumber;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SlateBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(42, 35);
            this.btnBack.TabIndex = 49;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.dgvSeasons);
            this.groupBox4.Location = new System.Drawing.Point(509, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(423, 527);
            this.groupBox4.TabIndex = 52;
            this.groupBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(189, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 17);
            this.label10.TabIndex = 53;
            this.label10.Text = "*double click to delete season\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "List of seasons";
            // 
            // dgvSeasons
            // 
            this.dgvSeasons.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeasons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dgvSeasons.Location = new System.Drawing.Point(37, 52);
            this.dgvSeasons.Name = "dgvSeasons";
            this.dgvSeasons.RowHeadersWidth = 51;
            this.dgvSeasons.RowTemplate.Height = 24;
            this.dgvSeasons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeasons.Size = new System.Drawing.Size(352, 441);
            this.dgvSeasons.TabIndex = 50;
            this.dgvSeasons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeasons_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SeasonName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Season name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // frmSeasonEpisodeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 609);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCountinue);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSeasonEpisodeAdd";
            this.Load += new System.EventHandler(this.frmSeasonEpisodeAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEpisodeNumber)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEpisodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSeasonAdd)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeasons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeasonName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddSeason;
        private System.Windows.Forms.Button btnAddEpisode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSeason;
        private System.Windows.Forms.NumericUpDown txtEpisodeNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEpisodeName;
        private System.Windows.Forms.DataGridView dgwEpisodes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSeasonSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn EpisodeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Episodename;
        private System.Windows.Forms.ErrorProvider errorSeasonAdd;
        private System.Windows.Forms.Button btnCountinue;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvSeasons;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}