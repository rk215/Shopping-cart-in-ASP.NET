<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProductPage.aspx.vb" Inherits="ProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" CssClass="grid " runat="server" AutoGenerateColumns="False"
                Caption="Products" CellSpacing="15" CellPadding="15" DataKeyNames="id"
                DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False"
                        ReadOnly="True" SortExpression="id" />
                    <asp:TemplateField HeaderText="Images">
                        <ItemTemplate>
                            <asp:Image ID="Image1" CssClass="img" ImageUrl='<%#bind("img") %>' runat="server" />
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:BoundField DataField="nm" HeaderText="nm" SortExpression="nm" />
                    <asp:BoundField DataField="disc" HeaderText="disc" SortExpression="disc" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                SelectCommand="SELECT * FROM [products]"></asp:SqlDataSource>
        </div>

    </form>
</body>
</html>
