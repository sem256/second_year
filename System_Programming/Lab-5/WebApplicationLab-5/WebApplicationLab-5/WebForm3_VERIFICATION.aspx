<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3_VERIFICATION.aspx.cs" Inherits="WebApplicationLab_5.WebForm3_VERIFICATION" %>

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

        .auto-style2 {
            width: 552px;
        }

        .auto-style3 {
            width: 552px;
            height: 23px;
        }

        .auto-style4 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="ВЕРИФІКАЦІЯ АДРЕСИ ЕЛЕКТРОННОЇ ПОШТИ"></asp:Label>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="На Вашу адресу направлений одноразовий пароль."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="227px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="NextButton" runat="server" OnClick="NextButton_Click" Text="ЗАРЕЄСТРУВАТИ" OnClientClick="OnButtonClick1();"/>
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="НАЗАД " OnClientClick="OnButtonClick1();"/>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
        <script type="text/javascript">
            function OnButtonClick1() {
                document.getElementById("NextButton").style.visibility = "hidden";
                document.getElementById("Button2").style.visibility = "hidden";
            }
        </script>
    </form>
</body>
</html>
