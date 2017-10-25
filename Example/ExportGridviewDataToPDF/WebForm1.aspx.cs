using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ExportGridviewDataToPDF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con= new SqlConnection(CS);
                SqlDataAdapter da= new SqlDataAdapter("select * from Employee4", con);
                DataSet ds= new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PdfPTable pdfPTable= new PdfPTable(GridView1.HeaderRow.Cells.Count);

            //addind header row........
              foreach (TableCell headerCell in GridView1.HeaderRow.Cells)
                {
                //adding color in header....
                    Font font= new Font();
                    font.Color=new BaseColor(GridView1.HeaderStyle.ForeColor);

                    PdfPCell pdfPCell = new PdfPCell(new Phrase(headerCell.Text));

               //adding header color...........
                    pdfPCell.BackgroundColor=new BaseColor(GridView1.HeaderStyle.BackColor);

                    pdfPTable.AddCell(pdfPCell);
                }
         
           // adding cell...............
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GridView1.RowStyle.ForeColor);

                    PdfPCell pdfPCell= new PdfPCell(new Phrase(tableCell.Text));
                    pdfPCell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);
                    pdfPTable.AddCell(pdfPCell);
                }
            }

            Document pdfdocument= new Document(PageSize.A4,10f,10f,10f,10f);
            PdfWriter.GetInstance(pdfdocument, Response.OutputStream);

            pdfdocument.Open();
            pdfdocument.Add(pdfPTable);
            pdfdocument.Close();

             // Download ......requeriment....
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition","attachment;filename=Employees.pdf");
            Response.Write(pdfdocument);
            Response.Flush();
            Response.End();
        }
    }
}