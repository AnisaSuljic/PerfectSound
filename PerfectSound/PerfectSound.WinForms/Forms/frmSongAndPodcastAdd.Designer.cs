
namespace PerfectSound.WinForms.Forms
{
    partial class frmSongAndPodcastAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSongAndPodcastAdd));
            this.podcastBtn = new System.Windows.Forms.RadioButton();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.btnAddPoster = new System.Windows.Forms.Button();
            this.richtxtSong = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRunningTime = new System.Windows.Forms.TextBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProdCompany = new System.Windows.Forms.ComboBox();
            this.btnSaveSongPodcast = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.clbGenre = new System.Windows.Forms.CheckedListBox();
            this.ofdOpenPoster = new System.Windows.Forms.OpenFileDialog();
            this.ErrorSoundAndPodcastAdd = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.btnSeasonEpisodeSetting = new System.Windows.Forms.Button();
            this.btnArtists = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorSoundAndPodcastAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // podcastBtn
            // 
            this.podcastBtn.AutoSize = true;
            this.podcastBtn.BackColor = System.Drawing.SystemColors.Control;
            this.podcastBtn.Checked = true;
            this.podcastBtn.Location = new System.Drawing.Point(520, 402);
            this.podcastBtn.Name = "podcastBtn";
            this.podcastBtn.Size = new System.Drawing.Size(80, 21);
            this.podcastBtn.TabIndex = 1;
            this.podcastBtn.TabStop = true;
            this.podcastBtn.Text = "Podcast";
            this.podcastBtn.UseVisualStyleBackColor = false;
            this.podcastBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.podcastBtn_MouseClick);
            // 
            // pbPoster
            // 
            this.pbPoster.BackColor = System.Drawing.Color.White;
            this.pbPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPoster.Location = new System.Drawing.Point(73, 37);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(149, 176);
            this.pbPoster.TabIndex = 2;
            this.pbPoster.TabStop = false;
            // 
            // btnAddPoster
            // 
            this.btnAddPoster.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddPoster.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddPoster.Location = new System.Drawing.Point(73, 219);
            this.btnAddPoster.Name = "btnAddPoster";
            this.btnAddPoster.Size = new System.Drawing.Size(149, 35);
            this.btnAddPoster.TabIndex = 3;
            this.btnAddPoster.Text = "Add poster";
            this.btnAddPoster.UseVisualStyleBackColor = false;
            this.btnAddPoster.Click += new System.EventHandler(this.btnAddPoster_Click);
            // 
            // richtxtSong
            // 
            this.richtxtSong.BackColor = System.Drawing.Color.White;
            this.richtxtSong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richtxtSong.Location = new System.Drawing.Point(641, 37);
            this.richtxtSong.Name = "richtxtSong";
            this.richtxtSong.Size = new System.Drawing.Size(270, 335);
            this.richtxtSong.TabIndex = 4;
            this.richtxtSong.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Text";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(263, 17);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(35, 17);
            this.Title.TabIndex = 6;
            this.Title.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Release date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Running time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Budget";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Genre";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(263, 37);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(337, 22);
            this.txtTitle.TabIndex = 11;
            // 
            // txtRunningTime
            // 
            this.txtRunningTime.Location = new System.Drawing.Point(263, 94);
            this.txtRunningTime.Name = "txtRunningTime";
            this.txtRunningTime.Size = new System.Drawing.Size(337, 22);
            this.txtRunningTime.TabIndex = 12;
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(263, 208);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(310, 22);
            this.txtBudget.TabIndex = 13;
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(263, 151);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(337, 22);
            this.dtpReleaseDate.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Production company";
            // 
            // cbProdCompany
            // 
            this.cbProdCompany.FormattingEnabled = true;
            this.cbProdCompany.Location = new System.Drawing.Point(263, 265);
            this.cbProdCompany.Name = "cbProdCompany";
            this.cbProdCompany.Size = new System.Drawing.Size(337, 24);
            this.cbProdCompany.TabIndex = 17;
            // 
            // btnSaveSongPodcast
            // 
            this.btnSaveSongPodcast.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSaveSongPodcast.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSaveSongPodcast.Location = new System.Drawing.Point(745, 477);
            this.btnSaveSongPodcast.Name = "btnSaveSongPodcast";
            this.btnSaveSongPodcast.Size = new System.Drawing.Size(166, 35);
            this.btnSaveSongPodcast.TabIndex = 18;
            this.btnSaveSongPodcast.Text = "Save";
            this.btnSaveSongPodcast.UseVisualStyleBackColor = false;
            this.btnSaveSongPodcast.Click += new System.EventHandler(this.btnSaveSongPodcast_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(584, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "€";
            // 
            // clbGenre
            // 
            this.clbGenre.FormattingEnabled = true;
            this.clbGenre.Location = new System.Drawing.Point(263, 324);
            this.clbGenre.Name = "clbGenre";
            this.clbGenre.Size = new System.Drawing.Size(163, 106);
            this.clbGenre.TabIndex = 20;
            // 
            // ofdOpenPoster
            // 
            this.ofdOpenPoster.FileName = "openPoster";
            // 
            // ErrorSoundAndPodcastAdd
            // 
            this.ErrorSoundAndPodcastAdd.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(478, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "(format: 00:00:00)";
            // 
            // btnSeasonEpisodeSetting
            // 
            this.btnSeasonEpisodeSetting.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSeasonEpisodeSetting.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSeasonEpisodeSetting.Location = new System.Drawing.Point(745, 395);
            this.btnSeasonEpisodeSetting.Name = "btnSeasonEpisodeSetting";
            this.btnSeasonEpisodeSetting.Size = new System.Drawing.Size(166, 35);
            this.btnSeasonEpisodeSetting.TabIndex = 22;
            this.btnSeasonEpisodeSetting.Text = "Seasons/Episodes";
            this.btnSeasonEpisodeSetting.UseVisualStyleBackColor = false;
            this.btnSeasonEpisodeSetting.Click += new System.EventHandler(this.btnSeasonEpisodeSetting_Click);
            // 
            // btnArtists
            // 
            this.btnArtists.BackColor = System.Drawing.Color.SlateBlue;
            this.btnArtists.ForeColor = System.Drawing.SystemColors.Control;
            this.btnArtists.Location = new System.Drawing.Point(745, 436);
            this.btnArtists.Name = "btnArtists";
            this.btnArtists.Size = new System.Drawing.Size(166, 35);
            this.btnArtists.TabIndex = 23;
            this.btnArtists.Text = "Artists";
            this.btnArtists.UseVisualStyleBackColor = false;
            this.btnArtists.Click += new System.EventHandler(this.btnArtists_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SlateBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(42, 35);
            this.btnBack.TabIndex = 50;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(73, 477);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 35);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmSongAndPodcastAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(968, 571);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnArtists);
            this.Controls.Add(this.btnSeasonEpisodeSetting);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.podcastBtn);
            this.Controls.Add(this.clbGenre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSaveSongPodcast);
            this.Controls.Add(this.cbProdCompany);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.txtBudget);
            this.Controls.Add(this.txtRunningTime);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richtxtSong);
            this.Controls.Add(this.btnAddPoster);
            this.Controls.Add(this.pbPoster);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSongAndPodcastAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SongAndPodcastAdd_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorSoundAndPodcastAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton podcastBtn;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.Button btnAddPoster;
        private System.Windows.Forms.RichTextBox richtxtSong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtRunningTime;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProdCompany;
        private System.Windows.Forms.Button btnSaveSongPodcast;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox clbGenre;
        private System.Windows.Forms.OpenFileDialog ofdOpenPoster;
        private System.Windows.Forms.ErrorProvider ErrorSoundAndPodcastAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSeasonEpisodeSetting;
        private System.Windows.Forms.Button btnArtists;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
    }
}