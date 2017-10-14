<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="XMLDataSource.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Continent" HeaderText="Continent" SortExpression="Continent" />
            </Columns>
        </asp:GridView>
        
        <br/>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Data/XMLFile1.xml"></asp:XmlDataSource>
    </div>
    </form>
</body>
</html>
