using MetroFramework.Controls;
using MetroFramework.Forms;

//using System.Drawing;
//using System.Windows.Forms;

namespace metrostylegui
{
    public partial class DmsForm_Main : MetroForm
    {
        TCP.TCP_MasterSlave client;

        public DmsForm_Main()
        {
            InitializeComponent();

            client = new TCP.TCP_MasterSlave(TCP.ServerType.Client, "10.10.1.240", 4242, "dmsCli");
            client.ReceiveData = GetConnectionString;
            bgCon.RunWorkerAsync();
        }

        private void GetConnectionString(System.Net.Sockets.Socket socket, byte[] data)
        {
            try
            {
                int size;
                using (var ms = new System.IO.MemoryStream(data))
                {
                    using (var br = new System.IO.BinaryReader(ms))
                    {
                        size = br.ReadInt32();
                        var codedstring = System.Text.Encoding.UTF8.GetString(br.ReadBytes(size));
                        var decodedstring = DmsObfuscation.Decode("dms", codedstring);
                        DmsLog.Notes.Log(decodedstring);
                        DmsSession.ConnectionString = decodedstring;
                    }
                }
            }
            catch (System.Exception)
            {
                System.Diagnostics.Debugger.Break();
                throw;
            }
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

        DmsForm_Filer factoryForm;
        private void tileFactory_Click(object sender, System.EventArgs e)
        {
            if (factoryForm == null)
            {
                factoryForm = new DmsForm_Filer();
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

        private void bgCon_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (client.Status != TCP.ConnStat.Connected)
            {
                client.Open();
                if (client.Status != TCP.ConnStat.Connected)
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }
            DmsLog.Notes.Log("sending request");
            client.SendToServer(new byte[] { 49 });
        }

    }
}