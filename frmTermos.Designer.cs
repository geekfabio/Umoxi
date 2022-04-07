
namespace Umoxi
{
    partial class frmTermos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTermos));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelProductName = new DevExpress.XtraEditors.LabelControl();
            this.labelVersion = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.richTextBox1.Location = new System.Drawing.Point(0, 89);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(800, 361);
            this.richTextBox1.TabIndex = 142;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.separatorControl1);
            this.panel1.Controls.Add(this.labelProductName);
            this.panel1.Controls.Add(this.labelVersion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 89);
            this.panel1.TabIndex = 144;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = global::Umoxi.Properties.Resources.logo_255px;
            this.pictureBox2.Image = global::Umoxi.Properties.Resources.logo_255px;
            this.pictureBox2.Location = new System.Drawing.Point(9, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 145;
            this.pictureBox2.TabStop = false;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(9, 67);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(669, 21);
            this.separatorControl1.TabIndex = 144;
            // 
            // labelProductName
            // 
            this.labelProductName.Appearance.Font = new System.Drawing.Font("Rubik", 13.25F);
            this.labelProductName.Appearance.Options.UseFont = true;
            this.labelProductName.Location = new System.Drawing.Point(79, 14);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(217, 23);
            this.labelProductName.TabIndex = 143;
            this.labelProductName.Text = "Umoxi - Gestão Hospitalar";
            // 
            // labelVersion
            // 
            this.labelVersion.Appearance.Font = new System.Drawing.Font("Rubik", 9.25F);
            this.labelVersion.Appearance.Options.UseFont = true;
            this.labelVersion.Location = new System.Drawing.Point(79, 43);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(73, 15);
            this.labelVersion.TabIndex = 142;
            this.labelVersion.Text = "Versão: 1.0.0";
            // 
            // frmTermos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTermos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Termos e Politica de Privacidade";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.LabelControl labelProductName;
        private DevExpress.XtraEditors.LabelControl labelVersion;
    }
}