<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4_YesOrNo.aspx.cs" Inherits="WebApplicationLab_5.WebForm4_YesOrNo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: mintcream;
        }

        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="height: 26px" Text="НА ГОЛОВНУ" OnClientClick="OnButtonClick1();"/>
                    </td>
                </tr>
            </table>

        </div>
        <script type="text/javascript">
            function OnButtonClick1() {
                document.getElementById("Button1").style.visibility = "hidden";
            }
        </script>
    </form>
</body>
</html>
