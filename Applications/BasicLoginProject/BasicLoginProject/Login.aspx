<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BasicLoginProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Authentication, Vulnerable to Sniffing</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Login Page</h3>
        <a href="Register.aspx">Register.aspx</a>
        <table>
            <tr>
                <td>Email Address</td>

                <td><asp:TextBox ID="username" runat="server" /></td>

                <td><asp:RequiredFieldValidator ID="usernameRequiredField"
                    ControlToValidate ="username"
                    Display="Dynamic"
                    ErrorMessage="Username Cannot be Empty"
                    runat="server" />
                </td>
            </tr>
            <tr>
                <td>Password</td>

                <td><asp:TextBox ID="password" runat="server" TextMode="Password" /></td>

                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    ControlToValidate ="password"
                    Display="Dynamic"
                    ErrorMessage="Password Cannot be Empty"
                    runat="server" />
                </td>
            </tr>
            <tr>
                <td>Remembuh me?</td>
                <td><asp:CheckBox ID="Persist" runat="server" /></td>
            </tr>
        </table>
        <asp:Button ID="Submit" runat="server" OnClick="Login_Click" Text="Log On" />
        <p>
            <asp:Label ID="msg" ForeColor="Red" runat="server" />
        </p>

    </div>
    </form>
</body>
</html>
