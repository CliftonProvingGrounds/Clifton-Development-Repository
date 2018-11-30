<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BasicLoginProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label runat="server" id="Welcome"/>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" text="Log_Out" OnClick="Sign_Out" />
    </div>
    </form>
</body>
</html>
