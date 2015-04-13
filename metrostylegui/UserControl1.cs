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
    public partial class UserControl1 : MetroUserControl
    {
        public UserControl1()
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private async void bLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Pwd)) return;
            DmsDatabase.DmsUser user = await Task<DmsDatabase.DmsUser>.Run(() => DmsDatabase.DmsUser.GetUser(Login, Pwd));
            OnUserChanged(user);
            //if (user != null) this.Parent.Controls.Remove(this);
        }

        public event EventHandler<UserChangedArgs> UserChanged;
        private void OnUserChanged(DmsDatabase.DmsUser user)
        {
            if (user != null && UserChanged != null)
            {
                UserChanged(this, new UserChangedArgs() { User = user });
                MetroFramework.MetroMessageBox.Show(this.ParentForm, "login Sucessfull", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this.ParentForm, "login failed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);             
            }
        }

        private void tLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bLog_Click(sender, e);
            }
        }

    }
}
