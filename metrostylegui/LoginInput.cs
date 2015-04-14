﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace metrostylegui
{
    public partial class LoginInput : MetroUserControl
    {
        DmsDatabase.DmsUser user;
        public LoginInput()
        {
            InitializeComponent();
            this.ParentChanged += UserControl1_ParentChanged;
        }

        void UserControl1_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null && ParentForm != null)
            {
                Parent.Resize += Parent_Resize;
                Parent_Resize(sender, e);
            }
        }

        void Parent_Resize(object sender, EventArgs e)
        {
            if (ParentForm.WindowState != FormWindowState.Minimized)
            {
                this.Top = (Parent.Height - this.Height) / 2;
                this.Left = (Parent.Width - this.Width) / 2;
            }
        }

        public string Login { get { return tLogin.Text; } }
        public string Pwd { get { return tPwd.Text; } }

        private async void bLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Pwd)) return;

            LoginInProggres(true);

            user = await Task<DmsDatabase.DmsUser>.Run(() => DmsDatabase.DmsUser.GetUser(Login, Pwd));
            LogState ls = (user != null) ? LogState.LoginOK : LogState.LoginNOK;
            OnUserChanged(user, ls);
            //if (user != null) this.Parent.Controls.Remove(this);
        }

        private void LoginInProggres(bool p)
        {
            metroProgressSpinner1.Visible = p;
            bLog.Enabled = !p;
            tLogin.Enabled = !p;
            tPwd.Enabled = !p;
        }

        public event EventHandler<UserChangedArgs> UserChanged;
        private void OnUserChanged(DmsDatabase.DmsUser user, LogState logstate)
        {
            LoginInProggres(false);
            if (UserChanged != null)
            {
                switch (logstate)
                {
                    case LogState.LoginOK:
                        UserChanged(this, new UserChangedArgs() { User = user });
                        MetroFramework.MetroMessageBox.Show(this.ParentForm, "login Sucessfull", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginSuccessfull(true);
                        break;
                    case LogState.Logout:
                        UserChanged(this, new UserChangedArgs() { User = user });
                        LoginSuccessfull(false);
                        break;
                    case LogState.LoginNOK:
                        MetroFramework.MetroMessageBox.Show(this.ParentForm, "login failed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoginSuccessfull(bool p)
        {
            if (p)
            {
                bLog.Text = "Logout";
                bLog.Click -= bLogin_Click;
                bLog.Click += bLogout_Click;
                tLogin.Enabled = !p;
                tPwd.Visible = !p;
                //       lLogin.Visible = !p;
                lPwd.Visible = !p;
                IFirstName.Visible = p;
                ILastName.Visible = p;
                ILastLogin.Visible = p;
                tfirstname.Visible = p;
                tlastname.Visible = p;
                tlastlogin.Visible = p;
                UserInfo(user);
            }
            else
            {
                bLog.Text = "Login!";
                bLog.Click -= bLogout_Click;
                bLog.Click += bLogin_Click;
                tLogin.Enabled = !p;
                tPwd.Visible = !p;
                //         lLogin.Visible = !p;
                lPwd.Visible = !p;
                IFirstName.Visible = p;
                ILastName.Visible = p;
                ILastLogin.Visible = p;
                tfirstname.Visible = p;
                tlastname.Visible = p;
                tlastlogin.Visible = p;
            }
            bUpdate.Visible = p;

        }

        private void UserInfo(DmsDatabase.DmsUser user)
        {
            tfirstname.Text = user.Firstname;
            tlastname.Text = user.Lastname;
            tlastlogin.Text = Convert.ToString(user.Lastlogin);
        }

        private void bLogout_Click(object sender, EventArgs e)
        {
            OnUserChanged(null, LogState.Logout);
        }

        private void tLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bLogin_Click(sender, e);
            }
        }

        enum LogState
        {
            LoginOK,
            LoginNOK,
            Logout,
        }

        private async void bUpdate_Click(object sender, EventArgs e)
        {
            user.Firstname = tfirstname.Text;
            user.Lastname = tlastname.Text;
            metroProgressSpinner1.Visible = true;
            await Task.Run(() => DmsDatabase.DmsUser.SaveUser(user));
            metroProgressSpinner1.Visible = false;
        }
    }
}
