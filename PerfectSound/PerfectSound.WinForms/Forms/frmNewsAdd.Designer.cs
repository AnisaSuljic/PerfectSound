
namespace PerfectSound.WinForms.Forms
{
    partial class frmNewsAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewsAdd));
            this.pbNewsPoster = new System.Windows.Forms.PictureBox();
            this.btnAddNewsPoster = new System.Windows.Forms.Button();
            this.txtTitleNews = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Subtitle = new System.Windows.Forms.Label();
            this.txtSubTitleNews = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPublication = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveNews = new System.Windows.Forms.Button();
            this.coverPhoto = new System.Windows.Forms.OpenFileDialog();
            this.errorNews = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNewsPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNews)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNewsPoster
            // 
            this.pbNewsPoster.BackColor = System.Drawing.Color.White;
            this.pbNewsPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNewsPoster.Location = new System.Drawing.Point(49, 103);
            this.pbNewsPoster.Name = "pbNewsPoster";
            this.pbNewsPoster.Size = new System.Drawing.Size(265, 301);
            this.pbNewsPoster.TabIndex = 0;
            this.pbNewsPoster.TabStop = false;
            // 
            // btnAddNewsPoster
            // 
            this.btnAddNewsPoster.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddNewsPoster.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddNewsPoster.Location = new System.Drawing.Point(110, 410);
            this.btnAddNewsPoster.Name = "btnAddNewsPoster";
            this.btnAddNewsPoster.Size = new System.Drawing.Size(149, 35);
            this.btnAddNewsPoster.TabIndex = 25;
            this.btnAddNewsPoster.Text = "Add news picture";
            this.btnAddNewsPoster.UseVisualStyleBackColor = false;
            this.btnAddNewsPoster.Click += new System.EventHandler(this.btnAddNewsPoster_Click);
            // 
            // txtTitleNews
            // 
            this.txtTitleNews.Location = new System.Drawing.Point(367, 56);
            this.txtTitleNews.Multiline = true;
            this.txtTitleNews.Name = "txtTitleNews";
            this.txtTitleNews.Size = new System.Drawing.Size(484, 22);
            this.txtTitleNews.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Title";
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.Location = new System.Drawing.Point(364, 103);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(55, 17);
            this.Subtitle.TabIndex = 29;
            this.Subtitle.Text = "Subtitle";
            // 
            // txtSubTitleNews
            // 
            this.txtSubTitleNews.Location = new System.Drawing.Point(367, 123);
            this.txtSubTitleNews.Name = "txtSubTitleNews";
            this.txtSubTitleNews.Size = new System.Drawing.Size(484, 22);
            this.txtSubTitleNews.TabIndex = 28;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(367, 257);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(484, 259);
            this.txtContent.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Content";
            // 
            // dtpPublication
            // 
            this.dtpPublication.Location = new System.Drawing.Point(367, 190);
            this.dtpPublication.Name = "dtpPublication";
            this.dtpPublication.Size = new System.Drawing.Size(484, 22);
            this.dtpPublication.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Release date";
            // 
            // btnSaveNews
            // 
            this.btnSaveNews.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSaveNews.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSaveNews.Location = new System.Drawing.Point(702, 548);
            this.btnSaveNews.Name = "btnSaveNews";
            this.btnSaveNews.Size = new System.Drawing.Size(149, 35);
            this.btnSaveNews.TabIndex = 34;
            this.btnSaveNews.Text = "Save news";
            this.btnSaveNews.UseVisualStyleBackColor = false;
            this.btnSaveNews.Click += new System.EventHandler(this.btnSaveNews_Click);
            // 
            // coverPhoto
            // 
            this.coverPhoto.FileName = "coverPhoto";
            // 
            // errorNews
            // 
            this.errorNews.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(49, 548);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 35);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmNewsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(899, 607);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveNews);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpPublication);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.txtSubTitleNews);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitleNews);
            this.Controls.Add(this.btnAddNewsPoster);
            this.Controls.Add(this.pbNewsPoster);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewsAdd";
            this.Load += new System.EventHandler(this.frmNewsAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNewsPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorNews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNewsPoster;
        private System.Windows.Forms.Button btnAddNewsPoster;
        private System.Windows.Forms.TextBox txtTitleNews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.TextBox txtSubTitleNews;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPublication;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveNews;
        private System.Windows.Forms.OpenFileDialog coverPhoto;
        private System.Windows.Forms.ErrorProvider errorNews;
        private System.Windows.Forms.Button btnDelete;
    }
}