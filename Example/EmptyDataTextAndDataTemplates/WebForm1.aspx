<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmptyDataTextAndDataTemplates.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" EmptyDataText="There are no product avaiable" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="ProdcutId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ProdcutId" HeaderText="ProdcutId" InsertVisible="False" ReadOnly="True" SortExpression="ProdcutId"/>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"/>
                <asp:BoundField DataField="QuantitySold" HeaderText="QuantitySold" SortExpression="QuantitySold"/>
            </Columns>
           <EmptyDataTemplate>
    <table cellspacing="2" cellpadding="3" rules="all" id="GridView1" style="background-color: #DEBA84;
        border-color: #DEBA84; border-width: 1px; border-style: None;">
        <tr style="color: White; background-color: #A55129; font-weight: bold;">
            <td scope="col">
                ProdcutId
            </td>
            <td scope="col">
                Name
            </td>
            <td scope="col">
                UnitPrice
            </td>
            <td scope="col">
                QuantitySold
            </td>
        </tr>
        <tr style="color: #8C4510; background-color: #FFF7E7;">
            <td colspan="4">
                There are no products to display
            </td>
        </tr>
    </table>
</EmptyDataTemplate> 
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
