using MetroFramework.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metrostylegui
{
    public partial class UserLogIn : MetroUserControl
    {
        private string Login { get { return tLogin.Text; } }
        private string Pwd { get { return tPwd.Text; } }

        public UserLogIn()
        {
            InitializeComponent();
            this.ParentChanged += UserControl1_ParentChanged;
        }

        private void UserControl1_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null && ParentForm != null)
            {
                Parent.Resize += Parent_Resize;
                Parent_Resize(sender, e);
            }
        }

        private void Parent_Resize(object sender, EventArgs e)
        {
            if (ParentForm.WindowState != FormWindowState.Minimized)
            {
                this.Top = (Parent.Height - this.Height) / 2;
                this.Left = (Parent.Width - this.Width) / 2;
            }
        }

        private async void bLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Pwd))
            {
                MetroFramework.MetroMessageBox.Show(this.ParentForm, "Input data cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginInProggres(true);
            
            var ok = await Task<bool>.Run(() => DmsSession.Login(Login, Pwd));

            if (ok)
            {
                OnUserChanged();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this.ParentForm, "Error while loging in! Check Your login or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoginInProggres(false);
        }

        private void LoginInProggres(bool p)
        {
            metroProgressSpinner1.Visible = p;
            bLogIn.Enabled = !p;
        }

        public event EventHandler<DmsUserChangedArgs> UserChanged;
        private void OnUserChanged()
        {
            if (UserChanged != null)
                UserChanged(this, new DmsUserChangedArgs() { User = DmsSession.LoggedUser, Action = UserChangedAction.Login });
        }

        private void tLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bLogIn_Click(sender, e);
            }
        }
    }
}