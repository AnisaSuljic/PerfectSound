
namespace PerfectSound.WinForms.Forms
{
    partial class frmUserAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAdd));
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Prezime = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbUserType = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.checkPassword = new System.Windows.Forms.CheckBox();
            this.checkPasswordConfirm = new System.Windows.Forms.CheckBox();
            this.lblGeneratePass = new System.Windows.Forms.LinkLabel();
            this.errorUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(323, 59);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(301, 22);
            this.txtFirstName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Firstname";
            // 
            // Prezime
            // 
            this.Prezime.AutoSize = true;
            this.Prezime.Location = new System.Drawing.Point(320, 92);
            this.Prezime.Name = "Prezime";
            this.Prezime.Size = new System.Drawing.Size(70, 17);
            this.Prezime.TabIndex = 3;
            this.Prezime.Text = "Lastname";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(323, 112);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(301, 22);
            this.txtLastname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(323, 167);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(301, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(323, 221);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(301, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(323, 278);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(301, 22);
            this.txtPhone.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(323, 337);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(273, 22);
            this.txtPassword.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Password confirm";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(323, 418);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(273, 22);
            this.txtPasswordConfirm.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 450);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "User type";
            // 
            // cbUserType
            // 
            this.cbUserType.FormattingEnabled = true;
            this.cbUserType.Location = new System.Drawing.Point(323, 470);
            this.cbUserType.Name = "cbUserType";
            this.cbUserType.Size = new System.Drawing.Size(301, 24);
            this.cbUserType.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PerfectSound.WinForms.Properties.Resources.view;
            this.pictureBox1.Location = new System.Drawing.Point(626, 337);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PerfectSound.WinForms.Properties.Resources.view;
            this.pictureBox2.Location = new System.Drawing.Point(626, 418);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddUser.Location = new System.Drawing.Point(728, 529);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(166, 35);
            this.btnAddUser.TabIndex = 39;
            this.btnAddUser.Text = "Add user";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // checkPassword
            // 
            this.checkPassword.AutoSize = true;
            this.checkPassword.Location = new System.Drawing.Point(602, 341);
            this.checkPassword.Name = "checkPassword";
            this.checkPassword.Size = new System.Drawing.Size(18, 17);
            this.checkPassword.TabIndex = 40;
            this.checkPassword.UseVisualStyleBackColor = true;
            this.checkPassword.CheckedChanged += new System.EventHandler(this.checkPassword_CheckedChanged);
            // 
            // checkPasswordConfirm
            // 
            this.checkPasswordConfirm.AutoSize = true;
            this.checkPasswordConfirm.Location = new System.Drawing.Point(602, 422);
            this.checkPasswordConfirm.Name = "checkPasswordConfirm";
            this.checkPasswordConfirm.Size = new System.Drawing.Size(18, 17);
            this.checkPasswordConfirm.TabIndex = 41;
            this.checkPasswordConfirm.UseVisualStyleBackColor = true;
            this.checkPasswordConfirm.CheckedChanged += new System.EventHandler(this.checkPasswordConfirm_CheckedChanged);
            // 
            // lblGeneratePass
            // 
            this.lblGeneratePass.AutoSize = true;
            this.lblGeneratePass.LinkColor = System.Drawing.Color.SlateBlue;
            this.lblGeneratePass.Location = new System.Drawing.Point(464, 362);
            this.lblGeneratePass.Name = "lblGeneratePass";
            this.lblGeneratePass.Size = new System.Drawing.Size(132, 17);
            this.lblGeneratePass.TabIndex = 42;
            this.lblGeneratePass.TabStop = true;
            this.lblGeneratePass.Text = "Generate password";
            this.lblGeneratePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGeneratePass_LinkClicked);
            // 
            // errorUser
            // 
            this.errorUser.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(63, 529);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 35);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 604);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblGeneratePass);
            this.Controls.Add(this.checkPasswordConfirm);
            this.Controls.Add(this.checkPassword);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbUserType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.Prezime);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFirstName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUserAdd";
            this.Load += new System.EventHandler(this.frmUserAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Prezime;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbUserType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.CheckBox checkPassword;
        private System.Windows.Forms.CheckBox checkPasswordConfirm;
        private System.Windows.Forms.LinkLabel lblGeneratePass;
        private System.Windows.Forms.ErrorProvider errorUser;
        private System.Windows.Forms.Button btnDelete;
    }
}