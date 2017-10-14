<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AccessDataSource.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="AccessDataSource1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitePrice" HeaderText="UnitePrice" SortExpression="UnitePrice" />
            </Columns>
        </asp:GridView>
        <br/>
        <br/>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/Data/Product.accdb" SelectCommand="SELECT * FROM [tblProduct]"></asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
