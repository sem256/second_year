<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1_Input.aspx.cs" Inherits="WebApplicationLab_5.WebForm1_Input" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JavaScript.js"></script>
    <style type="text/css">
        body {
            background-color: mintcream;
        }
        #mainid{
            align-self:center;
            height:400px;
        }
    </style>
</head>
<body>
    <div id="mainid">
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="Label1" runat="server" Text="САЙТ З АВТОРИЗОВАНИМ ДОСТУПОМ"></asp:Label>
            </div>
            <p>
                <asp:Label ID="Label2" runat="server" Text="ЛОГІН:"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" Width="181px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox1" ErrorMessage="Поле не може бути пустим" ValidationGroup="CV" BackColor="#FF9966"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="ПАРОЛЬ:"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="TextBox2" runat="server" Width="177px" Type="password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text=" ВХІД" Width="94px" OnClick="Button1_Click" Style="height: 26px" ValidationGroup="CV" OnClientClick="OnButtonClick1();"/>
                <asp:CustomValidator ID="CustomValidator1" runat="server" BackColor="#FF9966" ControlToValidate="TextBox1" ErrorMessage="Такого користувача не існує" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="CV"></asp:CustomValidator>
            </p>
            <p>
                <asp:Button ID="Button2" runat="server" Text="РЕЄСТРАЦІЯ" Width="136px" OnClick="Button2_Click" OnClientClick="OnButtonClick1();"/>
            </p>
            <script type="text/javascript">
                function OnButtonClick1() {
                    document.getElementById("Button2").style.visibility = "hidden";
                    document.getElementById("Button1").style.visibility = "hidden";
                }
            </script>
        </form>
    </div>
</body>
</html>
