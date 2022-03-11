
namespace PerfectSound.WinForms.Forms
{
    partial class frmVerseAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveVerse = new System.Windows.Forms.Button();
            this.txtVerse = new System.Windows.Forms.TextBox();
            this.comboBoxSAPforVerse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Verse";
            // 
            // btnSaveVerse
            // 
            this.btnSaveVerse.BackColor = System.Drawing.Color.SlateBlue;
            this.btnSaveVerse.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSaveVerse.Location = new System.Drawing.Point(393, 253);
            this.btnSaveVerse.Name = "btnSaveVerse";
            this.btnSaveVerse.Size = new System.Drawing.Size(166, 35);
            this.btnSaveVerse.TabIndex = 19;
            this.btnSaveVerse.Text = "Save";
            this.btnSaveVerse.UseVisualStyleBackColor = false;
            this.btnSaveVerse.Click += new System.EventHandler(this.btnSaveVerse_Click);
            // 
            // txtVerse
            // 
            this.txtVerse.Location = new System.Drawing.Point(12, 66);
            this.txtVerse.Name = "txtVerse";
            this.txtVerse.Size = new System.Drawing.Size(546, 22);
            this.txtVerse.TabIndex = 0;
            // 
            // comboBoxSAPforVerse
            // 
            this.comboBoxSAPforVerse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSAPforVerse.FormattingEnabled = true;
            this.comboBoxSAPforVerse.Location = new System.Drawing.Point(12, 147);
            this.comboBoxSAPforVerse.Name = "comboBoxSAPforVerse";
            this.comboBoxSAPforVerse.Size = new System.Drawing.Size(546, 24);
            this.comboBoxSAPforVerse.TabIndex = 20;
            this.comboBoxSAPforVerse.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBoxSAPforVerse_Format);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Choose the song that contains the verse";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmVerseAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 300);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSAPforVerse);
            this.Controls.Add(this.btnSaveVerse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVerse);
            this.Name = "frmVerseAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add verse";
            this.Load += new System.EventHandler(this.frmVerseAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveVerse;
        private System.Windows.Forms.TextBox txtVerse;
        private System.Windows.Forms.ComboBox comboBoxSAPforVerse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}