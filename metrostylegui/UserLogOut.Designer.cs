namespace metrostylegui
{
    partial class UserLogOut
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelbody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lLogAs = new MetroFramework.Controls.MetroLabel();
            this.lUserName = new MetroFramework.Controls.MetroLabel();
            this.bLogOut = new MetroFramework.Controls.MetroButton();
            this.panelbody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbody
            // 
            this.panelbody.BackColor = System.Drawing.Color.Transparent;
            this.panelbody.Controls.Add(this.tableLayoutPanel1);
            this.panelbody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbody.Location = new System.Drawing.Point(0, 0);
            this.panelbody.Margin = new System.Windows.Forms.Padding(0);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(600, 242);
            this.panelbody.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lLogAs, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.bLogOut, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lUserName, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 242);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lLogAs
            // 
            this.lLogAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lLogAs.Location = new System.Drawing.Point(150, 64);
            this.lLogAs.Margin = new System.Windows.Forms.Padding(0);
            this.lLogAs.Name = "lLogAs";
            this.lLogAs.Size = new System.Drawing.Size(90, 22);
            this.lLogAs.TabIndex = 14;
            this.lLogAs.Text = "Logged as:";
            this.lLogAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLogAs.UseStyleColors = true;
            // 
            // lUserName
            // 
            this.lUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lUserName.Location = new System.Drawing.Point(240, 64);
            this.lUserName.Margin = new System.Windows.Forms.Padding(0);
            this.lUserName.Name = "lUserName";
            this.lUserName.Size = new System.Drawing.Size(210, 22);
            this.lUserName.TabIndex = 15;
            this.lUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lUserName.UseStyleColors = true;
            // 
            // bLogOut
            // 
            this.bLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bLogOut.BackColor = System.Drawing.Color.ForestGreen;
            this.bLogOut.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.bLogOut.Location = new System.Drawing.Point(243, 124);
            this.bLogOut.Name = "bLogOut";
            this.bLogOut.Size = new System.Drawing.Size(204, 22);
            this.bLogOut.TabIndex = 16;
            this.bLogOut.Text = "log out";
            this.bLogOut.UseSelectable = true;
            this.bLogOut.Click += new System.EventHandler(this.bLogOut_Click);
            // 
            // UserLogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelbody);
            this.Name = "UserLogOut";
            this.Size = new System.Drawing.Size(600, 242);
            this.panelbody.ResumeLayout(false);
            this.panelbody.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbody;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lLogAs;
        private MetroFramework.Controls.MetroLabel lUserName;
        private MetroFramework.Controls.MetroButton bLogOut;


    }
}
