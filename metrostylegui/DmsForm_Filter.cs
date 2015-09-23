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
    public partial class DmsForm_Filer : MetroFramework.Forms.MetroForm
    {
        public DmsForm_Filer()
        {
            InitializeComponent();
            DmsSession.LogingOut += HandleLoggingOut;
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
    }
}
