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
            gridProductionData.Columns["rowNum"].Visible = false;
            gridProductionData.Columns[5].HeaderText = "Body";
            gridProductionData.Columns[6].HeaderText = "Plastic";
            gridProductionData.Columns[7].HeaderText = "Adress";
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

        private void bTxt_Click(object sender, EventArgs e)
        {
    
        }

        private void bFilters_Click(object sender, EventArgs e)
        {

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(gridProductionData.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;

            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 0;
            // font definitions
            BaseFont bdeffTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font font_column = new Font(bdeffTimes, 10, 3, Color.DARK_GRAY);
            Font font_cell = new Font(bdeffTimes, 8, 3, Color.DARK_GRAY);
            Font font_header = new Font(bdeffTimes, 22, 3, Color.RED);

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
            iTextSharp.text.Image logo_Jpg = iTextSharp.text.Image.GetInstance(@"C:\PDFs\jaguarland.jpg");
            //Resize image depend upon your need

            logo_Jpg.ScaleToFit(70f, 70f);

            //Give space before image

            logo_Jpg.SpacingBefore = 10f;

            //Give some space after the image

            logo_Jpg.SpacingAfter = 10f;

            logo_Jpg.Alignment = Element.ALIGN_RIGHT;

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";

            // source input 
            Paragraph headertext = new Paragraph("Summary Report for: ", font_header);
            Paragraph lastupdatetext = new Paragraph("Created time " + DateTime.Now.ToString(), font_column);
            Paragraph emptylinetext = new Paragraph(" ");

            headertext.Alignment = Element.ALIGN_CENTER;
            lastupdatetext.Alignment = Element.ALIGN_RIGHT;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 30f, 30f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(logo_Jpg);
                pdfDoc.Add(headertext);
                pdfDoc.Add(emptylinetext);
                pdfDoc.Add(emptylinetext);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(emptylinetext);
                pdfDoc.Add(emptylinetext);
                pdfDoc.Add(lastupdatetext);
                pdfDoc.Close();
                stream.Close();
            }
        }
    }
}
