<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUDexercise.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84"
                          BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                          CellSpacing="2" AutoGenerateColumns="False" DataKeyNames="EmployeeId" DataSourceID="SqlDataSource1" ShowFooter="True">
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
                            <asp:LinkButton ID="LinkButton1" ValidationGroup="Insert"  OnClick="LinkButton1_OnClick" runat="server">Insert</asp:LinkButton>
                            
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server"
                                                        ErrorMessage="Name is Required" Text="*"
                                                        ForeColor="red" ValidationGroup="Insert" 
                                ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" SelectedValue='<%# Bind("Gender") %>' runat="server">
                                <asp:ListItem>Select Gender</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>FeMale</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlGender" runat="server">
                                <asp:ListItem>Select Gender</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>FeMale</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server"
                                                        ErrorMessage="Gender is Required" ValidationGroup="Insert" Text="*"
                                                        ForeColor="red" InitialValue="Select Gender" ControlToValidate="ddlGender"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City" SortExpression="City">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" ValidationGroup="Insert" runat="server"
                                                        ErrorMessage="City is Required" Text="*"
                                                        ForeColor="red" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
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
            <asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup="Insert" ForeColor="red"  runat="server" />

            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" DeleteCommand="DELETE FROM [Employee4] WHERE [EmployeeId] = @EmployeeId" InsertCommand="INSERT INTO [Employee4] ([Name], [Gender], [City]) VALUES (@Name, @Gender, @City)" SelectCommand="SELECT * FROM [Employee4]" UpdateCommand="UPDATE [Employee4] SET [Name] = @Name, [Gender] = @Gender, [City] = @City WHERE [EmployeeId] = @EmployeeId">
                <DeleteParameters>
                    <asp:Parameter Name="EmployeeId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="EmployeeId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
