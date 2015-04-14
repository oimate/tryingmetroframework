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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tabsMain = new MetroFramework.Controls.MetroTabControl();
            this.tabLogin = new MetroFramework.Controls.MetroTabPage();
            this.tabErp = new MetroFramework.Controls.MetroTabPage();
            this.tlpErp = new System.Windows.Forms.TableLayoutPanel();
            this.gridErp = new MetroFramework.Controls.MetroGrid();
            this.metroPanel1.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tabErp.SuspendLayout();
            this.tlpErp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErp)).BeginInit();
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
            this.tabsMain.Controls.Add(this.tabErp);
            this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMain.ItemSize = new System.Drawing.Size(100, 30);
            this.tabsMain.Location = new System.Drawing.Point(0, 0);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(790, 535);
            this.tabsMain.TabIndex = 1;
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
            // tabErp
            // 
            this.tabErp.Controls.Add(this.tlpErp);
            this.tabErp.HorizontalScrollbarBarColor = true;
            this.tabErp.HorizontalScrollbarHighlightOnWheel = false;
            this.tabErp.HorizontalScrollbarSize = 10;
            this.tabErp.Location = new System.Drawing.Point(4, 34);
            this.tabErp.Name = "tabErp";
            this.tabErp.Size = new System.Drawing.Size(782, 497);
            this.tabErp.TabIndex = 1;
            this.tabErp.Text = "View ERP";
            this.tabErp.VerticalScrollbarBarColor = true;
            this.tabErp.VerticalScrollbarHighlightOnWheel = false;
            this.tabErp.VerticalScrollbarSize = 10;
            // 
            // tlpErp
            // 
            this.tlpErp.BackColor = System.Drawing.Color.Transparent;
            this.tlpErp.ColumnCount = 2;
            this.tlpErp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpErp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpErp.Controls.Add(this.gridErp, 0, 1);
            this.tlpErp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpErp.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpErp.Location = new System.Drawing.Point(0, 0);
            this.tlpErp.Name = "tlpErp";
            this.tlpErp.RowCount = 2;
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpErp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpErp.Size = new System.Drawing.Size(782, 497);
            this.tlpErp.TabIndex = 3;
            // 
            // gridErp
            // 
            this.gridErp.AllowUserToAddRows = false;
            this.gridErp.AllowUserToDeleteRows = false;
            this.gridErp.AllowUserToOrderColumns = true;
            this.gridErp.AllowUserToResizeRows = false;
            this.gridErp.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridErp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridErp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridErp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridErp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridErp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridErp.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridErp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridErp.EnableHeadersVisualStyles = false;
            this.gridErp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridErp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridErp.Location = new System.Drawing.Point(3, 43);
            this.gridErp.Name = "gridErp";
            this.gridErp.ReadOnly = true;
            this.gridErp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridErp.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridErp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridErp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridErp.Size = new System.Drawing.Size(619, 451);
            this.gridErp.TabIndex = 3;
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
            this.tabErp.ResumeLayout(false);
            this.tlpErp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridErp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl tabsMain;
        private MetroFramework.Controls.MetroTabPage tabLogin;
        private MetroFramework.Controls.MetroTabPage tabErp;
        private System.Windows.Forms.TableLayoutPanel tlpErp;
        private MetroFramework.Controls.MetroGrid gridErp;





    }
}

