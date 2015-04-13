namespace metrostylegui
{
    partial class UserControl1
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bLog = new MetroFramework.Controls.MetroButton();
            this.lLogin = new MetroFramework.Controls.MetroLabel();
            this.lPwd = new MetroFramework.Controls.MetroLabel();
            this.tPwd = new MetroFramework.Controls.MetroTextBox();
            this.tLogin = new MetroFramework.Controls.MetroTextBox();
            this.panelbody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.panelbody.Size = new System.Drawing.Size(600, 110);
            this.panelbody.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lLogin, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lPwd, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tPwd, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tLogin, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 110);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.bLog, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(150, 80);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 30);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // bLog
            // 
            this.bLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bLog.BackColor = System.Drawing.Color.ForestGreen;
            this.bLog.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.bLog.Location = new System.Drawing.Point(153, 4);
            this.bLog.Name = "bLog";
            this.bLog.Size = new System.Drawing.Size(144, 22);
            this.bLog.TabIndex = 0;
            this.bLog.Text = "Login!";
            this.bLog.UseSelectable = true;
            this.bLog.Click += new System.EventHandler(this.bLog_Click);
            // 
            // lLogin
            // 
            this.lLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lLogin.Location = new System.Drawing.Point(150, 24);
            this.lLogin.Margin = new System.Windows.Forms.Padding(0);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(100, 22);
            this.lLogin.TabIndex = 6;
            this.lLogin.Text = "Login:";
            this.lLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLogin.UseStyleColors = true;
            // 
            // lPwd
            // 
            this.lPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lPwd.Location = new System.Drawing.Point(150, 54);
            this.lPwd.Margin = new System.Windows.Forms.Padding(0);
            this.lPwd.Name = "lPwd";
            this.lPwd.Size = new System.Drawing.Size(100, 22);
            this.lPwd.TabIndex = 7;
            this.lPwd.Text = "Password:";
            this.lPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lPwd.UseStyleColors = true;
            // 
            // tPwd
            // 
            this.tPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tPwd.Lines = new string[0];
            this.tPwd.Location = new System.Drawing.Point(250, 54);
            this.tPwd.Margin = new System.Windows.Forms.Padding(0);
            this.tPwd.MaxLength = 32767;
            this.tPwd.Name = "tPwd";
            this.tPwd.PasswordChar = '\0';
            this.tPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tPwd.SelectedText = "";
            this.tPwd.Size = new System.Drawing.Size(200, 22);
            this.tPwd.TabIndex = 1;
            this.tPwd.UseSelectable = true;
            this.tPwd.UseStyleColors = true;
            this.tPwd.WordWrap = false;
            this.tPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tLogin_KeyPress);
            // 
            // tLogin
            // 
            this.tLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tLogin.Lines = new string[0];
            this.tLogin.Location = new System.Drawing.Point(250, 24);
            this.tLogin.Margin = new System.Windows.Forms.Padding(0);
            this.tLogin.MaxLength = 32767;
            this.tLogin.Name = "tLogin";
            this.tLogin.PasswordChar = '\0';
            this.tLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tLogin.SelectedText = "";
            this.tLogin.Size = new System.Drawing.Size(200, 22);
            this.tLogin.TabIndex = 0;
            this.tLogin.UseSelectable = true;
            this.tLogin.UseStyleColors = true;
            this.tLogin.WordWrap = false;
            this.tLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tLogin_KeyPress);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelbody);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(600, 110);
            this.panelbody.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbody;
        private MetroFramework.Controls.MetroButton bLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lLogin;
        private MetroFramework.Controls.MetroLabel lPwd;
        private MetroFramework.Controls.MetroTextBox tPwd;
        private MetroFramework.Controls.MetroTextBox tLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;


    }
}
