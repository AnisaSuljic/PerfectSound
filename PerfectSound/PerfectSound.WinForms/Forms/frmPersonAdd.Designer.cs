
namespace PerfectSound.WinForms.Forms
{
    partial class frmPersonAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonAdd));
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtPlaceOfBirth = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richtxtBiography = new System.Windows.Forms.RichTextBox();
            this.btnAddProfilePic = new System.Windows.Forms.Button();
            this.pbProfilePic = new System.Windows.Forms.PictureBox();
            this.dtpDateOfDeath = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ofdProfilPhoto = new System.Windows.Forms.OpenFileDialog();
            this.Radiodeath = new System.Windows.Forms.RadioButton();
            this.errorPerson = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddPerson.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddPerson.Location = new System.Drawing.Point(725, 417);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(166, 35);
            this.btnAddPerson.TabIndex = 38;
            this.btnAddPerson.Text = "Add person";
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(243, 179);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(337, 22);
            this.dtpDateOfBirth.TabIndex = 35;
            // 
            // txtPlaceOfBirth
            // 
            this.txtPlaceOfBirth.Location = new System.Drawing.Point(243, 236);
            this.txtPlaceOfBirth.Name = "txtPlaceOfBirth";
            this.txtPlaceOfBirth.Size = new System.Drawing.Size(337, 22);
            this.txtPlaceOfBirth.TabIndex = 34;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(243, 122);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(337, 22);
            this.txtLastName.TabIndex = 33;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(243, 65);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(337, 22);
            this.txtFirstName.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Place of birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Last name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Date of birth";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(243, 45);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(74, 17);
            this.Title.TabIndex = 27;
            this.Title.Text = "First name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Biography";
            // 
            // richtxtBiography
            // 
            this.richtxtBiography.BackColor = System.Drawing.Color.White;
            this.richtxtBiography.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richtxtBiography.Location = new System.Drawing.Point(621, 59);
            this.richtxtBiography.Name = "richtxtBiography";
            this.richtxtBiography.Size = new System.Drawing.Size(270, 335);
            this.richtxtBiography.TabIndex = 25;
            this.richtxtBiography.Text = "";
            // 
            // btnAddProfilePic
            // 
            this.btnAddProfilePic.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddProfilePic.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddProfilePic.Location = new System.Drawing.Point(53, 241);
            this.btnAddProfilePic.Name = "btnAddProfilePic";
            this.btnAddProfilePic.Size = new System.Drawing.Size(149, 35);
            this.btnAddProfilePic.TabIndex = 24;
            this.btnAddProfilePic.Text = "Add profile picture";
            this.btnAddProfilePic.UseVisualStyleBackColor = false;
            this.btnAddProfilePic.Click += new System.EventHandler(this.btnAddProfilePic_Click);
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.BackColor = System.Drawing.Color.White;
            this.pbProfilePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProfilePic.Location = new System.Drawing.Point(53, 59);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.Size = new System.Drawing.Size(149, 176);
            this.pbProfilePic.TabIndex = 23;
            this.pbProfilePic.TabStop = false;
            // 
            // dtpDateOfDeath
            // 
            this.dtpDateOfDeath.Location = new System.Drawing.Point(243, 293);
            this.dtpDateOfDeath.Name = "dtpDateOfDeath";
            this.dtpDateOfDeath.Size = new System.Drawing.Size(297, 22);
            this.dtpDateOfDeath.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "Date of death";
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(243, 350);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(167, 24);
            this.cbGender.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Gender";
            // 
            // ofdProfilPhoto
            // 
            this.ofdProfilPhoto.FileName = "ofdProfilPhoto";
            // 
            // Radiodeath
            // 
            this.Radiodeath.AutoSize = true;
            this.Radiodeath.Location = new System.Drawing.Point(563, 298);
            this.Radiodeath.Name = "Radiodeath";
            this.Radiodeath.Size = new System.Drawing.Size(17, 16);
            this.Radiodeath.TabIndex = 43;
            this.Radiodeath.TabStop = true;
            this.Radiodeath.UseVisualStyleBackColor = true;
            this.Radiodeath.CheckedChanged += new System.EventHandler(this.Radiodeath_CheckedChanged);
            this.Radiodeath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Radiodeath_MouseClick);
            // 
            // errorPerson
            // 
            this.errorPerson.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(53, 417);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 35);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmPersonAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 521);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.Radiodeath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.dtpDateOfDeath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.txtPlaceOfBirth);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richtxtBiography);
            this.Controls.Add(this.btnAddProfilePic);
            this.Controls.Add(this.pbProfilePic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersonAdd";
            this.Load += new System.EventHandler(this.frmPersonAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox txtPlaceOfBirth;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richtxtBiography;
        private System.Windows.Forms.Button btnAddProfilePic;
        private System.Windows.Forms.PictureBox pbProfilePic;
        private System.Windows.Forms.DateTimePicker dtpDateOfDeath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog ofdProfilPhoto;
        private System.Windows.Forms.RadioButton Radiodeath;
        private System.Windows.Forms.ErrorProvider errorPerson;
        private System.Windows.Forms.Button btnDelete;
    }
}