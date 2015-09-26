namespace metrostylegui
{
    partial class DmsForm_Filer
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
            this.tb_SkidNr = new MetroFramework.Controls.MetroTextBox();
            this.tb_LeftPlant = new MetroFramework.Controls.MetroCheckBox();
            this.cb_allUnitsOnPlant = new MetroFramework.Controls.MetroCheckBox();
            this.tb_BsnNr = new MetroFramework.Controls.MetroTextBox();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.metroDateTime2 = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // tb_SkidNr
            // 
            this.tb_SkidNr.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tb_SkidNr.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.tb_SkidNr.IconRight = true;
            this.tb_SkidNr.Lines = new string[] {
        "0"};
            this.tb_SkidNr.Location = new System.Drawing.Point(357, 144);
            this.tb_SkidNr.MaxLength = 32767;
            this.tb_SkidNr.Name = "tb_SkidNr";
            this.tb_SkidNr.PasswordChar = '\0';
            this.tb_SkidNr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_SkidNr.SelectedText = "";
            this.tb_SkidNr.Size = new System.Drawing.Size(155, 35);
            this.tb_SkidNr.TabIndex = 23;
            this.tb_SkidNr.Text = "0";
            this.tb_SkidNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_SkidNr.UseSelectable = true;
            this.tb_SkidNr.UseStyleColors = true;
            this.tb_SkidNr.TextChanged += new System.EventHandler(this.tbLoadL5X_TextChanged);
            // 
            // tb_LeftPlant
            // 
            this.tb_LeftPlant.AutoSize = true;
            this.tb_LeftPlant.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.tb_LeftPlant.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.tb_LeftPlant.Location = new System.Drawing.Point(26, 135);
            this.tb_LeftPlant.Name = "tb_LeftPlant";
            this.tb_LeftPlant.Size = new System.Drawing.Size(129, 19);
            this.tb_LeftPlant.TabIndex = 35;
            this.tb_LeftPlant.Text = "Units Left  plant";
            this.tb_LeftPlant.UseSelectable = true;
            this.tb_LeftPlant.CheckedChanged += new System.EventHandler(this.metroCheckBox7_CheckedChanged);
            // 
            // cb_allUnitsOnPlant
            // 
            this.cb_allUnitsOnPlant.AutoSize = true;
            this.cb_allUnitsOnPlant.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.cb_allUnitsOnPlant.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.cb_allUnitsOnPlant.Location = new System.Drawing.Point(26, 158);
            this.cb_allUnitsOnPlant.Name = "cb_allUnitsOnPlant";
            this.cb_allUnitsOnPlant.Size = new System.Drawing.Size(117, 19);
            this.cb_allUnitsOnPlant.TabIndex = 34;
            this.cb_allUnitsOnPlant.Text = "Units on Plant";
            this.cb_allUnitsOnPlant.UseSelectable = true;
            this.cb_allUnitsOnPlant.CheckedChanged += new System.EventHandler(this.metroCheckBox6_CheckedChanged);
            // 
            // tb_BsnNr
            // 
            this.tb_BsnNr.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tb_BsnNr.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.tb_BsnNr.IconRight = true;
            this.tb_BsnNr.Lines = new string[] {
        "0"};
            this.tb_BsnNr.Location = new System.Drawing.Point(175, 144);
            this.tb_BsnNr.MaxLength = 32767;
            this.tb_BsnNr.Name = "tb_BsnNr";
            this.tb_BsnNr.PasswordChar = '\0';
            this.tb_BsnNr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_BsnNr.SelectedText = "";
            this.tb_BsnNr.Size = new System.Drawing.Size(155, 35);
            this.tb_BsnNr.TabIndex = 38;
            this.tb_BsnNr.Text = "0";
            this.tb_BsnNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_BsnNr.UseSelectable = true;
            this.tb_BsnNr.UseStyleColors = true;
            this.tb_BsnNr.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Checked = false;
            this.metroDateTime1.Location = new System.Drawing.Point(40, 80);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.ShowCheckBox = true;
            this.metroDateTime1.Size = new System.Drawing.Size(213, 29);
            this.metroDateTime1.TabIndex = 39;
            this.metroDateTime1.ValueChanged += new System.EventHandler(this.metroDateTime1_ValueChanged);
            // 
            // metroDateTime2
            // 
            this.metroDateTime2.Checked = false;
            this.metroDateTime2.Location = new System.Drawing.Point(277, 80);
            this.metroDateTime2.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime2.Name = "metroDateTime2";
            this.metroDateTime2.ShowCheckBox = true;
            this.metroDateTime2.Size = new System.Drawing.Size(213, 29);
            this.metroDateTime2.TabIndex = 40;
            this.metroDateTime2.ValueChanged += new System.EventHandler(this.metroDateTime2_ValueChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(131, 53);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(28, 19);
            this.metroLabel1.TabIndex = 43;
            this.metroLabel1.Text = "Od";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(377, 51);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(26, 19);
            this.metroLabel2.TabIndex = 44;
            this.metroLabel2.Text = "Do";
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox2.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.metroTextBox2.IconRight = true;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(23, 63);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ReadOnly = true;
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.Size = new System.Drawing.Size(491, 60);
            this.metroTextBox2.TabIndex = 45;
            this.metroTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(231, 135);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(34, 19);
            this.metroLabel3.TabIndex = 47;
            this.metroLabel3.Text = "BSN";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(419, 135);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 19);
            this.metroLabel4.TabIndex = 48;
            this.metroLabel4.Text = "Skid Nr";
            // 
            // DmsForm_Filer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 198);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroDateTime2);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.tb_BsnNr);
            this.Controls.Add(this.tb_LeftPlant);
            this.Controls.Add(this.cb_allUnitsOnPlant);
            this.Controls.Add(this.tb_SkidNr);
            this.Controls.Add(this.metroTextBox2);
            this.Name = "DmsForm_Filer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "dms Filters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DmsForm_FactoryState_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tb_SkidNr;
        private MetroFramework.Controls.MetroCheckBox tb_LeftPlant;
        private MetroFramework.Controls.MetroCheckBox cb_allUnitsOnPlant;
        private MetroFramework.Controls.MetroTextBox tb_BsnNr;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroDateTime metroDateTime2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}