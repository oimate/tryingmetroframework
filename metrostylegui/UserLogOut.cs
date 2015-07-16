using MetroFramework.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metrostylegui
{
    public partial class UserLogOut : MetroUserControl
    {
        public string LoggedUser { set { lUserName.Text = value; } }

        public UserLogOut()
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

        private async void bLogOut_Click(object sender, EventArgs e)
        {
            await Task.Run(() => DmsSession.Logout(this));
            OnUserChanged();
        }

        public event EventHandler<DmsUserChangedArgs> UserChanged;
        private void OnUserChanged()
        {
            if (UserChanged != null)
                UserChanged(this, new DmsUserChangedArgs() { User = DmsSession.LoggedUser, Action = UserChangedAction.Logout });
        }
    }
}