using MetroFramework.Controls;
using MetroFramework.Forms;
//using System.Drawing;
//using System.Windows.Forms;

namespace metrostylegui
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
        }

        void MainForm_Resize(object sender, System.EventArgs e)
        {
            //if (uc1 != null && metroPanel1.Controls.Contains(uc1))
            //    ResizeUC(uc1);
        }

        private void ResizeUC(MetroUserControl uc)
        {
            uc.Top = (this.Height - uc.Height) / 2 - this.Padding.Top;
            uc.Left = (this.Width - uc.Width) / 2 - this.Padding.Left;
        }

        private LoginInput uc1;
        void MainForm_Load(object sender, System.EventArgs e)
        {
            this.uc1 = new LoginInput();
            this.uc1.UserChanged += uc1_UserChanged;
            this.metroTabPage1.Controls.Add(this.uc1);

        }

        void uc1_UserChanged(object sender, UserChangedArgs e)
        {
            metroTabPage1.Text = (e.User != null) ? e.User.Displayname : "Login";
        }
    }
}
