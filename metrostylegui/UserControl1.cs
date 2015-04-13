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
            this.GotFocus += UserControl1_GotFocus;
        }

        void UserControl1_GotFocus(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(ParentForm, "some message");
        }

        void UserControl1_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null && ParentForm != null)
            {
                Parent.Resize += Parent_Resize;
                Parent_Resize(sender, e);
            }
            else
                Parent.Resize -= Parent_Resize;
        }

        void Parent_Resize(object sender, EventArgs e)
        {
            if (ParentForm.WindowState != FormWindowState.Minimized)
            {
                this.Top = (Parent.Height - this.Height) / 2;
                this.Left = (Parent.Width - this.Width) / 2;
            }
        }

        public string Login { get { return metroTextBox1.Text; } }
        public string Pwd { get { return metroTextBox2.Text; } }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Pwd)) return;
            DmsDatabase.DmsUser user = await Task<DmsDatabase.DmsUser>.Run(() => DmsDatabase.DmsUser.GetUser(Login, Pwd));
            if (user != null) this.Parent.Controls.Remove(this);
        }
    }
}
