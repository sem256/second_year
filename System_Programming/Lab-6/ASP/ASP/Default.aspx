<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 21px;
        }
        .auto-style3 {
            height: 21px;
            width: 199px;
        }
        .auto-style4 {
            width: 199px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label1" runat="server" Text="X"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Y"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:TextBox ID="TextBoxX" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxY" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="OK" />
            </td>
            <td>
                <asp:Label ID="LabelAnswer" runat="server" Text="Answer"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
    
</body>
</html>
