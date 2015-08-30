<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2_Registration.aspx.cs" Inherits="WebApplicationLab_5.WebForm2_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: mintcream;
        }

        .auto-style1 {
            height: 28px;
        }

        .auto-style2 {
            height: 29px;
        }

        .auto-style3 {
            height: 31px;
        }

        .auto-style4 {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Фото"></asp:Label>
                        :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Поле не може бути пустим" ValidationGroup="valid" BackColor="#FF9966"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style8">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="366px" />
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Не правильний розмір картинки" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="valid" BackColor="#FF9966"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="ІМ'Я:"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Поле не може бути пустим" ValidationGroup="valid" BackColor="#FF9966"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="Label9" runat="server" Text="ПРІЗВИЩЕ:"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Поле не може бути пустим" ValidationGroup="valid" BackColor="#FF9966"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox1" runat="server" Width="216px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox2" runat="server" Width="239px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Логін:"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Поле не може бути пустим" ValidationGroup="valid" BackColor="#FF9966"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="Label8" runat="server" Text="E-mail:"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Поле не може бути пустим" ValidationGroup="valid" BackColor="#FF9966"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server" Width="217px"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" BackColor="#FF9966" ControlToValidate="TextBox3" ErrorMessage="Вже існує" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="valid"></asp:CustomValidator>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="TextBox4" runat="server" Width="239px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="Введіть правильно Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="valid" BackColor="#FF9966"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Пароль"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Поле не може бути пустим" ValidationGroup="valid" BackColor="#FF9966"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="Поле не може бути пустим" ValidationGroup="valid" BackColor="#FF9966"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Width="215px" type="password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox5" ControlToValidate="TextBox6" ErrorMessage="Паролі не співпадають" ValidationGroup="valid" BackColor="#FF9966"></asp:CompareValidator>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox6" runat="server" Width="239px" type="password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Студент" GroupName="MyGroup" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" />
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Викладач" GroupName="MyGroup" Checked="True" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="True" />
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Навчально-допоміжний персонал" GroupName="MyGroup" AutoPostBack="True" OnCheckedChanged="RadioButton3_CheckedChanged" />
                    </td>
                    <td class="auto-style9">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Майстер спорту" />
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="Кандидат наук" />
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="Доктор наук" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label5" runat="server" Text="Курс:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:Label ID="Label7" runat="server" Text="Факультет:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="232px" Height="22px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="129px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="Label6" runat="server" Text="Структурний підрозділ:"></asp:Label>
                    </td>
                    <td class="auto-style14"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:DropDownList ID="DropDownList3" runat="server" Width="237px" Height="23px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="ButtonNext" runat="server" Text="ДАЛІ" Width="107px" OnClick="ButtonNext_Click" ValidationGroup="valid" OnClientClick="OnButtonClick1();" />
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="ButtonBack" runat="server" Text="НАЗАД" Width="115px" OnClick="ButtonBack_Click" OnClientClick="OnButtonClick1();" />
                    </td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">
            function OnButtonClick1() {
                document.getElementById("ButtonNext").style.visibility = "hidden";
                document.getElementById("ButtonBack").style.visibility = "hidden";
            }
        </script>
    </form>
</body>
</html>
