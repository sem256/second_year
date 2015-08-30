<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="JavaScript1.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        <asp:Image ID="Image1" Runat="server"  ImageUrl="~\image\IMG_1651 — копия.jpg"/><br />
        <br />
        <asp:Button ID="Button1" Runat="server" Text="Change Image" 
         OnClick="Button1_Click" />
    </div>
    </div>
    </form>
</body>
</html>
