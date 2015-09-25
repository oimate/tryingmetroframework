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
            gridProductionData.AutoResizeColumns();
            gridProductionData.Columns["Id"].Visible = false;
             //    gridProductionData.Columns["rowNum"].Visible = true;
            //     gridProductionData.Columns[5].HeaderText = "Body";
            //     gridProductionData.Columns[6].HeaderText = "Plastic";
            //     gridProductionData.Columns[7].HeaderText = "Adress";
            gridProductionData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (this.gridProductionData.ContextMenuStrip == null)
            {
                this.gridProductionData.ContextMenuStrip = this.contextMenuStrip1;
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

            if (filtersForm == null)
            {
                gridProductionData.DataSource = DmsDatabase.GetErTop1000();
        //        gridProductionData.DataSource = DmsDatabase.GetErpWithRange(1, 2000);
                filtersForm = new DmsForm_Filer();
                filtersForm.FormClosing += factoryForm_FormClosing;
            }
            else
            {
                if (filtersForm.Sk_nr != 0)
                {
                    gridProductionData.DataSource = DmsDatabase.GetErpSkidData(filtersForm.Sk_nr, filtersForm.CB_LeftPlant);
                    
                }
                if (filtersForm.Bsn_nr != 0)
                {
                    gridProductionData.DataSource = DmsDatabase.GetErpBnsData(filtersForm.Bsn_nr, filtersForm.CB_LeftPlant);                    
                }

                if (filtersForm.Bsn_nr ==0 && filtersForm.Sk_nr == 0)
                {
                                gridProductionData.DataSource = DmsDatabase.GetErpProduction(filtersForm.CB_LeftPlant);
                }
            }

            ReStyleDataGrid();
            bTxt.Enabled = true;
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
            Paragraph headertext = new Paragraph("Summary Report for: " + loginID, font_header);
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
        DmsForm_Filer filtersForm;
        private void bFilters_Click(object sender, EventArgs e)
        {
            if (filtersForm == null)
            {
                filtersForm = new DmsForm_Filer();
                filtersForm.FormClosing += factoryForm_FormClosing; 
            }
            filtersForm.Show();
            if (filtersForm.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                filtersForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
            if (!filtersForm.Focused)
            {
                filtersForm.Focus();
            }
        }
        private void factoryForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (filtersForm != null)
            {
                filtersForm.FormClosing -= factoryForm_FormClosing;
            }
            filtersForm = null;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            //  gridProductionData.DataSource = DmsDatabase.GetErpWithRange(1, 500);
            ReStyleDataGrid();
            bTxt.Enabled = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var test = filtersForm.Datatime2; 

            //   gridProductionData.DataSource = DmsDatabase.GetErpWithRange(1, 1000);
            //  gridProductionData.DataSource = DmsDatabase.GetErpWithRange(1, 500);
            ReStyleDataGrid();
            bTxt.Enabled = true;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selecteditem in gridProductionData.SelectedRows)
            {
                int skid_value = Int32.Parse(gridProductionData.Rows[selecteditem.Index].Cells["ForeignSkid"].Value.ToString());

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

        private void t_filterscheck_Tick(object sender, EventArgs e)
        {
            if (filtersForm != null)
            {
                if (bFilters.Style == MetroFramework.MetroColorStyle.Red)
                {
                    bFilters.Style = MetroFramework.MetroColorStyle.Blue;

                }
                else
                {
                    bFilters.Style = MetroFramework.MetroColorStyle.Red;
    

                }
            }
            else
            {
                bFilters.Style = MetroFramework.MetroColorStyle.Blue;
            }
            bFilters.Refresh();
        }
    }
}
