
namespace PerfectSound.WinForms.Forms
{
    partial class SongAndPodcastAdd
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
            this.podcastBtn = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // podcastBtn
            // 
            this.podcastBtn.AutoSize = true;
            this.podcastBtn.Checked = true;
            this.podcastBtn.Location = new System.Drawing.Point(578, 420);
            this.podcastBtn.Name = "podcastBtn";
            this.podcastBtn.Size = new System.Drawing.Size(80, 21);
            this.podcastBtn.TabIndex = 1;
            this.podcastBtn.TabStop = true;
            this.podcastBtn.Text = "Podcast";
            this.podcastBtn.UseVisualStyleBackColor = true;
            this.podcastBtn.CheckedChanged += new System.EventHandler(this.podcastBtn_CheckedChanged);
            this.podcastBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.podcastBtn_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(68, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 303);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(107, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add poster";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // richtxtSong
            // 
            this.richtxtSong.BackColor = System.Drawing.Color.White;
            this.richtxtSong.Location = new System.Drawing.Point(716, 80);
            this.richtxtSong.Name = "richtxtSong";
            this.richtxtSong.Size = new System.Drawing.Size(270, 361);
            this.richtxtSong.TabIndex = 4;
            this.richtxtSong.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(713, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Text";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(318, 89);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(35, 17);
            this.Title.TabIndex = 6;
            this.Title.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Release date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Running time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Budget";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Genre";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(321, 109);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(337, 22);
            this.txtTitle.TabIndex = 11;
            // 
            // txtRunningTime
            // 
            this.txtRunningTime.Location = new System.Drawing.Point(321, 167);
            this.txtRunningTime.Name = "txtRunningTime";
            this.txtRunningTime.Size = new System.Drawing.Size(337, 22);
            this.txtRunningTime.TabIndex = 12;
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(321, 287);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.Size = new System.Drawing.Size(337, 22);
            this.txtBudget.TabIndex = 13;
            // 
            // cbGenre
            // 
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(321, 353);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(121, 24);
            this.cbGenre.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(321, 228);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(337, 22);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // SongAndPodcastAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1056, 535);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbGenre);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.podcastBtn);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SongAndPodcastAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD SONG/PODCAST";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton podcastBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}