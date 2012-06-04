<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SSOClientWeb.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Label ID="lblUserId" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnSignOut" runat="server" Text="注销" 
            onclick="btnSignOut_Click" />
        
    
    </form>
</body>
</html>
