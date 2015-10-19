namespace metrostylegui
{
    partial class DmsForm_Overview
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tb_SkindNr = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tb_Place = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::metrostylegui.Properties.Resources.jaguarOverview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1253, 674);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(1064, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(52, 19);
            this.metroLabel1.TabIndex = 51;
            this.metroLabel1.Text = "Skid Nr";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_SkindNr
            // 
            this.tb_SkindNr.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_SkindNr.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.tb_SkindNr.IconRight = true;
            this.tb_SkindNr.Lines = new string[] {
        "0"};
            this.tb_SkindNr.Location = new System.Drawing.Point(1120, 24);
            this.tb_SkindNr.Margin = new System.Windows.Forms.Padding(2);
            this.tb_SkindNr.MaxLength = 32767;
            this.tb_SkindNr.Name = "tb_SkindNr";
            this.tb_SkindNr.PasswordChar = '\0';
            this.tb_SkindNr.ReadOnly = true;
            this.tb_SkindNr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_SkindNr.SelectedText = "";
            this.tb_SkindNr.Size = new System.Drawing.Size(50, 25);
            this.tb_SkindNr.TabIndex = 50;
            this.tb_SkindNr.Text = "0";
            this.tb_SkindNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_SkindNr.UseSelectable = true;
            this.tb_SkindNr.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(1171, 27);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(40, 19);
            this.metroLabel2.TabIndex = 53;
            this.metroLabel2.Text = "Place";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Place
            // 
            this.tb_Place.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_Place.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.tb_Place.IconRight = true;
            this.tb_Place.Lines = new string[] {
        "0"};
            this.tb_Place.Location = new System.Drawing.Point(1215, 24);
            this.tb_Place.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Place.MaxLength = 32767;
            this.tb_Place.Name = "tb_Place";
            this.tb_Place.PasswordChar = '\0';
            this.tb_Place.ReadOnly = true;
            this.tb_Place.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_Place.SelectedText = "";
            this.tb_Place.Size = new System.Drawing.Size(50, 25);
            this.tb_Place.TabIndex = 52;
            this.tb_Place.Text = "0";
            this.tb_Place.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Place.UseSelectable = true;
            this.tb_Place.UseStyleColors = true;
            // 
            // DmsForm_Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 738);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.tb_Place);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tb_SkindNr);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DmsForm_Overview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "dms Overview ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DmsForm_FactoryState_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox tb_SkindNr;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox tb_Place;

    }
}