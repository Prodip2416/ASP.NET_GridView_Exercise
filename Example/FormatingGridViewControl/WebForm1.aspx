<%@ Page Language="C#" Culture="en-IN" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FormatingGridViewControl.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="EmployeeId" Visible="False" HeaderText="EmployeeId"
                     InsertVisible="False" ReadOnly="True" SortExpression="EmployeeId" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" DataFormatString="{0:D}" SortExpression="DateOfBirth" />
                <asp:BoundField DataField="AnnualSalary" HeaderText="Annual Salary"
                     DataFormatString="{0:c}" SortExpression="AnnualSalary" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" SortExpression="DepartmentName" />
            </Columns>
        </asp:GridView>

        <br/>
        <br/>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="SELECT * FROM [Employee2]"></asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
