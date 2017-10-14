<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UsingStoredProcedureWithSQLdataSource.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="spGetDepartments" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="DepartmentId">
        </asp:DropDownList>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="spGetEmployeesByDepartmentId" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="-1" Name="DepartmentId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="EmployeeId" DataSourceID="SqlDataSource2" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeId" />
                <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" SortExpression="EmployeeName" />
                <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
