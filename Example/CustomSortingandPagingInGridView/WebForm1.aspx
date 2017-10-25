<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CustomSortingandPagingInGridView.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
    CurrentSortField="EmployeeId" CurrentSortDirection="ASC"
    AllowPaging="True" PageSize="3"
    OnSorting="GridView1_Sorting" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
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
<asp:Repeater ID="repeaterPaging" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="pagingLinkButton" runat="server" 
            Text='<%#Eval("Text") %>' 
            CommandArgument='<%# Eval("Value") %>'
            Enabled='<%# Eval("Enabled") %>' 
            OnClick="linkButton_Click">
        </asp:LinkButton>
    </ItemTemplate>
</asp:Repeater>
    </div>
    </form>
</body>
</html>
