<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BasicLoginProject.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register New user Authentication, also Vulnerable to Sniffing</title>
</head>
<body>
    <a href="Login.aspx">Login.aspx</a>
    <form id="form1" runat="server">
        <div>
            <h3>Registration Page</h3>
            <table>
                <tr>
                    <td>Email Address</td>

                    <td>
                        <asp:TextBox ID="username_field" runat="server" /></td>

                    <td>
                        <asp:RequiredFieldValidator ID="usernameRequiredField"
                            ControlToValidate="username"
                            Display="Dynamic"
                            ErrorMessage="Username Cannot be Empty"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Password</td>

                    <td>
                        <asp:TextBox ID="password_field" runat="server" TextMode="Password" /></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ControlToValidate="password"
                            Display="Dynamic"
                            ErrorMessage="Password Cannot be Empty"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Roles</td>

                    <td>
                        <asp:TextBox ID="roles_field" runat="server"/></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            ControlToValidate="Roles"
                            Display="Dynamic"
                            ErrorMessage="Roles Cannot be Empty"
                            runat="server" />
                    </td>
                </tr>
            </table>
            <asp:Button ID="Submit" runat="server" OnClick="Register_Click" Text="Register!" />
            <p>
                <asp:Label ID="msg" ForeColor="Red" runat="server" />
            </p>

        </div>
    </form>
</body>
</html>
