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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panFilters = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bTxt = new MetroFramework.Controls.MetroButton();
            this.bFilters = new MetroFramework.Controls.MetroButton();
            this.bSearch = new MetroFramework.Controls.MetroButton();
            this.panTable = new MetroFramework.Controls.MetroPanel();
            this.gridProductionData = new MetroFramework.Controls.MetroGrid();
            this.panFilters.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductionData)).BeginInit();
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
            this.panFilters.Size = new System.Drawing.Size(1001, 33);
            this.panFilters.Style = MetroFramework.MetroColorStyle.Blue;
            this.panFilters.TabIndex = 0;
            this.panFilters.UseStyleColors = true;
            this.panFilters.VerticalScrollbarBarColor = true;
            this.panFilters.VerticalScrollbarHighlightOnWheel = false;
            this.panFilters.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bTxt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.bFilters, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.bSearch, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 33);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // bTxt
            // 
            this.bTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bTxt.Enabled = false;
            this.bTxt.Location = new System.Drawing.Point(812, 3);
            this.bTxt.Name = "bTxt";
            this.bTxt.Size = new System.Drawing.Size(58, 27);
            this.bTxt.Style = MetroFramework.MetroColorStyle.Orange;
            this.bTxt.TabIndex = 1;
            this.bTxt.Text = "Save";
            this.bTxt.UseSelectable = true;
            this.bTxt.UseStyleColors = true;
            this.bTxt.Click += new System.EventHandler(this.bTxt_Click);
            // 
            // bFilters
            // 
            this.bFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bFilters.Location = new System.Drawing.Point(876, 3);
            this.bFilters.Name = "bFilters";
            this.bFilters.Size = new System.Drawing.Size(58, 27);
            this.bFilters.Style = MetroFramework.MetroColorStyle.Blue;
            this.bFilters.TabIndex = 2;
            this.bFilters.Text = "Filters";
            this.bFilters.UseSelectable = true;
            this.bFilters.UseStyleColors = true;
            this.bFilters.Click += new System.EventHandler(this.bFilters_Click);
            // 
            // bSearch
            // 
            this.bSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bSearch.Location = new System.Drawing.Point(940, 3);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(58, 27);
            this.bSearch.Style = MetroFramework.MetroColorStyle.Green;
            this.bSearch.TabIndex = 3;
            this.bSearch.Text = "Search";
            this.bSearch.UseSelectable = true;
            this.bSearch.UseStyleColors = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
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
            this.panTable.Size = new System.Drawing.Size(1001, 649);
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
            this.gridProductionData.Size = new System.Drawing.Size(1001, 649);
            this.gridProductionData.Style = MetroFramework.MetroColorStyle.Blue;
            this.gridProductionData.TabIndex = 0;
            this.gridProductionData.UseStyleColors = true;
            // 
            // DmsForm_ProductionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 762);
            this.Controls.Add(this.panTable);
            this.Controls.Add(this.panFilters);
            this.Name = "DmsForm_ProductionData";
            this.Text = "dms Production Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DmsERP_FormClosing);
            this.panFilters.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProductionData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panFilters;
        private MetroFramework.Controls.MetroPanel panTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton bSearch;
        private MetroFramework.Controls.MetroGrid gridProductionData;
        private MetroFramework.Controls.MetroButton bTxt;
        private MetroFramework.Controls.MetroButton bFilters;
    }
}