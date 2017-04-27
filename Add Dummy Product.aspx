<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add Dummy Product.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" placeholder="name" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" placeholder="description" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox3" placeholder="price" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server"            Text="Button" />
    </div>
    </form>
</body>
</html>
