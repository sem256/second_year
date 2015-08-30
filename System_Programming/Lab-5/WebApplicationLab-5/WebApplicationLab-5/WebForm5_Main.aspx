<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5_Main.aspx.cs" Inherits="WebApplicationLab_5.WebForm5_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color:mintcream;
        }
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 304px;
        }

        .auto-style5 {
            width: 304px;
            height: 30px;
        }

        .auto-style7 {
            width: 304px;
            height: 29px;
        }

        .auto-style9 {
            width: 304px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label1" runat="server" Text="Вітаємо Вас на нашому сайті,"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="LabelName" runat="server" Text="Label"></asp:Label>
                        &nbsp;
                    <asp:Label ID="LabelSurName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:Image ID="Image1" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label2" runat="server" Text="Логін:  "></asp:Label>
                        <asp:Label ID="LabelLogin" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="Label4" runat="server" Text="Е-mail:  "></asp:Label>
                        <asp:Label ID="LabelEmail" runat="server" Text="Label"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="ButtonExit" runat="server" Text="ВИХІД" OnClick="ButtonExit_Click" OnClientClick="OnButtonClick1();"/>
                    </td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">
            function OnButtonClick1() {
                document.getElementById("ButtonExit").style.visibility = "hidden";
            }
        </script>
    </form>
</body>
</html>
