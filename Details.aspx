<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView CssClass="detail" ID="DetailsView1" runat="server" Height="50px"
                Width="125px"
                AutoGenerateRows="False" CellSpacing="10" CellPadding="10" Caption="Product Details Page"
                DataKeyNames="id" DataSourceID="SqlDataSource1">
                <Fields>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbid" runat="server" Text='<%#bind("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Lbname" runat="server" Text='<%#bind("nm") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Images">
                        <ItemTemplate>
                            <asp:Image ID="Image1" CssClass="img" ImageUrl='<%#bind("img") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="Lbdesc" runat="server" Text='<%#bind("disc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="Lbprice" runat="server" Text='<%#bind("price") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                SelectCommand="SELECT * FROM [products] WHERE ([id] = @id)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
            <asp:Button ID="Button2" CssClass="btseecart " runat="server" Text="See Cart" />


            <asp:Button ID="Button1" CssClass="btaddtocart " runat="server" Text="Add to cart" />
        </div>
        <br />
        <asp:Label CssClass="msg" ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
