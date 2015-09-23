namespace metrostylegui
{
    partial class DmsForm_Main
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
            this.tableLayoutStatus = new System.Windows.Forms.TableLayoutPanel();
            this.tileFactory = new MetroFramework.Controls.MetroTile();
            this.tileERP = new MetroFramework.Controls.MetroTile();
            this.tileLoginLogout = new MetroFramework.Controls.MetroTile();
            this.tilePlcStatus = new MetroFramework.Controls.MetroTile();
            this.tileDatabaseStatus = new MetroFramework.Controls.MetroTile();
            this.bgCon = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutStatus
            // 
            this.tableLayoutStatus.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutStatus.ColumnCount = 4;
            this.tableLayoutStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutStatus.Controls.Add(this.tileFactory, 2, 9);
            this.tableLayoutStatus.Controls.Add(this.tileERP, 2, 8);
            this.tableLayoutStatus.Controls.Add(this.tileLoginLogout, 1, 2);
            this.tableLayoutStatus.Controls.Add(this.tilePlcStatus, 1, 5);
            this.tableLayoutStatus.Controls.Add(this.tileDatabaseStatus, 2, 5);
            this.tableLayoutStatus.Controls.Add(this.pictureBox1, 3, 0);
            this.tableLayoutStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStatus.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutStatus.Location = new System.Drawing.Point(5, 60);
            this.tableLayoutStatus.Name = "tableLayoutStatus";
            this.tableLayoutStatus.RowCount = 12;
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutStatus.Size = new System.Drawing.Size(790, 535);
            this.tableLayoutStatus.TabIndex = 1;
            // 
            // tileFactory
            // 
            this.tileFactory.ActiveControl = null;
            this.tileFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileFactory.Location = new System.Drawing.Point(398, 370);
            this.tileFactory.Name = "tileFactory";
            this.tileFactory.Size = new System.Drawing.Size(194, 34);
            this.tileFactory.Style = MetroFramework.MetroColorStyle.Purple;
            this.tileFactory.TabIndex = 5;
            this.tileFactory.Text = "Factory State";
            this.tileFactory.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tileFactory.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileFactory.UseSelectable = true;
            this.tileFactory.Visible = false;
            this.tileFactory.Click += new System.EventHandler(this.tileFactory_Click);
            // 
            // tileERP
            // 
            this.tileERP.ActiveControl = null;
            this.tileERP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileERP.Location = new System.Drawing.Point(398, 330);
            this.tileERP.Name = "tileERP";
            this.tileERP.Size = new System.Drawing.Size(194, 34);
            this.tileERP.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileERP.TabIndex = 4;
            this.tileERP.Text = "Production Data";
            this.tileERP.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tileERP.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileERP.UseSelectable = true;
            this.tileERP.Visible = false;
            this.tileERP.Click += new System.EventHandler(this.tileProduction_Click);
            // 
            // tileLoginLogout
            // 
            this.tileLoginLogout.ActiveControl = null;
            this.tableLayoutStatus.SetColumnSpan(this.tileLoginLogout, 2);
            this.tileLoginLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileLoginLogout.Location = new System.Drawing.Point(198, 130);
            this.tileLoginLogout.Name = "tileLoginLogout";
            this.tableLayoutStatus.SetRowSpan(this.tileLoginLogout, 2);
            this.tileLoginLogout.Size = new System.Drawing.Size(394, 74);
            this.tileLoginLogout.Style = MetroFramework.MetroColorStyle.Silver;
            this.tileLoginLogout.TabIndex = 3;
            this.tileLoginLogout.Text = "Login";
            this.tileLoginLogout.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileLoginLogout.UseSelectable = true;
            this.tileLoginLogout.Click += new System.EventHandler(this.tileLoginLogout_Click);
            // 
            // tilePlcStatus
            // 
            this.tilePlcStatus.ActiveControl = null;
            this.tilePlcStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePlcStatus.Location = new System.Drawing.Point(198, 230);
            this.tilePlcStatus.Name = "tilePlcStatus";
            this.tableLayoutStatus.SetRowSpan(this.tilePlcStatus, 2);
            this.tilePlcStatus.Size = new System.Drawing.Size(194, 74);
            this.tilePlcStatus.Style = MetroFramework.MetroColorStyle.Green;
            this.tilePlcStatus.TabIndex = 0;
            this.tilePlcStatus.Text = "PLC Status";
            this.tilePlcStatus.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tilePlcStatus.UseSelectable = true;
            this.tilePlcStatus.Click += new System.EventHandler(this.tilePlcStatus_Click);
            // 
            // tileDatabaseStatus
            // 
            this.tileDatabaseStatus.ActiveControl = null;
            this.tileDatabaseStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileDatabaseStatus.Location = new System.Drawing.Point(398, 230);
            this.tileDatabaseStatus.Name = "tileDatabaseStatus";
            this.tableLayoutStatus.SetRowSpan(this.tileDatabaseStatus, 2);
            this.tileDatabaseStatus.Size = new System.Drawing.Size(194, 74);
            this.tileDatabaseStatus.Style = MetroFramework.MetroColorStyle.Green;
            this.tileDatabaseStatus.TabIndex = 1;
            this.tileDatabaseStatus.Text = "Database Status";
            this.tileDatabaseStatus.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileDatabaseStatus.UseSelectable = true;
            this.tileDatabaseStatus.Click += new System.EventHandler(this.tileDatabaseStatus_Click);
            // 
            // bgCon
            // 
            this.bgCon.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCon_DoWork);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::metrostylegui.Properties.Resources.jaguarland;
            this.pictureBox1.Location = new System.Drawing.Point(598, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // DmsForm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutStatus);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DmsForm_Main";
            this.Padding = new System.Windows.Forms.Padding(5, 60, 5, 5);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "dms";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.tableLayoutStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutStatus;
        private MetroFramework.Controls.MetroTile tileLoginLogout;
        private MetroFramework.Controls.MetroTile tilePlcStatus;
        private MetroFramework.Controls.MetroTile tileDatabaseStatus;
        private MetroFramework.Controls.MetroTile tileFactory;
        private MetroFramework.Controls.MetroTile tileERP;
        private System.ComponentModel.BackgroundWorker bgCon;
        private System.Windows.Forms.PictureBox pictureBox1;






    }
}

