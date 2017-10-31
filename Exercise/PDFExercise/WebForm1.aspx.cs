using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFExercise
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con= new SqlConnection(CS);
                SqlDataAdapter da= new SqlDataAdapter("select * from Products",con);
                DataSet ds= new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable= new PdfPTable(GridView1.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in GridView1.HeaderRow.Cells)
            {
                Font font= new Font();
                font.Color=new BaseColor(GridView1.HeaderStyle.ForeColor);
                PdfPCell pdfP= new PdfPCell(new Phrase(headerCell.Text,font));
                pdfP.BackgroundColor=new BaseColor(GridView1.HeaderStyle.BackColor);
                pdfTable.AddCell(pdfP);
            }

            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GridView1.RowStyle.ForeColor);
                    PdfPCell pdfPCell=new PdfPCell(new Phrase(tableCell.Text,font));
                    pdfPCell.BackgroundColor=new BaseColor(GridView1.RowStyle.BackColor);
                    pdfTable.AddCell(pdfPCell);
                }
            }

            Document pdfDocument=new Document(PageSize.A4,10f,10f,10f,10f);
            // for landscape view...
            pdfDocument.SetPageSize(PageSize.A4.Rotate());

            // for download....
          //  PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            // for download in own server....
            PdfWriter.GetInstance(pdfDocument, new FileStream(Server.MapPath("~/PDFDocuments/Product.pdf"), FileMode.Create));

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.Redirect("~/PDFDocuments//Product.pdf");

            //Response.ContentType = "application/pdf";
            //Response.AppendHeader("content-disposition","attachment;filename=Product.pdf");
            //Response.Write(pdfDocument);
            //Response.Flush();
            //Response.End();
           // Response.Redirect("~\\Product.pdf");
        }
    }
}