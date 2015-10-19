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
    public partial class DmsForm_Overview : MetroFramework.Forms.MetroForm
    {
        public DmsForm_Overview()
        {
            InitializeComponent();
            DmsSession.LogingOut += HandleLoggingOut;
        }

        private int selectedsk_nr;
        public int _SelectedSk_nr
        {
            set { selectedsk_nr = value; }
        }

        private string place_nr;
        public string _Place_nr
        {
            set { place_nr = value; }
        }

        public void paintOverview()
        {
            tb_SkindNr.Text = selectedsk_nr.ToString();
            tb_Place.Text = place_nr;
        }

        private void HandleLoggingOut(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DmsForm_FactoryState_FormClosing(object sender, FormClosingEventArgs e)
        {
            DmsSession.LogingOut -= HandleLoggingOut;
        }

        private void btFiltersave_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Actual Filter was saved", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }

        private void btFilterReset_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "All setings was removed", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }

        private void metroDateTime2_ValueChanged(object sender, EventArgs e)
        {
            //datatime2 = metroDateTime2.Value.Date;
            //datatime2_checked = metroDateTime2.Checked;

        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            //datatime1 = metroDateTime1.Value.Date;
            //datatime1_checked = metroDateTime1.Checked;
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            //bsn_nr = int.Parse(tb_BsnNr.Text);
        }

        private void tbLoadL5X_TextChanged(object sender, EventArgs e)
        {
            //sk_nr = int.Parse(tb_SkidNr.Text);
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            //tb_BsnNr.Text = "0";
            //tb_SkidNr.Text = "0";
            //cb_allUnitsOnPlant.Checked = false;

            //if (tb_LeftPlant.Checked == true)
            //{
            //    cb_leftplant = 1;
            //}
            //else
            //{
            //    cb_leftplant = 0;
            //}
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            //cb_searchinMFP = cb_allUnitsOnPlant.Checked;
            //tb_BsnNr.Text = "0";
            //tb_SkidNr.Text = "0";
            //tb_LeftPlant.Checked = false;

        }
    }
}
