<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignOn.aspx.cs" Inherits="SSOServerWeb.SignOn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
    <tr><td>用户名:</td><td>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td></tr>
    <tr><td>密码:</td><td>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td></tr>
    <tr><td colspan="2" align="right">
        <asp:Label ID="lblerror" runat="server" ForeColor="Red" Text=""></asp:Label><asp:Button ID="btnSignOn" runat="server" Text="登录" onclick="btnSignOn_Click" /></td></tr>
    </table>
    </form>
</body>
</html>
