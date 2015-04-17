using System;
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
            UpdeteTexts();
        }

        private void UpdeteTexts()
        {
            IGroup.Text = Properties.Resources.Group;
            IFirstName.Text = Properties.Resources.FirstName;
            ILastName.Text = Properties.Resources.LastName;
            ILastLogin.Text = Properties.Resources.LastLogin;
            lLogin.Text = Properties.Resources.Login;
            lPwd.Text = Properties.Resources.Password;
            bLog.Text = Properties.Resources.Login;
            bUpdate.Text = Properties.Resources.Edit;
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

        private async void bLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tLogin.Text) || string.IsNullOrWhiteSpace(tPwd.Text)) return;

            LoginInProggres(true);

            user = await Task<DmsDatabase.DmsUser>.Run(() => DmsDatabase.DmsUser.GetUser(tLogin.Text, tPwd.Text));
            LogState ls = (user != null) ? LogState.LoginOK : LogState.LoginNOK;
            OnUserChanged(user, ls);
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
                        tableLayoutPanel1.Visible = false;
                        MetroFramework.MetroMessageBox.Show(this.ParentForm, "login Sucessfull", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tableLayoutPanel1.Visible = true;
                        LoginSuccessfull(true);
                        break;
                    case LogState.Logout:
                        UserChanged(this, new UserChangedArgs() { User = user });
                        LoginSuccessfull(false);
                        tPwd.Text = "";
                        break;
                    case LogState.LoginNOK:
                        tableLayoutPanel1.Visible = false;
                        MetroFramework.MetroMessageBox.Show(this.ParentForm, "login failed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tableLayoutPanel1.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoginSuccessfull(bool success)
        {
            if (success)
            {
                bLog.Text = Properties.Resources.Logout;
                bLog.Click -= bLogin_Click;
                bLog.Click += bLogout_Click;
                UserBoxDisplay(DisplayMode.AllLabels);
                UserInfo(user);
            }
            else
            {
                bLog.Text = Properties.Resources.Login;
                bLog.Click -= bLogout_Click;
                bLog.Click += bLogin_Click;
            }
            bUpdate.Visible = success;
            bUpdate.Text = Properties.Resources.Edit;
            bUpdate.Click -= bUpdate_Click;
            bUpdate.Click += bEdit_Click;
        }

        private void UserBoxDisplay(DisplayMode disp)
        {
            switch (disp)
            {
                case DisplayMode.AllLabels:
                    tableLayoutPanel1.Controls.Add(Lgrouptext, 2, 0);
                    tableLayoutPanel1.Controls.Add(Lfirstnametext, 2, 1);
                    tableLayoutPanel1.Controls.Add(Llastnametext, 2, 2);
                    tableLayoutPanel1.Controls.Add(Lastlogintext, 2, 3);
                    tableLayoutPanel1.Controls.Add(Llogintext, 2, 4);
                    tableLayoutPanel1.Controls.Add(Lpasswordtext, 2, 5);

                    IGroup.Visible = true;
                    IFirstName.Visible = true;
                    ILastName.Visible = true;
                    ILastLogin.Visible = true;
                    lLogin.Visible = true;
                    lPwd.Visible = true;

                    Lgrouptext.Visible = true;
                    Lfirstnametext.Visible = true;
                    Llastnametext.Visible = true;
                    Lastlogintext.Visible = true;
                    Llogintext.Visible = true;
                    Lpasswordtext.Visible = true;

                    tGroup.Visible = false;
                    tfirstname.Visible = false;
                    tlastname.Visible = false;
                    tlastlogin.Visible = false;
                    tLogin.Visible = false;
                    tPwd.Visible = false;
                    break;

                case DisplayMode.AllTables:
                    tableLayoutPanel1.Controls.Remove(Lgrouptext);
                    tableLayoutPanel1.Controls.Remove(Lfirstnametext);
                    tableLayoutPanel1.Controls.Remove(Llastnametext);
                    tableLayoutPanel1.Controls.Remove(Lastlogintext);
                    tableLayoutPanel1.Controls.Remove(Llogintext);
                    tableLayoutPanel1.Controls.Remove(Lpasswordtext);

                    tableLayoutPanel1.Controls.Add(tGroup, 2, 0);
                    tableLayoutPanel1.Controls.Add(tfirstname, 2, 1);
                    tableLayoutPanel1.Controls.Add(tlastname, 2, 2);
                    tableLayoutPanel1.Controls.Add(tlastlogin, 2, 3);
                    tableLayoutPanel1.Controls.Add(tLogin, 2, 4);
                    tableLayoutPanel1.Controls.Add(tPwd, 2, 5);

                    IGroup.Visible = true;
                    IFirstName.Visible = true;
                    ILastName.Visible = true;
                    ILastLogin.Visible = true;
                    lLogin.Visible = true;
                    lPwd.Visible = true;

                    Lgrouptext.Visible = false;
                    Lfirstnametext.Visible = false;
                    Llastnametext.Visible = false;
                    Lastlogintext.Visible = false;
                    Llogintext.Visible = false;
                    Lpasswordtext.Visible = false;

                    tGroup.Visible = true;
                    tfirstname.Visible = true;
                    tlastname.Visible = true;
                    tlastlogin.Visible = true;
                    tLogin.Visible = true;
                    tPwd.Visible = true;

                    tGroup.Enabled = false;
                    tlastlogin.Enabled = false;
                    break;

                case DisplayMode.LogingAndPwdTables:
                    tableLayoutPanel1.Controls.Remove(Lgrouptext);
                    tableLayoutPanel1.Controls.Remove(Lfirstnametext);
                    tableLayoutPanel1.Controls.Remove(Llastnametext);
                    tableLayoutPanel1.Controls.Remove(Lastlogintext);
                    tableLayoutPanel1.Controls.Remove(Llogintext);
                    tableLayoutPanel1.Controls.Remove(Lpasswordtext);

                    tableLayoutPanel1.Controls.Add(tGroup, 2, 0);
                    tableLayoutPanel1.Controls.Add(tfirstname, 2, 1);
                    tableLayoutPanel1.Controls.Add(tlastname, 2, 2);
                    tableLayoutPanel1.Controls.Add(tlastlogin, 2, 3);
                    tableLayoutPanel1.Controls.Add(tLogin, 2, 4);
                    tableLayoutPanel1.Controls.Add(tPwd, 2, 5);

                    IGroup.Visible = false;
                    IFirstName.Visible = false;
                    ILastName.Visible = false;
                    ILastLogin.Visible = false;
                    lLogin.Visible = true;
                    lPwd.Visible = true;

                    Lgrouptext.Visible = false;
                    Lfirstnametext.Visible = false;
                    Llastnametext.Visible = false;
                    Lastlogintext.Visible = false;
                    Llogintext.Visible = false;
                    Lpasswordtext.Visible = false;

                    tGroup.Visible = false;
                    tfirstname.Visible = false;
                    tlastname.Visible = false;
                    tlastlogin.Visible = false;
                    tLogin.Visible = true;
                    tPwd.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void UserInfo(DmsDatabase.DmsUser user)
        {
            tGroup.Text = user.Group;
            tfirstname.Text = user.Firstname;
            tlastname.Text = user.Lastname;
            tlastlogin.Text = Convert.ToString(user.Lastlogin);
            tLogin.Text = user.Name;
            Lpasswordtext.Text = "****";
            Lgrouptext.Text = user.Group;
            Lfirstnametext.Text = user.Firstname;
            Llastnametext.Text = user.Lastname;
            Lastlogintext.Text = Convert.ToString(user.Lastlogin);
            Llogintext.Text = user.Name;
        }

        private void bLogout_Click(object sender, EventArgs e)
        {
            UserBoxDisplay(DisplayMode.LogingAndPwdTables);
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

        enum DisplayMode
        {
            AllLabels,
            AllTables,
            LogingAndPwdTables,
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            bUpdate.Text = Properties.Resources.Update;
            bUpdate.Click -= bEdit_Click;
            bUpdate.Click += bUpdate_Click;

            UserBoxDisplay(DisplayMode.AllTables);
            UserInfo(user);
        }

        private async void bUpdate_Click(object sender, EventArgs e)
        {
            user.Group = tGroup.Text;
            user.Firstname = tfirstname.Text;
            user.Lastname = tlastname.Text;
            user.Lastlogin = Convert.ToDateTime(tlastlogin.Text);
            user.Name = tLogin.Text;
            user.Pwd = Obfuscation.Code(tLogin.Text, tPwd.Text);
            metroProgressSpinner1.Visible = true;
            await Task.Run(() => DmsDatabase.DmsUser.SaveUser(user));
            metroProgressSpinner1.Visible = false;
            bUpdate.Text = Properties.Resources.Edit;
            bUpdate.Click -= bUpdate_Click;
            bUpdate.Click += bEdit_Click;
            UserBoxDisplay(DisplayMode.AllLabels);
            UserInfo(user);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }





    }
}




