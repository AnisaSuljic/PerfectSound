
namespace PerfectSound.WinForms.Forms
{
    partial class frmSongAndPodcastPersonAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSongAndPodcastPersonAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddArtist = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.txtSongPodcast = new System.Windows.Forms.TextBox();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.dgwArtists = new System.Windows.Forms.DataGridView();
            this.ArtistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgwAllArtists = new System.Windows.Forms.DataGridView();
            this.ArtistsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongPodcast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSearchRoles = new System.Windows.Forms.ComboBox();
            this.txtSearchSongPodcast = new System.Windows.Forms.TextBox();
            this.ErrorSongAndPodcastPersonAdd = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwArtists)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAllArtists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorSongAndPodcastPersonAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAddArtist);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cbRoles);
            this.groupBox1.Controls.Add(this.txtSongPodcast);
            this.groupBox1.Controls.Add(this.txtArtist);
            this.groupBox1.Controls.Add(this.dgwArtists);
            this.groupBox1.Controls.Add(this.txtArtistName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 562);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artists";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 17);
            this.label8.TabIndex = 48;
            this.label8.Text = "by firstname or lastname";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "Choose an artist";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Search artist";
            // 
            // btnAddArtist
            // 
            this.btnAddArtist.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddArtist.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddArtist.Location = new System.Drawing.Point(321, 70);
            this.btnAddArtist.Name = "btnAddArtist";
            this.btnAddArtist.Size = new System.Drawing.Size(137, 35);
            this.btnAddArtist.TabIndex = 44;
            this.btnAddArtist.Text = "Add new artist";
            this.btnAddArtist.UseVisualStyleBackColor = false;
            this.btnAddArtist.Click += new System.EventHandler(this.btnAddArtist_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Roles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Song/Podcast";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Artist";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(347, 504);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 35);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbRoles
            // 
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(37, 510);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(203, 24);
            this.cbRoles.TabIndex = 4;
            // 
            // txtSongPodcast
            // 
            this.txtSongPodcast.Location = new System.Drawing.Point(262, 446);
            this.txtSongPodcast.Name = "txtSongPodcast";
            this.txtSongPodcast.Size = new System.Drawing.Size(196, 22);
            this.txtSongPodcast.TabIndex = 3;
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(40, 446);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(200, 22);
            this.txtArtist.TabIndex = 2;
            // 
            // dgwArtists
            // 
            this.dgwArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwArtists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArtistName});
            this.dgwArtists.Location = new System.Drawing.Point(40, 130);
            this.dgwArtists.Name = "dgwArtists";
            this.dgwArtists.RowHeadersWidth = 51;
            this.dgwArtists.RowTemplate.Height = 24;
            this.dgwArtists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwArtists.Size = new System.Drawing.Size(418, 278);
            this.dgwArtists.TabIndex = 1;
            this.dgwArtists.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwArtists_CellClick);
            // 
            // ArtistName
            // 
            this.ArtistName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ArtistName.DataPropertyName = "FirstName";
            this.ArtistName.HeaderText = "";
            this.ArtistName.MinimumWidth = 6;
            this.ArtistName.Name = "ArtistName";
            // 
            // txtArtistName
            // 
            this.txtArtistName.Location = new System.Drawing.Point(40, 76);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(236, 22);
            this.txtArtistName.TabIndex = 0;
            this.txtArtistName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtArtistName_KeyUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgwAllArtists);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbSearchRoles);
            this.groupBox3.Controls.Add(this.txtSearchSongPodcast);
            this.groupBox3.Location = new System.Drawing.Point(532, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 562);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search artists";
            // 
            // dgwAllArtists
            // 
            this.dgwAllArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAllArtists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArtistsName,
            this.SongPodcast,
            this.Role});
            this.dgwAllArtists.Location = new System.Drawing.Point(38, 114);
            this.dgwAllArtists.Name = "dgwAllArtists";
            this.dgwAllArtists.RowHeadersWidth = 51;
            this.dgwAllArtists.RowTemplate.Height = 24;
            this.dgwAllArtists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwAllArtists.Size = new System.Drawing.Size(417, 420);
            this.dgwAllArtists.TabIndex = 46;
            
            // 
            // ArtistsName
            // 
            this.ArtistsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ArtistsName.DataPropertyName = "Name";
            this.ArtistsName.HeaderText = "Name";
            this.ArtistsName.MinimumWidth = 6;
            this.ArtistsName.Name = "ArtistsName";
            // 
            // SongPodcast
            // 
            this.SongPodcast.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SongPodcast.DataPropertyName = "SongPodcast";
            this.SongPodcast.HeaderText = "Song/Podcast";
            this.SongPodcast.MinimumWidth = 6;
            this.SongPodcast.Name = "SongPodcast";
            // 
            // Role
            // 
            this.Role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Role.DataPropertyName = "Role";
            this.Role.HeaderText = "Role";
            this.Role.MinimumWidth = 6;
            this.Role.Name = "Role";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Roles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "Song/Podcast";
            // 
            // cbSearchRoles
            // 
            this.cbSearchRoles.FormattingEnabled = true;
            this.cbSearchRoles.Location = new System.Drawing.Point(255, 60);
            this.cbSearchRoles.Name = "cbSearchRoles";
            this.cbSearchRoles.Size = new System.Drawing.Size(200, 24);
            this.cbSearchRoles.TabIndex = 46;
            this.cbSearchRoles.SelectionChangeCommitted += new System.EventHandler(this.cbSearchRoles_SelectionChangeCommitted);
            // 
            // txtSearchSongPodcast
            // 
            this.txtSearchSongPodcast.Location = new System.Drawing.Point(38, 62);
            this.txtSearchSongPodcast.Name = "txtSearchSongPodcast";
            this.txtSearchSongPodcast.Size = new System.Drawing.Size(196, 22);
            this.txtSearchSongPodcast.TabIndex = 46;
            // 
            // ErrorSongAndPodcastPersonAdd
            // 
            this.ErrorSongAndPodcastPersonAdd.ContainerControl = this;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SlateBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(12, 580);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(42, 35);
            this.btnBack.TabIndex = 50;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.SlateBlue;
            this.btnFinish.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFinish.Location = new System.Drawing.Point(918, 583);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(111, 35);
            this.btnFinish.TabIndex = 49;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // frmSongAndPodcastPersonAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 624);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSongAndPodcastPersonAdd";
            this.Load += new System.EventHandler(this.frmSongAndPodcastPersonAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwArtists)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAllArtists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorSongAndPodcastPersonAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.TextBox txtSongPodcast;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.DataGridView dgwArtists;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddArtist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgwAllArtists;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSearchRoles;
        private System.Windows.Forms.TextBox txtSearchSongPodcast;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SongPodcast;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.ErrorProvider ErrorSongAndPodcastPersonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFinish;
    }
}