<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UsingStoredProcedureWithObjectDataSour.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllDepartments" TypeName="UsingStoredProcedureWithObjectDataSour.DepartmentDataAccessLayer"></asp:ObjectDataSource>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="DepartmentName" DataValueField="DepartmentId">
        </asp:DropDownList>
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAllEmployees" TypeName="UsingStoredProcedureWithObjectDataSour.EmployeeDataAccessLayer">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="departmentId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId" />
                <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" SortExpression="EmployeeName" />
                <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />
            </Columns>
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
    
    </div>
    </form>
</body>
</html>
