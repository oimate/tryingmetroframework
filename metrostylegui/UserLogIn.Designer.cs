namespace metrostylegui
{
    partial class UserLogIn
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
            this.lLogin = new MetroFramework.Controls.MetroLabel();
            this.lPwd = new MetroFramework.Controls.MetroLabel();
            this.tLogin = new MetroFramework.Controls.MetroTextBox();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.tPwd = new MetroFramework.Controls.MetroTextBox();
            this.bLogIn = new MetroFramework.Controls.MetroButton();
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
            this.tableLayoutPanel1.Controls.Add(this.lLogin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lPwd, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tLogin, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.metroProgressSpinner1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tPwd, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.bLogIn, 2, 4);
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
            // lLogin
            // 
            this.lLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lLogin.Location = new System.Drawing.Point(150, 64);
            this.lLogin.Margin = new System.Windows.Forms.Padding(0);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(90, 22);
            this.lLogin.TabIndex = 12;
            this.lLogin.Text = "Login:";
            this.lLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLogin.UseStyleColors = true;
            // 
            // lPwd
            // 
            this.lPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lPwd.Location = new System.Drawing.Point(150, 94);
            this.lPwd.Margin = new System.Windows.Forms.Padding(0);
            this.lPwd.Name = "lPwd";
            this.lPwd.Size = new System.Drawing.Size(90, 22);
            this.lPwd.TabIndex = 4;
            this.lPwd.Text = "Password:";
            this.lPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lPwd.UseStyleColors = true;
            // 
            // tLogin
            // 
            this.tLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tLogin.Lines = new string[0];
            this.tLogin.Location = new System.Drawing.Point(240, 64);
            this.tLogin.Margin = new System.Windows.Forms.Padding(0);
            this.tLogin.MaxLength = 32767;
            this.tLogin.Name = "tLogin";
            this.tLogin.PasswordChar = '\0';
            this.tLogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tLogin.SelectedText = "";
            this.tLogin.Size = new System.Drawing.Size(210, 22);
            this.tLogin.TabIndex = 10;
            this.tLogin.UseSelectable = true;
            this.tLogin.UseStyleColors = true;
            this.tLogin.WordWrap = false;
            this.tLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tLogin_KeyPress);
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroProgressSpinner1.Location = new System.Drawing.Point(474, 63);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.tableLayoutPanel1.SetRowSpan(this.metroProgressSpinner1, 3);
            this.metroProgressSpinner1.Size = new System.Drawing.Size(102, 84);
            this.metroProgressSpinner1.TabIndex = 6;
            this.metroProgressSpinner1.TabStop = false;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.UseStyleColors = true;
            this.metroProgressSpinner1.Visible = false;
            // 
            // tPwd
            // 
            this.tPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tPwd.Lines = new string[0];
            this.tPwd.Location = new System.Drawing.Point(240, 94);
            this.tPwd.Margin = new System.Windows.Forms.Padding(0);
            this.tPwd.MaxLength = 32767;
            this.tPwd.Name = "tPwd";
            this.tPwd.PasswordChar = '*';
            this.tPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tPwd.SelectedText = "";
            this.tPwd.Size = new System.Drawing.Size(210, 22);
            this.tPwd.TabIndex = 11;
            this.tPwd.UseSelectable = true;
            this.tPwd.UseStyleColors = true;
            this.tPwd.WordWrap = false;
            this.tPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tLogin_KeyPress);
            // 
            // bLogIn
            // 
            this.bLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bLogIn.BackColor = System.Drawing.Color.ForestGreen;
            this.bLogIn.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.bLogIn.Location = new System.Drawing.Point(243, 124);
            this.bLogIn.Name = "bLogIn";
            this.bLogIn.Size = new System.Drawing.Size(204, 22);
            this.bLogIn.TabIndex = 0;
            this.bLogIn.Text = "log in";
            this.bLogIn.UseSelectable = true;
            this.bLogIn.UseStyleColors = true;
            this.bLogIn.Click += new System.EventHandler(this.bLogIn_Click);
            // 
            // UserLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelbody);
            this.Name = "UserLogIn";
            this.Size = new System.Drawing.Size(600, 242);
            this.panelbody.ResumeLayout(false);
            this.panelbody.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbody;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton bLogIn;
        private MetroFramework.Controls.MetroLabel lPwd;
        private MetroFramework.Controls.MetroTextBox tPwd;
        private MetroFramework.Controls.MetroTextBox tLogin;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroLabel lLogin;


    }
}
