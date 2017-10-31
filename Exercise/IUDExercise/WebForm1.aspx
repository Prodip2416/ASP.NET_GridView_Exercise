<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IUDExercise.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="EmployeeId" DataSourceID="SqlDataSource1" ShowFooter="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
                <asp:TemplateField HeaderText="EmployeeId" InsertVisible="False" SortExpression="EmployeeId">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeId") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="btnInsert" OnClick="btnInsert_OnClick" ValidationGroup="Insert" runat="server">Insert</asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ErrorMessage="Name is Required"
                                                    ControlToValidate="TextBox1" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Insert" runat="server"
                                                    ErrorMessage="Name is Required"
                                                    ControlToValidate="txtName" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Gender") %>'>
                            <asp:ListItem>Select Gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>FeMale</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ddlGender" runat="server"
                                                    ErrorMessage="Gender is Required"
                                                    ControlToValidate="DropDownList1" Text="*" ForeColor="red" InitialValue="Select Gender"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>Select Gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>FeMale</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ddlGender" ValidationGroup="Insert" runat="server"
                                                    ErrorMessage="Gender is Required"
                                                    ControlToValidate="DropDownList2" Text="*" ForeColor="red" InitialValue="Select Gender"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="salary" SortExpression="salary">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("salary") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ErrorMessage="Salary is Required"
                                                    ControlToValidate="textBox3" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("salary") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Insert" ID="RequiredFieldValidator3" runat="server"
                                                    ErrorMessage="Salary is Required"
                                                    ControlToValidate="txtSalary" Text="*" ForeColor="red"></asp:RequiredFieldValidator>
                    </FooterTemplate>
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
        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" ForeColor="red" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary2" ForeColor="red" runat="server" />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>"
                           DeleteCommand="DELETE FROM [tblEmployee] WHERE [EmployeeId] = @EmployeeId"
                           InsertCommand="INSERT INTO [tblEmployee] ([Name], [Gender], [salary]) VALUES (@Name, @Gender, @salary)"
                           SelectCommand="SELECT * FROM [tblEmployee]"
                           UpdateCommand="UPDATE [tblEmployee] SET [Name] = @Name, [Gender] = @Gender,
             [salary] = @salary WHERE [EmployeeId] = @EmployeeId">
            <DeleteParameters>
                <asp:Parameter Name="EmployeeId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="salary" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="salary" Type="Int32" />
                <asp:Parameter Name="EmployeeId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
