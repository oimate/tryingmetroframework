namespace metrostylegui
{
    partial class DmsForm_ProductionData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panFilters = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_BsnNr = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dt_timeStart = new MetroFramework.Controls.MetroDateTime();
            this.dt_timeEnd = new MetroFramework.Controls.MetroDateTime();
            this.bSearch = new MetroFramework.Controls.MetroButton();
            this.tb_SkindNr = new MetroFramework.Controls.MetroTextBox();
            this.bTSaveToPDF = new MetroFramework.Controls.MetroButton();
            this.bt_resetfilter = new MetroFramework.Controls.MetroButton();
            this.panTable = new MetroFramework.Controls.MetroPanel();
            this.gridProductionData = new MetroFramework.Controls.MetroGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showUnitOnMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_searchinfo = new System.Windows.Forms.Label();
            this.t_filtercheck = new System.Windows.Forms.Timer(this.components);
            this.panFilters.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductionData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panFilters
            // 
            this.panFilters.Controls.Add(this.tableLayoutPanel1);
            this.panFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panFilters.HorizontalScrollbarBarColor = true;
            this.panFilters.HorizontalScrollbarHighlightOnWheel = false;
            this.panFilters.HorizontalScrollbarSize = 10;
            this.panFilters.Location = new System.Drawing.Point(20, 60);
            this.panFilters.Name = "panFilters";
            this.panFilters.Size = new System.Drawing.Size(1104, 33);
            this.panFilters.Style = MetroFramework.MetroColorStyle.Blue;
            this.panFilters.TabIndex = 0;
            this.panFilters.UseStyleColors = true;
            this.panFilters.VerticalScrollbarBarColor = true;
            this.panFilters.VerticalScrollbarHighlightOnWheel = false;
            this.panFilters.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 17;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.tb_BsnNr, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dt_timeStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dt_timeEnd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bSearch, 16, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_SkindNr, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.bTSaveToPDF, 15, 0);
            this.tableLayoutPanel1.Controls.Add(this.bt_resetfilter, 12, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 33);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tb_BsnNr
            // 
            this.tb_BsnNr.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tb_BsnNr.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.tb_BsnNr.IconRight = true;
            this.tb_BsnNr.Lines = new string[] {
        "0"};
            this.tb_BsnNr.Location = new System.Drawing.Point(412, 2);
            this.tb_BsnNr.Margin = new System.Windows.Forms.Padding(2);
            this.tb_BsnNr.MaxLength = 32767;
            this.tb_BsnNr.Name = "tb_BsnNr";
            this.tb_BsnNr.PasswordChar = '\0';
            this.tb_BsnNr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_BsnNr.SelectedText = "";
            this.tb_BsnNr.Size = new System.Drawing.Size(86, 29);
            this.tb_BsnNr.TabIndex = 50;
            this.tb_BsnNr.Text = "0";
            this.tb_BsnNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_BsnNr.UseSelectable = true;
            this.tb_BsnNr.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(503, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 33);
            this.metroLabel1.TabIndex = 49;
            this.metroLabel1.Text = "Skid Nr";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(343, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 33);
            this.metroLabel3.TabIndex = 48;
            this.metroLabel3.Text = "BSN Nr";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.UseMnemonic = false;
            // 
            // dt_timeStart
            // 
            this.dt_timeStart.Checked = false;
            this.dt_timeStart.Location = new System.Drawing.Point(3, 3);
            this.dt_timeStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dt_timeStart.Name = "dt_timeStart";
            this.dt_timeStart.ShowCheckBox = true;
            this.dt_timeStart.Size = new System.Drawing.Size(164, 29);
            this.dt_timeStart.TabIndex = 41;
            // 
            // dt_timeEnd
            // 
            this.dt_timeEnd.Checked = false;
            this.dt_timeEnd.Location = new System.Drawing.Point(173, 3);
            this.dt_timeEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dt_timeEnd.Name = "dt_timeEnd";
            this.dt_timeEnd.ShowCheckBox = true;
            this.dt_timeEnd.Size = new System.Drawing.Size(164, 29);
            this.dt_timeEnd.TabIndex = 40;
            // 
            // bSearch
            // 
            this.bSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bSearch.Location = new System.Drawing.Point(957, 3);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(144, 27);
            this.bSearch.Style = MetroFramework.MetroColorStyle.Green;
            this.bSearch.TabIndex = 3;
            this.bSearch.Text = "Search";
            this.bSearch.UseSelectable = true;
            this.bSearch.UseStyleColors = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // tb_SkindNr
            // 
            this.tb_SkindNr.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tb_SkindNr.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.tb_SkindNr.IconRight = true;
            this.tb_SkindNr.Lines = new string[] {
        "0"};
            this.tb_SkindNr.Location = new System.Drawing.Point(572, 2);
            this.tb_SkindNr.Margin = new System.Windows.Forms.Padding(2);
            this.tb_SkindNr.MaxLength = 32767;
            this.tb_SkindNr.Name = "tb_SkindNr";
            this.tb_SkindNr.PasswordChar = '\0';
            this.tb_SkindNr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_SkindNr.SelectedText = "";
            this.tb_SkindNr.Size = new System.Drawing.Size(86, 29);
            this.tb_SkindNr.TabIndex = 42;
            this.tb_SkindNr.Text = "0";
            this.tb_SkindNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_SkindNr.UseSelectable = true;
            this.tb_SkindNr.UseStyleColors = true;
            // 
            // bTSaveToPDF
            // 
            this.bTSaveToPDF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bTSaveToPDF.Enabled = false;
            this.bTSaveToPDF.Location = new System.Drawing.Point(866, 3);
            this.bTSaveToPDF.Name = "bTSaveToPDF";
            this.bTSaveToPDF.Size = new System.Drawing.Size(85, 27);
            this.bTSaveToPDF.Style = MetroFramework.MetroColorStyle.Orange;
            this.bTSaveToPDF.TabIndex = 1;
            this.bTSaveToPDF.Text = "Save to PDF";
            this.bTSaveToPDF.UseSelectable = true;
            this.bTSaveToPDF.UseStyleColors = true;
            this.bTSaveToPDF.Click += new System.EventHandler(this.bTxt_Click);
            // 
            // bt_resetfilter
            // 
            this.bt_resetfilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_resetfilter.Location = new System.Drawing.Point(691, 3);
            this.bt_resetfilter.Name = "bt_resetfilter";
            this.bt_resetfilter.Size = new System.Drawing.Size(94, 27);
            this.bt_resetfilter.Style = MetroFramework.MetroColorStyle.Silver;
            this.bt_resetfilter.TabIndex = 51;
            this.bt_resetfilter.Text = "Reset Filter";
            this.bt_resetfilter.UseSelectable = true;
            this.bt_resetfilter.UseStyleColors = true;
            this.bt_resetfilter.Visible = false;
            this.bt_resetfilter.Click += new System.EventHandler(this.b_resetfilter_Click);
            // 
            // panTable
            // 
            this.panTable.Controls.Add(this.gridProductionData);
            this.panTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTable.HorizontalScrollbarBarColor = true;
            this.panTable.HorizontalScrollbarHighlightOnWheel = false;
            this.panTable.HorizontalScrollbarSize = 10;
            this.panTable.Location = new System.Drawing.Point(20, 93);
            this.panTable.Name = "panTable";
            this.panTable.Size = new System.Drawing.Size(1104, 667);
            this.panTable.Style = MetroFramework.MetroColorStyle.Blue;
            this.panTable.TabIndex = 3;
            this.panTable.UseStyleColors = true;
            this.panTable.VerticalScrollbarBarColor = true;
            this.panTable.VerticalScrollbarHighlightOnWheel = false;
            this.panTable.VerticalScrollbarSize = 10;
            // 
            // gridProductionData
            // 
            this.gridProductionData.AllowUserToAddRows = false;
            this.gridProductionData.AllowUserToDeleteRows = false;
            this.gridProductionData.AllowUserToResizeRows = false;
            this.gridProductionData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridProductionData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridProductionData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridProductionData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.gridProductionData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProductionData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProductionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProductionData.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridProductionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProductionData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridProductionData.EnableHeadersVisualStyles = false;
            this.gridProductionData.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridProductionData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridProductionData.Location = new System.Drawing.Point(0, 0);
            this.gridProductionData.MultiSelect = false;
            this.gridProductionData.Name = "gridProductionData";
            this.gridProductionData.ReadOnly = true;
            this.gridProductionData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProductionData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridProductionData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridProductionData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProductionData.Size = new System.Drawing.Size(1104, 667);
            this.gridProductionData.Style = MetroFramework.MetroColorStyle.Blue;
            this.gridProductionData.TabIndex = 0;
            this.gridProductionData.UseStyleColors = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.showUnitOnMapToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::metrostylegui.Properties.Resources.edit_enable;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem1.Text = "Selected Row";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::metrostylegui.Properties.Resources.unselect_all;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.removeToolStripMenuItem.Text = "Remove from DB";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::metrostylegui.Properties.Resources.pdf3_logo;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveToolStripMenuItem.Text = "Save to PDF";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // showUnitOnMapToolStripMenuItem
            // 
            this.showUnitOnMapToolStripMenuItem.Image = global::metrostylegui.Properties.Resources.celownik;
            this.showUnitOnMapToolStripMenuItem.Name = "showUnitOnMapToolStripMenuItem";
            this.showUnitOnMapToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showUnitOnMapToolStripMenuItem.Text = "Show unit on Map";
            this.showUnitOnMapToolStripMenuItem.Click += new System.EventHandler(this.showUnitOnMapToolStripMenuItem_Click);
            // 
            // lb_searchinfo
            // 
            this.lb_searchinfo.AutoSize = true;
            this.lb_searchinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_searchinfo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lb_searchinfo.Location = new System.Drawing.Point(677, 27);
            this.lb_searchinfo.Name = "lb_searchinfo";
            this.lb_searchinfo.Size = new System.Drawing.Size(0, 20);
            this.lb_searchinfo.TabIndex = 53;
            // 
            // t_filtercheck
            // 
            this.t_filtercheck.Enabled = true;
            this.t_filtercheck.Interval = 500;
            this.t_filtercheck.Tick += new System.EventHandler(this.t_filtercheck_Tick);
            // 
            // DmsForm_ProductionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 780);
            this.Controls.Add(this.lb_searchinfo);
            this.Controls.Add(this.panTable);
            this.Controls.Add(this.panFilters);
            this.Name = "DmsForm_ProductionData";
            this.Text = "dms Production Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DmsERP_FormClosing);
            this.panFilters.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProductionData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panFilters;
        private MetroFramework.Controls.MetroPanel panTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton bSearch;
        private MetroFramework.Controls.MetroGrid gridProductionData;
        private MetroFramework.Controls.MetroButton bTSaveToPDF;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private MetroFramework.Controls.MetroDateTime dt_timeStart;
        private MetroFramework.Controls.MetroDateTime dt_timeEnd;
        private MetroFramework.Controls.MetroTextBox tb_SkindNr;
        private MetroFramework.Controls.MetroTextBox tb_BsnNr;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showUnitOnMapToolStripMenuItem;
        private System.Windows.Forms.Label lb_searchinfo;
        private MetroFramework.Controls.MetroButton bt_resetfilter;
        private System.Windows.Forms.Timer t_filtercheck;
    }
}