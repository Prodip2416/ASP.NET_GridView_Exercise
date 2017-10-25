<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailes.aspx.cs" Inherits="GetValueInGridViewTemplate.ProductDetailes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Arial">
<table border="1" style="background: LightGoldenrodYellow">
    <tr>
        <td>
            <b>ID</b>
        </td>
        <td>
            <asp:Label ID="lblID" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Name</b>
        </td>
        <td>
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Price</b>
        </td>
        <td>
            <asp:Label ID="lblPrice" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Color</b>
        </td>
        <td>
            <asp:Label ID="lblColor" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Size</b>
        </td>
        <td>
            <asp:Label ID="lblSize" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Weight</b>
        </td>
        <td>
            <asp:Label ID="lblWeight" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Quantity In Stoc</b>
        </td>
        <td>
            <asp:Label ID="lblQuantityInStock" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Discontinued</b>
        </td>
        <td>
            <asp:Label ID="lblDiscontinued" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Supplier</b>
        </td>
        <td>
            <asp:Label ID="lblSupplier" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</div>
    </form>
</body>
</html>
