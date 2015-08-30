<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationTest.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <asp:Button ID="Button1" runat="server" Text="Button" Height="34px" style="height: 0px" Width="81px" />
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                 <asp:Button ID="Button2" runat="server" Text="Button" Height="34px" style="height: 0px" Width="81px" />
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
                 </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
