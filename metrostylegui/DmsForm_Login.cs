using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metrostylegui
{
    public partial class DmsForm_Login : MetroFramework.Forms.MetroForm
    {
        public String Login { get { return tbUser.Text; } }
        public String Pwd { get { return tbPwd.Text; } }

        public DmsForm_Login(Form parent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            //this.Left = parent.Left;
            //this.Width = parent.Width;
            //this.Top = parent.Top + ((parent.Height - this.Height) / 2);
        }

        private async void bLogin_Click(object sender, EventArgs e)
        {
            if (InvalidUserInput(Login, Pwd))
            {
                MetroFramework.MetroMessageBox.Show(this, "Input data cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LockForLoginOperation();

            var ok = await Task<bool>.Run(() => { return DmsSession.Login(Login, Pwd); });

            UnlockAfterLoginOperation();

            if (ok)
            {
                //OnUserChanged();
            }
            else
            {
                if (!this.IsDisposed)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error while loging! Check login or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UnlockAfterLoginOperation()
        {
            bLogin.Enabled = tbPwd.Enabled = tbUser.Enabled = true;
            bLogin.Text = "Login";
        }

        private void LockForLoginOperation()
        {
            bLogin.Enabled = tbPwd.Enabled = tbUser.Enabled = false;
            bLogin.Text = "In Progress";
        }

        private bool InvalidUserInput(string user, string pwd)
        {
            return (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pwd));
        }

        //public event EventHandler<DmsUserChangedArgs> UserChanged;
        //private void OnUserChanged()
        //{
        //    if (UserChanged != null)
        //        UserChanged(this, new DmsUserChangedArgs() { User = DmsSession.LoggedUser, Action = UserChangedAction.Login });
        //}
    }
}
