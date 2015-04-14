namespace metrostylegui
{
    partial class MainForm
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tabsMain = new MetroFramework.Controls.MetroTabControl();
            this.tabLogin = new MetroFramework.Controls.MetroTabPage();
            this.tabStatus = new MetroFramework.Controls.MetroTabPage();
            this.tlpErp = new System.Windows.Forms.TableLayoutPanel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroPanel1.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.tlpErp.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.tabsMain);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(5, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(790, 535);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // tabsMain
            // 
            this.tabsMain.Controls.Add(this.tabLogin);
            this.tabsMain.Controls.Add(this.tabStatus);
            this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMain.ItemSize = new System.Drawing.Size(100, 30);
            this.tabsMain.Location = new System.Drawing.Point(0, 0);
            this.tabsMain.Multiline = true;
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 1;
            this.tabsMain.Size = new System.Drawing.Size(790, 535);
            this.tabsMain.TabIndex = 0;
            this.tabsMain.UseSelectable = true;
            this.tabsMain.UseStyleColors = true;
            // 
            // tabLogin
            // 
            this.tabLogin.HorizontalScrollbarBarColor = true;
            this.tabLogin.HorizontalScrollbarHighlightOnWheel = false;
            this.tabLogin.HorizontalScrollbarSize = 10;
            this.tabLogin.Location = new System.Drawing.Point(4, 34);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Size = new System.Drawing.Size(782, 497);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.VerticalScrollbarBarColor = true;
            this.tabLogin.VerticalScrollbarHighlightOnWheel = false;
            this.tabLogin.VerticalScrollbarSize = 10;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.tlpErp);
            this.tabStatus.HorizontalScrollbarBarColor = true;
            this.tabStatus.HorizontalScrollbarHighlightOnWheel = false;
            this.tabStatus.HorizontalScrollbarSize = 10;
            this.tabStatus.Location = new System.Drawing.Point(4, 34);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Size = new System.Drawing.Size(782, 497);
            this.tabStatus.TabIndex = 1;
            this.tabStatus.Text = "Status";
            this.tabStatus.VerticalScrollbarBarColor = true;
            this.tabStatus.VerticalScrollbarHighlightOnWheel = false;
            this.tabStatus.VerticalScrollbarSize = 10;
            // 
            // tlpErp
            // 
            this.tlpErp.BackColor = System.Drawing.Color.Transparent;
            this.tlpErp.ColumnCount = 4;
            this.tlpErp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpErp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpErp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpErp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpErp.Controls.Add(this.metroTile2, 2, 1);
            this.tlpErp.Controls.Add(this.metroTile1, 1, 1);
            this.tlpErp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpErp.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpErp.Location = new System.Drawing.Point(0, 0);
            this.tlpErp.Name = "tlpErp";
            this.tlpErp.RowCount = 6;
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpErp.Size = new System.Drawing.Size(782, 497);
            this.tlpErp.TabIndex = 0;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile1.Location = new System.Drawing.Point(194, 171);
            this.metroTile1.Name = "metroTile1";
            this.tlpErp.SetRowSpan(this.metroTile1, 4);
            this.metroTile1.Size = new System.Drawing.Size(194, 154);
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "PLC Status";
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseStyleColors = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile2.Location = new System.Drawing.Point(394, 171);
            this.metroTile2.Name = "metroTile2";
            this.tlpErp.SetRowSpan(this.metroTile2, 4);
            this.metroTile2.Size = new System.Drawing.Size(194, 154);
            this.metroTile2.TabIndex = 1;
            this.metroTile2.Text = "Database Status";
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseStyleColors = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5, 60, 5, 5);
            this.Text = "dms";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.metroPanel1.ResumeLayout(false);
            this.tabsMain.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.tlpErp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl tabsMain;
        private MetroFramework.Controls.MetroTabPage tabLogin;
        private MetroFramework.Controls.MetroTabPage tabStatus;
        private System.Windows.Forms.TableLayoutPanel tlpErp;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile1;





    }
}

