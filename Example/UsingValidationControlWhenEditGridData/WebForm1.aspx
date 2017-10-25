﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="OptimisticConcurrencyWhenEditData.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:GridView ID="GridView1" DataKeyNames="EmployeeId" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <Columns>
                <asp:CommandField ShowEditButton="True"/>
                <asp:BoundField DataField="EmployeeId" ReadOnly="True" HeaderText="EmployeeId" SortExpression="EmployeeId"/>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is Required"
                                                    ControlToValidate="TextBox1" ForeColor="red" Text="*"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" SelectedValue='<%# Bind("Gender") %>' runat="server">
                            <asp:ListItem>Select Gender</asp:ListItem>
                            <asp:ListItem>FeMale</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select Gender" runat="server" ErrorMessage="Gender is Required"
                                                    ControlToValidate="DropDownList1" ForeColor="red" Text="*"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City" SortExpression="City">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="City is Required"
                                                    ControlToValidate="TextBox3" ForeColor="red" Text="*"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"/>
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White"/>
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center"/>
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"/>
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"/>
            <SortedAscendingCellStyle BackColor="#FFF1D4"/>
            <SortedAscendingHeaderStyle BackColor="#B95C30"/>
            <SortedDescendingCellStyle BackColor="#F1E5CE"/>
            <SortedDescendingHeaderStyle BackColor="#93451F"/>
        </asp:GridView>
        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="red" runat="server" />
        <br />
        <br />
        <asp:ObjectDataSource ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}"
            ID="ObjectDataSource1" runat="server" SelectMethod="GetAllEmployees" TypeName="EditUpdatingOnObjectDataSource.EmployeeDataAccessLayer" UpdateMethod="UpdateEmployee">
            <UpdateParameters>
                <asp:Parameter Name="EmployeeId" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="City" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>