using MetroFramework.Controls;
using MetroFramework.Forms;

//using System.Drawing;
//using System.Windows.Forms;

namespace metrostylegui
{
    public partial class DmsForm_Main : MetroForm
    {
        public DmsForm_Main()
        {
            InitializeComponent();
            DmsLog.Notes.Log(DmsObfuscation.Code("dms", DmsSession.ConnectionString));
        }

        private void tileLoginLogout_Click(object sender, System.EventArgs e)
        {
            if (!DmsSession.IsSomeoneLogged)
            {
                var loginForm = new DmsForm_Login(this);
                loginForm.ShowDialog();
                if (loginForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    tileLoginLogout.Text = "Logout: " + DmsSession.LoggedUserDisplayName;
                    tileLoginLogout.Style = MetroFramework.MetroColorStyle.Green;
                    SwitchTilesVisible(true);
                }
                loginForm.Dispose();
            }
            else
            {
                DmsSession.Logout(this);
                tileLoginLogout.Text = "Login";
                tileLoginLogout.Style = MetroFramework.MetroColorStyle.Silver;
                SwitchTilesVisible(false);
            }
            this.Invalidate(true);
        }

        private void SwitchTilesVisible(bool onoff)
        {
            tileERP.Visible = tileFactory.Visible = onoff;
        }

        private void metroTile1_Click(object sender, System.EventArgs e)
        {
            var dt = DmsDatabase.GetErpWithRange(100, 20);
        }

        DmsForm_ProductionData productionForm;
        private void tileProduction_Click(object sender, System.EventArgs e)
        {
            if (productionForm == null)
            {
                productionForm = new DmsForm_ProductionData();
                productionForm.FormClosing += productionForm_FormClosing;
            }
            productionForm.Show();
            //if (productionForm.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            //{
            //    productionForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //}
            //if (!productionForm.Focused)
            //{
            //    productionForm.Focus();
            //}
            //this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
        private void productionForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (productionForm != null)
            {
                productionForm.FormClosing -= productionForm_FormClosing;
            }
            productionForm = null;
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        DmsForm_FactoryState factoryForm;
        private void tileFactory_Click(object sender, System.EventArgs e)
        {
            if (factoryForm == null)
            {
                factoryForm = new DmsForm_FactoryState();
                factoryForm.FormClosing += factoryForm_FormClosing;
            }
            factoryForm.Show();
            if (factoryForm.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                factoryForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
            if (!factoryForm.Focused)
            {
                factoryForm.Focus();
            }
        }
        private void factoryForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (factoryForm != null)
            {
                factoryForm.FormClosing -= factoryForm_FormClosing;
            }
            factoryForm = null;
        }

        private void tilePlcStatus_Click(object sender, System.EventArgs e)
        {

        }

        private void tileDatabaseStatus_Click(object sender, System.EventArgs e)
        {

        }

    }
}