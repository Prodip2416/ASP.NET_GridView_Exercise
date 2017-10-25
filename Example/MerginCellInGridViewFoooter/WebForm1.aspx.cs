using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerginCellInGridViewFoooter
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int count = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                count += 1;
            }
            else if(e.Row.RowType==DataControlRowType.Footer)
            {
                e.Row.Cells.Clear();
                 TableCell tableCell= new TableCell();
                tableCell.ColumnSpan = 4;
                tableCell.Font.Bold = true;
                tableCell.Text = "Total Employee Count = " + count.ToString();
                tableCell.HorizontalAlign=HorizontalAlign.Center;
                e.Row.Cells.Add(tableCell);
            }
        }
    }
}