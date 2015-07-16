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
    public partial class DmsForm_ProductionData : MetroFramework.Forms.MetroForm
    {
        public DmsForm_ProductionData()
        {
            InitializeComponent();
            DmsSession.LogingOut += Costam;
        }

        private void ReStyleDataGrid()
        {
            gridProductionData.AutoResizeColumns();
            gridProductionData.Columns["Id"].Visible = false;
            gridProductionData.Columns["rowNum"].Visible = false;
            gridProductionData.Columns["User"].Visible = false;
            gridProductionData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Costam(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DmsERP_FormClosing(object sender, FormClosingEventArgs e)
        {
            DmsSession.LogingOut -= Costam;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            gridProductionData.DataSource = DmsDatabase.GetErpWithRange(1, 200);
            ReStyleDataGrid();
        }
    }
}
