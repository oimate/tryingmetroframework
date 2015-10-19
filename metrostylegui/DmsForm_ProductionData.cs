using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.rtf;
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
            //if (cb_shotrinfo.Checked == true)
            //{
     //         hideOrRenameSomeColumns();
            //}

            gridProductionData.AutoResizeColumns();
            gridProductionData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (this.gridProductionData.ContextMenuStrip == null)
            {
                this.gridProductionData.ContextMenuStrip = this.contextMenuStrip1;
            }
        }

        private void hideOrRenameSomeColumns()
        {
            foreach (DataGridViewColumn column in gridProductionData.Columns)
            {
                if (column.HeaderText == "Id")
                {
                    column.Visible = false;
                }
                if (column.HeaderText == "ForeignSkid")
                {
                    column.HeaderText = "Skid ID";
                }
                if (column.HeaderText == "Roof")
                {
                    column.HeaderText = "Body";
                }
                if (column.HeaderText == "Door")
                {
                    column.HeaderText = "Plastic";
                }

                if (column.HeaderText == "Spare")
                {
                    column.HeaderText = "Adress";
                }
                if (column.HeaderText == "UpdatedOnMfp")
                {
                    column.Visible = false;
                }
                if (column.HeaderText == "MfpPos")
                {
                    column.Visible = false;
                }
                if (column.HeaderText == "Description")
                {
                    column.Visible = false;
                }

                if (column.HeaderText == "fk_LocalSkidNr")
                {
                    column.Visible = false;
                }

                if (column.HeaderText == "fk_MfpPos")
                {
                    column.Visible = false;
                }
                if (column.HeaderText == "Description1")
                {
                    column.HeaderText = "Actual Position";
                }

                if (column.HeaderText == "Track")
                {
                    column.Visible = false;
                }
            }
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
            if (tb_BsnNr.Text != "0" || tb_SkindNr.Text != "0" || dt_timeStart.Checked == true || dt_timeEnd.Checked == true)
            {
                if ((dt_timeStart.Checked == true && dt_timeEnd.Checked == true) && tb_SkindNr.Text =="0" )  // check historic movement for all skids
                {
                    gridProductionData.DataSource = DmsDatabase.MFP_GetHistoricDataForAllSkids(dt_timeStart.Value.Date.ToString(), dt_timeEnd.Value.Date.ToString());   // shot actual skids on factory      
                    lb_searchinfo.Text = " Historic data";
                }
                if ((dt_timeStart.Checked == true && dt_timeEnd.Checked == true) && tb_SkindNr.Text != "0")  // check historic movement for one skid
                {
                    gridProductionData.DataSource = DmsDatabase.MFP_GetHistoricDataForSkid(dt_timeStart.Value.Date.ToString(), dt_timeEnd.Value.Date.ToString(),int.Parse(tb_SkindNr.Text));   // shot actual skids on factory       
                    lb_searchinfo.Text = " Historic data , search by skid nr: "+ tb_SkindNr.Text;
                }
                if ((dt_timeStart.Checked == true && dt_timeEnd.Checked == true) && tb_BsnNr.Text != "0")  // check historic movement for one bsn
                {
                    gridProductionData.DataSource = DmsDatabase.MFP_GetHistoricDataForBSN(dt_timeStart.Value.Date.ToString(), dt_timeEnd.Value.Date.ToString(), int.Parse(tb_BsnNr.Text));   // shot actual skids on factory                 
                    lb_searchinfo.Text = " Historic data , search by BSN nr" +tb_BsnNr.Text;
                }

            }
            else
            {
                gridProductionData.DataSource = DmsDatabase.MFP_GetStatusSkidFactory();    // show actual skids on factory
                lb_searchinfo.Text = " Actual Skids on Factory";
            }

            ReStyleDataGrid();
            hideOrRenameSomeColumns();
            bTSaveToPDF.Enabled = true;
        }

        private void bTxt_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(gridProductionData.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;

            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 0;
            // font definitions
            BaseFont bdeffTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font font_column = new Font(bdeffTimes, 7, 3, Color.DARK_GRAY);
            Font font_cell = new Font(bdeffTimes, 5, 3, Color.DARK_GRAY);
            Font font_header = new Font(bdeffTimes, 10, 3, Color.RED);

            //Adding Header row
            foreach (DataGridViewColumn column in gridProductionData.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font_column));
                cell.BackgroundColor = new iTextSharp.text.Color(255, 255, 204);    //(140, 40, 240);
                pdfTable.AddCell(cell);
            }
            //Adding DataRow
            foreach (DataGridViewRow row in gridProductionData.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    PdfPCell cel = new PdfPCell(new Phrase(cell.Value.ToString(), font_cell));
                    pdfTable.AddCell(cel);
                }
            }
            // Add Image
            iTextSharp.text.Image logo_Jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"\jaguarland.jpg"); //(@"C:\PDFs\jaguarland.jpg");
            //Resize image depend upon your need

            logo_Jpg.ScaleToFit(70f, 70f);

            //Give space before image

            logo_Jpg.SpacingBefore = 10f;

            //Give some space after the image

            logo_Jpg.SpacingAfter = 10f;

            logo_Jpg.Alignment = Element.ALIGN_RIGHT;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please chose destination for save report file... ";
            DialogResult dr = fbd.ShowDialog();
            string folderPath = "";
            if (dr == DialogResult.OK)
            {
                var savedir = (fbd.SelectedPath.ToString() + @"\");
                folderPath = savedir;
                Properties.Settings.Default.SavePath = savedir;
                Properties.Settings.Default.Save();
            }
            //Exporting to PDF
            //     = @"C:\Service\Backup\4. Raports\";   //C:\Service\Backup\4. Raports

            // source input 
            string loginID = DmsSession.LoggedUserDisplayName;
            Paragraph headertext = new Paragraph("Summary Report for: " + lb_searchinfo.Text); //loginID, font_header);
            Paragraph lastupdatetext = new Paragraph("Created time " + DateTime.Now.ToString(), font_column);
            Paragraph emptylinetext = new Paragraph(" ");

            headertext.Alignment = Element.ALIGN_CENTER;
            lastupdatetext.Alignment = Element.ALIGN_RIGHT;
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }


                using (FileStream stream = new FileStream(folderPath + "ProductionReport" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 30f, 30f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(logo_Jpg);
                    pdfDoc.Add(headertext);
                    pdfDoc.Add(emptylinetext);
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Add(emptylinetext);
                    pdfDoc.Add(emptylinetext);
                    pdfDoc.Add(lastupdatetext);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Save procedure was canceled", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        DmsForm_Overview OverviewForm;
        private void bFilters_Click(object sender, EventArgs e)
        {
            if (OverviewForm == null)
            {
                OverviewForm = new DmsForm_Overview();
                OverviewForm.FormClosing += factoryForm_FormClosing;
            }
            OverviewForm.Show();
            if (OverviewForm.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                OverviewForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
            if (!OverviewForm.Focused)
            {
                OverviewForm.Focus();
            }
        }
        private void factoryForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (OverviewForm != null)
            {
                OverviewForm.FormClosing -= factoryForm_FormClosing;
            }
            OverviewForm = null;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ReStyleDataGrid();
            bTSaveToPDF.Enabled = true;
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selecteditem in gridProductionData.SelectedRows)
            {

                int skid_value = Int32.Parse(gridProductionData.Rows[selecteditem.Index].Cells["ForeignSkid"].Value.ToString());

                MetroFramework.MetroMessageBox.Show(this, "Do You want remove Record for skid Nr : " + skid_value.ToString(), "MetroMessagebox", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                bool leftplent = bool.Parse(gridProductionData.Rows[selecteditem.Index].Cells["LeftPlant"].Value.ToString());

                if (leftplent == false)
                {
                    var temp = DmsDatabase.DeleteRow(skid_value, 0);   // usuwanie tylko  na plancie = 0
                    gridProductionData.Rows.RemoveAt(selecteditem.Index);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(gridProductionData.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;

            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 0;
            // font definitions
            BaseFont bdeffTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font font_column = new Font(bdeffTimes, 8, 3, Color.DARK_GRAY);
            Font font_cell = new Font(bdeffTimes, 6, 3, Color.DARK_GRAY);
            Font font_header = new Font(bdeffTimes, 12, 3, Color.RED);

            //Adding Header row
            foreach (DataGridViewColumn column in gridProductionData.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font_column));
                cell.BackgroundColor = new iTextSharp.text.Color(140, 40, 240);
                pdfTable.AddCell(cell);
            }
            int skid_value = 0;
            //Adding DataRow
            foreach (DataGridViewRow row in gridProductionData.SelectedRows)
            {
                skid_value = Int32.Parse(gridProductionData.Rows[row.Index].Cells["ForeignSkid"].Value.ToString());

                foreach (DataGridViewCell cell in row.Cells)
                {
                    PdfPCell cel = new PdfPCell(new Phrase(cell.Value.ToString(), font_cell));
                    pdfTable.AddCell(cel);
                }
            }
            // Add Image
            iTextSharp.text.Image logo_Jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + @"\jaguarland.jpg"); //(@"C:\PDFs\jaguarland.jpg");
            //Resize image depend upon your need

            logo_Jpg.ScaleToFit(70f, 70f);

            //Give space before image

            logo_Jpg.SpacingBefore = 10f;

            //Give some space after the image

            logo_Jpg.SpacingAfter = 10f;

            logo_Jpg.Alignment = Element.ALIGN_RIGHT;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please chose destination for save report file... ";
            DialogResult dr = fbd.ShowDialog();
            string folderPath = "";
            if (dr == DialogResult.OK)
            {
                var savedir = (fbd.SelectedPath.ToString() + @"\");
                folderPath = savedir;
                Properties.Settings.Default.SavePath = savedir;
                Properties.Settings.Default.Save();
            }
            //Exporting to PDF
            //     = @"C:\Service\Backup\4. Raports\";   //C:\Service\Backup\4. Raports

            // source input 
            string loginID = DmsSession.LoggedUserDisplayName;
            Paragraph headertext = new Paragraph("Detailed  Report for skid nr: " + skid_value, font_header);
            Paragraph lastupdatetext = new Paragraph("Created time " + DateTime.Now.ToString(), font_column);
            Paragraph emptylinetext = new Paragraph(" ");

            headertext.Alignment = Element.ALIGN_CENTER;
            lastupdatetext.Alignment = Element.ALIGN_RIGHT;
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }


                using (FileStream stream = new FileStream(folderPath + "SkidDetailedReport" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 30f, 30f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(logo_Jpg);
                    pdfDoc.Add(headertext);
                    pdfDoc.Add(emptylinetext);
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Add(emptylinetext);
                    pdfDoc.Add(emptylinetext);
                    pdfDoc.Add(lastupdatetext);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Save procedure was canceled", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        } 
        private void cb_shotrinfo_CheckedChanged(object sender, EventArgs e)
        {
            hideOrRenameSomeColumns();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showUnitOnMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
             foreach (DataGridViewRow selecteditem in gridProductionData.SelectedRows)
            {
                string place_desc = "No Place";

                int selectedsk_nr = Int32.Parse(gridProductionData.Rows[selecteditem.Index].Cells[1].Value.ToString());

                //if (gridProductionData.Rows[selecteditem.Index].Cells["Actual Position"].Value.ToString() == "Actual Position")
                //{
                  place_desc = (gridProductionData.Rows[selecteditem.Index].Cells[16].Value.ToString());              
                //}
             
                if (selectedsk_nr != 0)
                {
                    if (OverviewForm == null)
                    {
                        OverviewForm = new DmsForm_Overview();
                        OverviewForm.FormClosing += factoryForm_FormClosing;
                    }
                    OverviewForm._SelectedSk_nr = selectedsk_nr;
                    OverviewForm._Place_nr = place_desc;
                    OverviewForm.paintOverview();
                    OverviewForm.Show();
              
                    if (OverviewForm.WindowState == System.Windows.Forms.FormWindowState.Minimized)
                    {
                        OverviewForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    }
                    if (!OverviewForm.Focused)
                    {
                        OverviewForm.Focus();
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Missing skid nr", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
             }          
        }

        private void t_filtercheck_Tick(object sender, EventArgs e)
        {
            if (tb_BsnNr.Text != "0" || tb_SkindNr.Text != "0" || dt_timeStart.Checked == true || dt_timeEnd.Checked == true)
            {
                if (bt_resetfilter.Style == MetroFramework.MetroColorStyle.Red)
                {
                    bt_resetfilter.Style = MetroFramework.MetroColorStyle.Silver;
                }
                else
                {
                bt_resetfilter.Style = MetroFramework.MetroColorStyle.Red;
                }
                bt_resetfilter.Visible = true;
            }

            bt_resetfilter.Refresh();

        }

        private void b_resetfilter_Click(object sender, EventArgs e)
        {
            tb_BsnNr.Text = "0";
            tb_SkindNr.Text = "0";
            dt_timeStart.Checked = false;
            dt_timeEnd.Checked = false;
            bt_resetfilter.Visible = false;
        }
    }
}
