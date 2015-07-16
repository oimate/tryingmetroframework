namespace metrostylegui
{
    partial class DmsForm_Login
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
            this.bLogin = new MetroFramework.Controls.MetroButton();
            this.bCancel = new MetroFramework.Controls.MetroButton();
            this.tbUser = new MetroFramework.Controls.MetroTextBox();
            this.tbPwd = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(73, 191);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(144, 30);
            this.bLogin.Style = MetroFramework.MetroColorStyle.Green;
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "Login";
            this.bLogin.UseSelectable = true;
            this.bLogin.UseStyleColors = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(223, 191);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(104, 30);
            this.bCancel.Style = MetroFramework.MetroColorStyle.Green;
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseSelectable = true;
            this.bCancel.UseStyleColors = true;
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbUser.Lines = new string[0];
            this.tbUser.Location = new System.Drawing.Point(73, 113);
            this.tbUser.MaxLength = 32767;
            this.tbUser.Name = "tbUser";
            this.tbUser.PasswordChar = '\0';
            this.tbUser.PromptText = "user";
            this.tbUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbUser.SelectedText = "";
            this.tbUser.Size = new System.Drawing.Size(254, 30);
            this.tbUser.Style = MetroFramework.MetroColorStyle.Green;
            this.tbUser.TabIndex = 0;
            this.tbUser.UseSelectable = true;
            this.tbUser.UseStyleColors = true;
            // 
            // tbPwd
            // 
            this.tbPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPwd.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbPwd.Lines = new string[0];
            this.tbPwd.Location = new System.Drawing.Point(73, 152);
            this.tbPwd.MaxLength = 32767;
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '●';
            this.tbPwd.PromptText = "password";
            this.tbPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPwd.SelectedText = "";
            this.tbPwd.Size = new System.Drawing.Size(254, 30);
            this.tbPwd.Style = MetroFramework.MetroColorStyle.Green;
            this.tbPwd.TabIndex = 1;
            this.tbPwd.UseSelectable = true;
            this.tbPwd.UseStyleColors = true;
            this.tbPwd.UseSystemPasswordChar = true;
            // 
            // DmsLoginForm
            // 
            this.AcceptButton = this.bLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(400, 335);
            this.ControlBox = false;
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "DmsLoginForm";
            this.Resizable = false;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton bLogin;
        private MetroFramework.Controls.MetroButton bCancel;
        private MetroFramework.Controls.MetroTextBox tbUser;
        private MetroFramework.Controls.MetroTextBox tbPwd;
    }
}